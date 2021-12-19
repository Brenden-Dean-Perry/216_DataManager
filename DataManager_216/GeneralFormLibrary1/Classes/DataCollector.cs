﻿using GeneralFormLibrary1.DataModels;
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

        public async void GetDataFromActiveJobs(Frequency frequency)
        {
            DateTime dateTime = DateTime.Today;

            DataAccess<DataModels.Model_DataImportJob> dataAccess = new DataAccess<DataModels.Model_DataImportJob>(DBcredentials);
            List<DataModels.Model_DataImportJob> ImportJobs = await dataAccess.GetAll();

            DataAccess<DataModels.Model_DataSource> dataAccess2 = new DataAccess<DataModels.Model_DataSource>(DBcredentials);
            List<DataModels.Model_DataSource> dataSources = await dataAccess2.GetAll();

            DataAccess<DataModels.Model_SecurityPriceType> dataAccess3 = new DataAccess<DataModels.Model_SecurityPriceType>(DBcredentials);
            List<DataModels.Model_SecurityPriceType> secPriceTypes = await dataAccess3.GetAll();

            foreach (DataModels.Model_DataImportJob job in ImportJobs)
            {
                if(job.ActiveState == 1)
                {
                    int DataJobImportJobTypeId = job.DataImportJobTypeId;
                    int SecurityId = job.SecurityId;
                    DataAccess<DataModels.Model_DataImportJobType> da = new DataAccess<DataModels.Model_DataImportJobType>(DBcredentials);
                    DataModels.Model_DataImportJobType jobType = await da.Get(DataJobImportJobTypeId);

                    DataAccess<DataModels.Model_Security> da2 = new DataAccess<DataModels.Model_Security>(DBcredentials);
                    DataModels.Model_Security Sec = await da2.Get(SecurityId);
                    string APIQuery = jobType.Query.Replace("(***TICKER***)", Sec.Ticker).Replace("(***KEY***)",dataSources.Where(x => x.Id == jobType.DataSourceId).FirstOrDefault().Key);

                    //Alpha Vantage
                    if (jobType.DataSourceId == 1)
                    {
                        UploadAlphaVantageDailyData(dateTime, SecurityId, jobType, APIQuery);
                    }
                }
            }
        }

        private async void UploadAlphaVantageDailyData(DateTime dateTime, int SecurityId, Model_DataImportJobType jobType, string APIQuerydemo)
        {
            AlphaVantageAPI api = new AlphaVantageAPI();
            Dictionary<string, Dictionary<string, string>> timeSeriesData = api.GetTimeSeries(APIQuerydemo, "Time Series (Digital Currency Daily)");

            //Build list to upload
            List<DataModels.Model_SecurityPrice> securityPrices = new List<DataModels.Model_SecurityPrice>();
            List<DataModels.Model_SecurityVolume> securityVolumes = new List<DataModels.Model_SecurityVolume>();

            foreach (KeyValuePair<string, Dictionary<string, string>> priceObj in timeSeriesData)
            {
                //Ignore today's prices
                if (DateTime.Parse(priceObj.Key).ToString("d") != dateTime.ToString("d"))
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
                            DataModels.Model_SecurityVolume volume = new DataModels.Model_SecurityVolume();
                            volume.Date = DateTime.Parse(priceObj.Key);
                            volume.DataSourceId = jobType.DataSourceId;
                            volume.SecurityId = SecurityId;
                            volume.Value = Decimal.Parse(price.Value);
                            securityVolumes.Add(volume);
                        }
                        else
                        {

                            DataModels.Model_SecurityPrice secPrice = new DataModels.Model_SecurityPrice();
                            if (closeFound == false && price.Key.ToLower().Contains("close (usd)") )
                            {
                                closeFound = true;
                                secPrice.SecurityPriceTypeId = 1;
                            }
                            else if (openFound == false && price.Key.ToLower().Contains("open (usd)"))
                            {
                                openFound = true;
                                secPrice.SecurityPriceTypeId = 2;
                            }
                            else if (highFound == false && price.Key.ToLower().Contains("high (usd)"))
                            {
                                highFound = true;
                                secPrice.SecurityPriceTypeId = 3;
                            }
                            else if (lowFound == false && price.Key.ToLower().Contains("low (usd)"))
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

            List<DataModels.Model_SecurityPrice> finalSecPricesForInsert = SecurityPriceListToFinalListForInsert(securityPrices);
            List<DataModels.Model_SecurityPrice> finalSecPricesForUpdate = SecurityListToSecurityListForUpdate(securityPrices);
            List<DataModels.Model_SecurityVolume> finalSecVolumesForInsert = SecurityVolumeListToFinalListForInsert(securityVolumes);
            MessageBox.Show("Price that need to be updated: " + finalSecPricesForUpdate.Count.ToString() + " prices");

            //Insert data
            if (finalSecPricesForInsert.Count > 0)
            {
                MessageBox.Show("About to insert " + finalSecPricesForInsert.Count.ToString() +  " prices");
                DataAccess<DataModels.Model_SecurityPrice> daSecPrice = new DataAccess<DataModels.Model_SecurityPrice>(DBcredentials);
                int recordsInserted = await daSecPrice.Insert(finalSecPricesForInsert);
                MessageBox.Show(recordsInserted.ToString() + " price records inserted");
            }

            //Insert data
            if (finalSecVolumesForInsert.Count > 0)
            {
                MessageBox.Show("About to insert " +  finalSecVolumesForInsert.Count.ToString() + " volume");
                DataAccess<DataModels.Model_SecurityVolume> daSecVolume = new DataAccess<DataModels.Model_SecurityVolume>(DBcredentials);
                int recordsInserted = await daSecVolume.Insert(finalSecVolumesForInsert);
                MessageBox.Show(recordsInserted.ToString() + " volume records inserted");
            }
        }

        public List<DataModels.Model_SecurityPrice> SecurityPriceListToFinalListForInsert(List<DataModels.Model_SecurityPrice> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).First().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).Last().Date;
            List<int> SecurityPriceTypeIds = list.Select(x => x.SecurityPriceTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityPrice Where SecurityId in (" + string.Join(",", SecurityIds)+ ") And Date >= '" + startDate + "' And Date <= '" + endDate + "' And SecurityPriceTypeId in (" + string.Join(",", SecurityPriceTypeIds) + ");";

            //Get data to compare from DB
            List<DataModels.Model_SecurityPrice> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityPrice>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityPrice> finalList = new List<Model_SecurityPrice>();
            foreach (DataModels.Model_SecurityPrice price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.SecurityPriceTypeId == price.SecurityPriceTypeId) && (x.Date == price.Date));
                if (DBListIndex > 0)
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

        public List<DataModels.Model_SecurityVolume> SecurityVolumeListToFinalListForInsert(List<DataModels.Model_SecurityVolume> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).First().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).Last().Date;
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityVolume Where SecurityId in (" + string.Join(",", SecurityIds) + ") And Date >= '" + startDate + "' And Date <= '" + endDate + "';";

            //Get data to compare from DB
            List<DataModels.Model_SecurityVolume> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityVolume>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityVolume> finalList = new List<Model_SecurityVolume>();
            foreach (DataModels.Model_SecurityVolume price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.Date == price.Date));
                if (DBListIndex > 0)
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

        public List<DataModels.Model_SecurityPrice> SecurityListToSecurityListForUpdate(List<DataModels.Model_SecurityPrice> list)
        {
            //Get query parameters
            DateTime startDate = (DateTime)list.OrderByDescending(x => x.Date).First().Date;
            DateTime endDate = (DateTime)list.OrderByDescending(x => x.Date).Last().Date;
            List<int> SecurityPriceTypeIds = list.Select(x => x.SecurityPriceTypeId).Distinct<int>().ToList();
            List<int> SecurityIds = list.Select(x => x.SecurityId).Distinct<int>().ToList();

            //Build query
            string query = "Select * From SecurityPrice Where SecurityId in (" + string.Join(",", SecurityIds) + ") And Date >= '" + startDate + "' And Date <= '" + endDate + "' And SecurityPriceTypeId in (" + string.Join(",", SecurityPriceTypeIds) + ");";

            //Get data to compare from DB
            List<DataModels.Model_SecurityPrice> DBList = DatabaseAPI.GetData_List<DataModels.Model_SecurityPrice>(DatabaseAPI.ConnectionString("QuantDB", DBcredentials), query);

            //Get final list of values from API not in the database
            List<DataModels.Model_SecurityPrice> finalList = new List<Model_SecurityPrice>();
            foreach (DataModels.Model_SecurityPrice price in list)
            {
                //If match found in DB
                int DBListIndex = DBList.FindIndex(x => (x.SecurityId == price.SecurityId) && (x.SecurityPriceTypeId == price.SecurityPriceTypeId) && (x.Date == price.Date));
                if (DBListIndex > 0)
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
