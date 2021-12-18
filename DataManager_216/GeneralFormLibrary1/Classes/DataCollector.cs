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
                    MessageBox.Show(APIQuery);
                    Clipboard.SetText(APIQuery);
                    string APIQuerydemo = jobType.DemoQuery;
                    MessageBox.Show(APIQuerydemo);

                    //Alpha Vantage
                    if (jobType.DataSourceId == 1)
                    {
                        AlphaVantageAPI api = new AlphaVantageAPI();
                        Dictionary<string, Dictionary<string, string>> data = api.GetTimeSeries(APIQuerydemo, "Time Series (Digital Currency Daily)");

                        //Build list to upload
                        List<DataModels.Model_SecurityPrice> securityPrices = new List<DataModels.Model_SecurityPrice>();
                        List<DataModels.Model_SecurityVolume> securityVolumes = new List<DataModels.Model_SecurityVolume>();

                        foreach (KeyValuePair<string, Dictionary<string, string>> priceObj in data)
                        {
                            foreach (KeyValuePair<string, string> priceDay in priceObj.Value)
                            {
                                DataModels.Model_SecurityPrice price = new DataModels.Model_SecurityPrice();
                                price.Date = DateTime.Parse(priceObj.Key);
                                price.DataSourceId = jobType.DataSourceId;
                                price.SecurityId = SecurityId;

                                if(priceDay.Key.ToLower() == "open")
                                {
                                    price.SecurityPriceTypeId = 1;
                                }
                                
                                price.Value = Decimal.Parse(priceDay.Value);
                                securityPrices.Add(price);
                            }
                        }

                        //Insert data
                        if (securityPrices.Count > 0)
                        {
                            MessageBox.Show("About to insert");
                            //DataAccess<DataModels.Model_SecurityPrice> daSecPrice = new DataAccess<DataModels.Model_SecurityPrice>(DBcredentials);
                            //int recordsInserted = await daSecPrice.Add(securityPrices);
                            //MessageBox.Show(recordsInserted.ToString() + " records inserted");
                        }
                    }
                }
            }
        }
    }
}
