using GeneralFormLibrary1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralFormLibrary1
{
    public class DataCollector
    {
        Dictionary<string, string> DBcredentials { get; set; }

        public DataCollector(Dictionary<string,string> dbCredentials)
        {
            DBcredentials = dbCredentials;
        }

        public enum Frequency
        {
            Daily,
            Monthly,
            Quarterly
        }

        public async void GetDataFromActiveJobs(Frequency frequency, StatusStrip statusStrip)
        {
            DateTime dateTime = DateTime.Today;

            DataAccess<DataModels.Model_DataImportJob> dataAccess = new DataAccess<DataModels.Model_DataImportJob>(DBcredentials);
            List<DataModels.Model_DataImportJob> ImportJobs = await dataAccess.GetAll();

            DataAccess<DataModels.Model_DataSource> dataAccess2 = new DataAccess<DataModels.Model_DataSource>(DBcredentials);
            List<DataModels.Model_DataSource> dataSources = await dataAccess2.GetAll();

            DataAccess<DataModels.Model_SecurityPriceType> dataAccess3 = new DataAccess<DataModels.Model_SecurityPriceType>(DBcredentials);
            List<DataModels.Model_SecurityPriceType> secPriceTypes = await dataAccess3.GetAll();
            int count = 0;
            foreach (DataModels.Model_DataImportJob job in ImportJobs)
            {
                count++;
                string Status = "Running Job: " + count.ToString() + " of " + ImportJobs.Count();
                FormControls.UpdateToolStripItemLabel_Async(statusStrip, Status);
                bool jobSuccessfullyRun = false;
                int DataJobImportJobTypeId = job.DataImportJobTypeId;
                DataAccess<DataModels.Model_DataImportJobType> da = new DataAccess<DataModels.Model_DataImportJobType>(DBcredentials);
                DataModels.Model_DataImportJobType jobType = await da.Get(DataJobImportJobTypeId);
                int PricesNeedUpdating = 0;
                if (job.ActiveState == 1 && (!job.LastRunDateTime.HasValue || job.LastRunDateTime.Value.Date < DateTime.Today.Date))
                {
                    if (jobType.DataSourceId == 1)
                    {
                        int SecurityId = job.SecurityId;
                        //int DataSourceId = jobType.DataSourceId;
                        int DataSourceId = 6;
                        DataAccess <DataModels.Model_Security> da2 = new DataAccess<DataModels.Model_Security>(DBcredentials);
                        DataModels.Model_Security Sec = await da2.Get(SecurityId);
                        string APIQuery = jobType.Query.Replace("(***TICKER***)", Sec.Ticker).Replace("(***KEY***)", dataSources.Where(x => x.Id == DataSourceId).FirstOrDefault().Key);

                        //Alpha Vantage crypto daily
                        if (jobType.Id == 1)
                        {
                            PricesNeedUpdating = await UploadAlphaVantageDailyData(dateTime, SecurityId, jobType, APIQuery, "Time Series (Digital Currency Daily)", " (usd)");
                            int requestsPerMinute = dataSources.Find(x => x.Id == 1).RequestLimitPerMin;
                            await Task.Run(() => System.Threading.Thread.Sleep(60000 / requestsPerMinute));
                            jobSuccessfullyRun = true;
                        }
                        //Alpha Vantage fx intraday (5min)
                        if (jobType.Id == 2)
                        {
                            PricesNeedUpdating = await UploadAlphaVantageIntradayData(dateTime, SecurityId, jobType, APIQuery, "Time Series Crypto (5min)");
                            int requestsPerMinute = dataSources.Find(x => x.Id == 1).RequestLimitPerMin;
                            await Task.Run(() => System.Threading.Thread.Sleep(60000 / requestsPerMinute));
                            jobSuccessfullyRun = true;
                        }
                        //Alpha Vantage fx daily
                        else if (jobType.Id == 3)
                        {
                            PricesNeedUpdating = await UploadAlphaVantageDailyData(dateTime, SecurityId, jobType, APIQuery, "Time Series FX (Daily)");
                            int requestsPerMinute = dataSources.Find(x => x.Id == 1).RequestLimitPerMin;
                            await Task.Run(() => System.Threading.Thread.Sleep(60000 / requestsPerMinute));
                            jobSuccessfullyRun = true;
                        }
                        else if (jobType.Id == 4)
                        {
                            PricesNeedUpdating = await UploadAlphaVantageIntradayData(dateTime, SecurityId, jobType, APIQuery, "Time Series FX (5min)");
                            int requestsPerMinute = dataSources.Find(x => x.Id == 1).RequestLimitPerMin;
                            await Task.Run(() => System.Threading.Thread.Sleep(60000 / requestsPerMinute));
                            jobSuccessfullyRun = true;
                        }
                        else if (jobType.Id == 5)
                        {
                            PricesNeedUpdating = await UploadAlphaVantageDailyData(dateTime, SecurityId, jobType, APIQuery, "Time Series (Daily)");
                            int requestsPerMinute = dataSources.Find(x => x.Id == 1).RequestLimitPerMin;
                            await Task.Run(() => System.Threading.Thread.Sleep(60000 / requestsPerMinute));
                            jobSuccessfullyRun = true;
                        }
                    }

                    if(jobSuccessfullyRun == true)
                    {
                        //Update run date time
                        job.LastRunDateTime = DateTime.Now;
                        job.PriceUpdatesNeeded = PricesNeedUpdating;
                        await dataAccess.Update(job);
                    }
                    
                } 
            }
            MessageBox.Show("Done");
        }

        private async Task<int> UploadAlphaVantageDailyData(DateTime dateTime, int SecurityId, Model_DataImportJobType jobType, string APIQuery, string ObjectHeaderString, string ExtraKeyEndingString = null)
        {
            AlphaVantageAPI api = new AlphaVantageAPI();
            Dictionary<string, Dictionary<string, string>> timeSeriesData = api.GetTimeSeries(APIQuery, ObjectHeaderString);

            if(timeSeriesData.Count <= 0)
            {
               MessageBox.Show("API request returned no data.");
               return 0; //Error in API request
            }

            //Build list to upload
            List<DataModels.Model_SecurityPrice> securityPrices = new List<DataModels.Model_SecurityPrice>();
            List<DataModels.Model_SecurityVolume> securityVolumes = new List<DataModels.Model_SecurityVolume>();
            List<DataModels.Model_SecurityDistribution> securityDistributions = new List<DataModels.Model_SecurityDistribution>();
            List<DataModels.Model_SecuritySplit> securitySplit= new List<DataModels.Model_SecuritySplit>();

            foreach (KeyValuePair<string, Dictionary<string, string>> priceObj in timeSeriesData)
            {
                //Ignore today's prices
                if (DateTime.Parse(priceObj.Key) < dateTime)
                {
                    bool openFound = false;
                    bool highFound = false;
                    bool lowFound = false;
                    bool closeFound = false;
                    bool volumeFound = false;
                    bool splitCoeffiecentFound = false;
                    bool dividendFound = false;

                    foreach (KeyValuePair<string, string> price in priceObj.Value)
                    {
                        if (volumeFound == false && price.Key.ToLower().Contains("volume"))
                        {
                            volumeFound = true;
                            DataModels.Model_SecurityVolume volume = new DataModels.Model_SecurityVolume();
                            volume.Date = DateTime.Parse(priceObj.Key);
                            volume.DataSourceId = jobType.DataSourceId;
                            volume.SecurityId = SecurityId;
                            volume.Value = Decimal.Parse(price.Value);
                            securityVolumes.Add(volume);
                        }
                        else if (dividendFound == false && price.Key.ToLower().Contains("dividend amount"))
                        {
                            //If there is a dividend to report, than save it.
                            if(Decimal.Parse(price.Value) != 0)
                            {
                                dividendFound = true;
                                DataModels.Model_SecurityDistribution dividend = new DataModels.Model_SecurityDistribution();
                                dividend.Date = DateTime.Parse(priceObj.Key);
                                dividend.DataSourceId = jobType.DataSourceId;
                                dividend.DistributionTypeId = 1; //For dividend type
                                dividend.SecurityId = SecurityId;
                                dividend.Value = Decimal.Parse(price.Value);
                                securityDistributions.Add(dividend);
                            }
                        }
                        else if (splitCoeffiecentFound == false && price.Key.ToLower().Contains("split coefficient"))
                        {
                            //If there is a split coeffient to report, then save it.
                            if(Decimal.Parse(price.Value) != 1)
                            {
                                splitCoeffiecentFound = true;
                                DataModels.Model_SecuritySplit split = new DataModels.Model_SecuritySplit();
                                split.Date = DateTime.Parse(priceObj.Key);
                                split.DataSourceId = jobType.DataSourceId;
                                split.SecurityId = SecurityId;
                                split.SplitCoefficient = Decimal.Parse(price.Value);
                                securitySplit.Add(split);
                            }
                        }
                        else
                        {
                            DataModels.Model_SecurityPrice secPrice = new DataModels.Model_SecurityPrice();
                            if (closeFound == false && price.Key.ToLower().Contains("close" + ExtraKeyEndingString) )
                            {
                                closeFound = true;
                                secPrice.SecurityPriceTypeId = 1;
                            }
                            else if (openFound == false && price.Key.ToLower().Contains("open" + ExtraKeyEndingString))
                            {
                                openFound = true;
                                secPrice.SecurityPriceTypeId = 2;
                            }
                            else if (highFound == false && price.Key.ToLower().Contains("high" + ExtraKeyEndingString))
                            {
                                highFound = true;
                                secPrice.SecurityPriceTypeId = 3;
                            }
                            else if (lowFound == false && price.Key.ToLower().Contains("low" + ExtraKeyEndingString))
                            {
                                lowFound = true;
                                secPrice.SecurityPriceTypeId = 4;
                            }

                            if (secPrice.SecurityPriceTypeId > 0)
                            {
                                secPrice.Date = DateTime.Parse(priceObj.Key);
                                secPrice.DataSourceId = jobType.DataSourceId;
                                secPrice.SecurityId = SecurityId;
                                secPrice.Value = Decimal.Parse(price.Value);
                                securityPrices.Add(secPrice);
                            }
                        }
                    }
                }
            }

            List<DataModels.Model_SecurityPrice> finalSecPricesForInsert = new List<Model_SecurityPrice>();
            List<DataModels.Model_SecurityPrice> finalSecPricesForUpdate = new List<Model_SecurityPrice>();
            List<DataModels.Model_SecurityVolume> finalSecVolumesForInsert = new List<Model_SecurityVolume>();
            List<DataModels.Model_SecurityDistribution> finalSecDistributionsForInsert = new List<Model_SecurityDistribution>();
            List<DataModels.Model_SecuritySplit> finalSecSplitsForInsert = new List<Model_SecuritySplit>();

            if (securityPrices. Count > 0)
            {
                finalSecPricesForInsert = SecurityPriceListToFinalListForInsert(securityPrices);
                finalSecPricesForUpdate = SecurityListToSecurityListForUpdate(securityPrices);
            }
            
            if(securityVolumes.Count > 0)
            {
                finalSecVolumesForInsert = SecurityVolumeListToFinalListForInsert(securityVolumes);
            }

            if(securityDistributions.Count > 0)
            {
                finalSecDistributionsForInsert = SecurityDistributionListToFinalListForInsert(securityDistributions);
            }

            if(securitySplit.Count > 0)
            {
                finalSecSplitsForInsert = SecuritySplitListToFinalListForInsert(securitySplit);
            }

            //Insert data
            if (finalSecPricesForInsert.Count > 0)
            {
                //MessageBox.Show("About to insert " + finalSecPricesForInsert.Count.ToString() +  " prices");
                DataAccess<DataModels.Model_SecurityPrice> daSecPrice = new DataAccess<DataModels.Model_SecurityPrice>(DBcredentials);
                int recordsInserted = await daSecPrice.Insert(finalSecPricesForInsert);
                //MessageBox.Show(recordsInserted.ToString() + " price records inserted");
            }

            //Insert data
            if (finalSecVolumesForInsert.Count > 0)
            {
                //MessageBox.Show("About to insert " +  finalSecVolumesForInsert.Count.ToString() + " volume");
                DataAccess<DataModels.Model_SecurityVolume> daSecVolume = new DataAccess<DataModels.Model_SecurityVolume>(DBcredentials);
                int recordsInserted = await daSecVolume.Insert(finalSecVolumesForInsert);
                //MessageBox.Show(recordsInserted.ToString() + " volume records inserted");
            }

            if(finalSecDistributionsForInsert.Count > 0)
            {
                DataAccess<DataModels.Model_SecurityDistribution> daSecDist = new DataAccess<DataModels.Model_SecurityDistribution>(DBcredentials);
                int recordsInserted = await daSecDist.Insert(finalSecDistributionsForInsert);
            }

            if (finalSecSplitsForInsert.Count > 0)
            {
                DataAccess<DataModels.Model_SecuritySplit> daSecSplits = new DataAccess<DataModels.Model_SecuritySplit>(DBcredentials);
                int recordsInserted = await daSecSplits.Insert(finalSecSplitsForInsert);
            }

            //Report securities that need to be updated
            if (finalSecPricesForUpdate.Count > 0)
            {
                ExcelAPI excel = new ExcelAPI();
                excel.ExportDataToSheet<Model_SecurityPrice>(finalSecPricesForUpdate, true, FileName: "PricesToUpdate");
            }
            return finalSecPricesForUpdate.Count();
        }

        private async Task<int> UploadAlphaVantageIntradayData(DateTime dateTime, int SecurityId, Model_DataImportJobType jobType, string APIQuery, string ObjectHeaderString, string ExtraKeyEndingString = null)
        {
            AlphaVantageAPI api = new AlphaVantageAPI();
            Dictionary<string, Dictionary<string, string>> timeSeriesData = api.GetTimeSeries(APIQuery, ObjectHeaderString);

            if (timeSeriesData.Count <= 0)
            {
                MessageBox.Show("API request returned no data.");
                return 0; //Error in API request
            }

            //Build list to upload
            List<DataModels.Model_SecurityPriceIntraday> securityPrices = new List<DataModels.Model_SecurityPriceIntraday>();
            List<DataModels.Model_SecurityVolumeIntraday> securityVolumes = new List<DataModels.Model_SecurityVolumeIntraday>();

            foreach (KeyValuePair<string, Dictionary<string, string>> priceObj in timeSeriesData)
            {
                //Ignore today's prices
                if (DateTime.Parse(priceObj.Key) < dateTime)
                {
                    bool openFound = false;
                    bool highFound = false;
                    bool lowFound = false;
                    bool closeFound = false;
                    bool volumeFound = false;

                    foreach (KeyValuePair<string, string> price in priceObj.Value)
                    {
                        if (volumeFound == false && price.Key.ToLower().Contains("volume"))
                        {
                            volumeFound = true;
                            DataModels.Model_SecurityVolumeIntraday volume = new DataModels.Model_SecurityVolumeIntraday();
                            volume.DateTime = DateTime.Parse(priceObj.Key);
                            volume.DataSourceId = jobType.DataSourceId;
                            volume.SecurityId = SecurityId;
                            volume.Value = Decimal.Parse(price.Value);
                            securityVolumes.Add(volume);
                        }
                        else
                        {
                            DataModels.Model_SecurityPriceIntraday secPrice = new DataModels.Model_SecurityPriceIntraday();
                            if (closeFound == false && price.Key.ToLower().Contains("close" + ExtraKeyEndingString))
                            {
                                closeFound = true;
                                secPrice.SecurityPriceTypeId = 1;
                            }
                            else if (openFound == false && price.Key.ToLower().Contains("open" + ExtraKeyEndingString))
                            {
                                openFound = true;
                                secPrice.SecurityPriceTypeId = 2;
                            }
                            else if (highFound == false && price.Key.ToLower().Contains("high" + ExtraKeyEndingString))
                            {
                                highFound = true;
                                secPrice.SecurityPriceTypeId = 3;
                            }
                            else if (lowFound == false && price.Key.ToLower().Contains("low" + ExtraKeyEndingString))
                            {
                                lowFound = true;
                                secPrice.SecurityPriceTypeId = 4;
                            }


                            if (secPrice.SecurityPriceTypeId > 0)
                            {
                                secPrice.DateTime = DateTime.Parse(priceObj.Key);
                                secPrice.DataSourceId = jobType.DataSourceId;
                                secPrice.SecurityId = SecurityId;
                                secPrice.Value = Decimal.Parse(price.Value);
                                securityPrices.Add(secPrice);
                            }

                        }
                    }

                }
            }

            List<DataModels.Model_SecurityPriceIntraday> finalSecPricesForInsert = new List<Model_SecurityPriceIntraday>();
            List<DataModels.Model_SecurityPriceIntraday> finalSecPricesForUpdate = new List<Model_SecurityPriceIntraday>();
            List<DataModels.Model_SecurityVolumeIntraday> finalSecVolumesForInsert = new List<Model_SecurityVolumeIntraday>();
            if (securityPrices.Count > 0)
            {
                finalSecPricesForInsert = SecurityPriceListToFinalListForInsert_Intraday(securityPrices);
                finalSecPricesForUpdate = SecurityListToSecurityListForUpdate_Intraday(securityPrices);
            }

            if (securityVolumes.Count > 0)
            {
                finalSecVolumesForInsert = SecurityVolumeListToFinalListForInsert_Intraday(securityVolumes);
            }

            //Insert data
            if (finalSecPricesForInsert.Count > 0)
            {
                //MessageBox.Show("About to insert " + finalSecPricesForInsert.Count.ToString() +  " prices");
                DataAccess<DataModels.Model_SecurityPriceIntraday> daSecPrice = new DataAccess<DataModels.Model_SecurityPriceIntraday>(DBcredentials);
                int recordsInserted = await daSecPrice.Insert(finalSecPricesForInsert);
                //MessageBox.Show(recordsInserted.ToString() + " price records inserted");
            }

            //Insert data
            if (finalSecVolumesForInsert.Count > 0)
            {
                //MessageBox.Show("About to insert " +  finalSecVolumesForInsert.Count.ToString() + " volume");
                DataAccess<DataModels.Model_SecurityVolumeIntraday> daSecVolume = new DataAccess<DataModels.Model_SecurityVolumeIntraday>(DBcredentials);
                int recordsInserted = await daSecVolume.Insert(finalSecVolumesForInsert);
                //MessageBox.Show(recordsInserted.ToString() + " volume records inserted");
            }

            //Report securities that need to be updated
            if (finalSecPricesForUpdate.Count > 0)
            {
                ExcelAPI excel = new ExcelAPI();
                excel.ExportDataToSheet<Model_SecurityPriceIntraday>(finalSecPricesForUpdate, true, FileName: "PricesToUpdate");
            }
            return finalSecPricesForUpdate.Count();
        }

        public List<DataModels.Model_SecurityPrice> SecurityPriceListToFinalListForInsert(List<DataModels.Model_SecurityPrice> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).LastOrDefault().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).FirstOrDefault().Date;
            List<int> SecurityPriceTypeIds = list.Select(x => x.SecurityPriceTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityPrice Where SecurityId in (" + string.Join(",", SecurityIds)+ ") And Date >= '" + startDate.ToString("d") + "' And Date <= '" + endDate.ToString("d") + "' And SecurityPriceTypeId in (" + string.Join(",", SecurityPriceTypeIds) + ");";

            //Get data to compare from DB
            List<DataModels.Model_SecurityPrice> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityPrice>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityPrice> finalList = new List<Model_SecurityPrice>();
            int count = 0;
            foreach (DataModels.Model_SecurityPrice price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.SecurityPriceTypeId == price.SecurityPriceTypeId) && (x.Date == price.Date));
                if (DBListIndex >= 0)
                {
                    //Do nothing. Price already exists or needs to be updated
                }
                else
                {
                    //Was not found and we need to insert
                    count++;
                    finalList.Add(price);
                }
            }

            return finalList;
        }

        public List<DataModels.Model_SecurityVolume> SecurityVolumeListToFinalListForInsert(List<DataModels.Model_SecurityVolume> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).LastOrDefault().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).FirstOrDefault().Date;
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityVolume Where SecurityId in (" + string.Join(",", SecurityIds) + ") And Date >= '" + startDate.ToString("d") + "' And Date <= '" + endDate.ToString("d") + "';";

            //Get data to compare from DB
            List<DataModels.Model_SecurityVolume> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityVolume>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityVolume> finalList = new List<Model_SecurityVolume>();
            foreach (DataModels.Model_SecurityVolume price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.Date == price.Date));
                if (DBListIndex >= 0)
                {
                    //Do nothing. Price already exists or needs to be updated
                }
                else
                {
                    //Was not found and we need to insert
                    finalList.Add(price);
                }
            }

            return finalList;
        }

        public List<DataModels.Model_SecurityDistribution> SecurityDistributionListToFinalListForInsert(List<DataModels.Model_SecurityDistribution> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).LastOrDefault().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).FirstOrDefault().Date;
            List<int> DistributionTypeIds = list.Select(x => x.DistributionTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityDistribution Where SecurityId in (" + string.Join(",", SecurityIds) + ") And Date >= '" + startDate.ToString("d") + "' And Date <= '" + endDate.ToString("d") + "' And DistributionTypeId in (" + string.Join(",", DistributionTypeIds) + ");";

            //Get data to compare from DB
            List<DataModels.Model_SecurityDistribution> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityDistribution>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityDistribution> finalList = new List<Model_SecurityDistribution>();
            int count = 0;
            foreach (DataModels.Model_SecurityDistribution price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.DistributionTypeId == price.DistributionTypeId) && (x.Date == price.Date));
                if (DBListIndex >= 0)
                {
                    //Do nothing. Price already exists or needs to be updated
                }
                else
                {
                    //Was not found and we need to insert
                    count++;
                    finalList.Add(price);
                }
            }

            return finalList;
        }

        public List<DataModels.Model_SecuritySplit> SecuritySplitListToFinalListForInsert(List<DataModels.Model_SecuritySplit> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).LastOrDefault().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).FirstOrDefault().Date;
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecuritySplit Where SecurityId in (" + string.Join(",", SecurityIds) + ") And Date >= '" + startDate.ToString("d") + "' And Date <= '" + endDate.ToString("d") + "';";

            //Get data to compare from DB
            List<DataModels.Model_SecuritySplit> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecuritySplit>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecuritySplit> finalList = new List<Model_SecuritySplit>();
            int count = 0;
            foreach (DataModels.Model_SecuritySplit price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.Date == price.Date));
                if (DBListIndex >= 0)
                {
                    //Do nothing. Price already exists or needs to be updated
                }
                else
                {
                    //Was not found and we need to insert
                    count++;
                    finalList.Add(price);
                }
            }

            return finalList;
        }


        public List<DataModels.Model_SecurityPrice> SecurityListToSecurityListForUpdate(List<DataModels.Model_SecurityPrice> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).LastOrDefault().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).FirstOrDefault().Date;
            List<int> SecurityPriceTypeIds = list.Select(x => x.SecurityPriceTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityPrice Where SecurityId in (" + string.Join(",", SecurityIds) + ") And Date >= '" + startDate.ToString("d") + "' And Date <= '" + endDate.ToString("d") + "' And SecurityPriceTypeId in (" + string.Join(",", SecurityPriceTypeIds) + ");";

            //Get data to compare from DB
            List<DataModels.Model_SecurityPrice> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityPrice>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityPrice> finalList = new List<Model_SecurityPrice>();
            foreach (DataModels.Model_SecurityPrice price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.SecurityPriceTypeId == price.SecurityPriceTypeId) && (x.Date == price.Date));
                if (DBListIndex >= 0)
                {
                    //Price already exists
                    if (price.Value != DBList[DBListIndex].Value)
                    {
                        //Price did not match. Needs to be updated
                        finalList.Add(price);
                    }
                }
                else
                {
                    //Was not found and we need to insert
                }
            }

            return finalList;
        }

        public List<DataModels.Model_SecurityPriceIntraday> SecurityPriceListToFinalListForInsert_Intraday(List<DataModels.Model_SecurityPriceIntraday> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.DateTime).LastOrDefault().DateTime;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.DateTime).FirstOrDefault().DateTime;
            List<int> SecurityPriceTypeIds = list.Select(x => x.SecurityPriceTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityPriceIntraday Where SecurityId in (" + string.Join(",", SecurityIds) + ") And DateTime >= '" + startDate.ToString("d") + "' And DateTime <= DATEADD(day, 1,'" + endDate.ToString("d") + "') And SecurityPriceTypeId in (" + string.Join(",", SecurityPriceTypeIds) + ");";
            Clipboard.SetText(query);

            //Get data to compare from DB
            List<DataModels.Model_SecurityPriceIntraday> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityPriceIntraday>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityPriceIntraday> finalList = new List<Model_SecurityPriceIntraday>();
            int count = 0;
            foreach (DataModels.Model_SecurityPriceIntraday price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.SecurityPriceTypeId == price.SecurityPriceTypeId) && (x.DateTime == price.DateTime));
                if (DBListIndex >= 0)
                {
                    //Do nothing. Price already exists or needs to be updated
                }
                else
                {
                    //Was not found and we need to insert
                    count++;
                    finalList.Add(price);
                }
            }

            return finalList;
        }

        public List<DataModels.Model_SecurityVolumeIntraday> SecurityVolumeListToFinalListForInsert_Intraday(List<DataModels.Model_SecurityVolumeIntraday> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.DateTime).LastOrDefault().DateTime;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.DateTime).FirstOrDefault().DateTime;
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityVolumeIntraday Where SecurityId in (" + string.Join(",", SecurityIds) + ") And DateTime >= '" + startDate.ToString("d") + "' And DateTime <= DATEADD(day, 1,'" + endDate.ToString("d") + "');";

            //Get data to compare from DB
            List<DataModels.Model_SecurityVolumeIntraday> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityVolumeIntraday>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityVolumeIntraday> finalList = new List<Model_SecurityVolumeIntraday>();
            foreach (DataModels.Model_SecurityVolumeIntraday price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.DateTime == price.DateTime));
                if (DBListIndex >= 0)
                {
                    //Do nothing. Price already exists or needs to be updated
                }
                else
                {
                    //Was not found and we need to insert
                    finalList.Add(price);
                }
            }

            return finalList;
        }

        public List<DataModels.Model_SecurityPriceIntraday> SecurityListToSecurityListForUpdate_Intraday(List<DataModels.Model_SecurityPriceIntraday> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.DateTime).LastOrDefault().DateTime;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.DateTime).FirstOrDefault().DateTime;
            List<int> SecurityPriceTypeIds = list.Select(x => x.SecurityPriceTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityPriceIntraday Where SecurityId in (" + string.Join(",", SecurityIds) + ") And DateTime >= '" + startDate.ToString("d") + "' And DateTime <= DATEADD(day, 1,'" + endDate.ToString("d") + "') And SecurityPriceTypeId in (" + string.Join(",", SecurityPriceTypeIds) + ");";

            //Get data to compare from DB
            List<DataModels.Model_SecurityPriceIntraday> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityPriceIntraday>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityPriceIntraday> finalList = new List<Model_SecurityPriceIntraday>();
            foreach (DataModels.Model_SecurityPriceIntraday price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.SecurityPriceTypeId == price.SecurityPriceTypeId) && (x.DateTime == price.DateTime));
                

                if (DBListIndex >= 0)
                {
                    //Price already exists
                    if (price.Value != DBList[DBListIndex].Value)
                    {
                        //Price did not match. Needs to be updated
                        finalList.Add(price);
                    }
                }
                else
                {
                    //Was not found and we need to insert
                }
            }

            return finalList;
        }
    }
}
