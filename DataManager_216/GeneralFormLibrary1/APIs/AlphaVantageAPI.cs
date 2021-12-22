using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using System.IO;


namespace GeneralFormLibrary1
{
    public class AlphaVantageAPI
    {
        public AlphaVantageAPI()
        {

        }

        public Dictionary<string, string> GetMetaData(string APIQueryURL)
        {

            WebRequest webRequest = System.Net.WebRequest.Create(APIQueryURL);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";

            //Get the response
            System.Net.WebResponse webResponse = webRequest.GetResponseAsync().Result;
            System.IO.Stream recieverStream = webResponse.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(recieverStream);
            string response = reader.ReadToEnd();

            Dictionary<string, string> metaDataDict = new Dictionary<string, string>();
            if (response.ToLower().Contains("error message") || response.ToLower().Contains("thank you for using alpha vantage!"))
            {
                return metaDataDict;
            }

            Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.Linq.JObject.Parse(response);

            //Store meta data
            Newtonsoft.Json.Linq.JObject metaData = Newtonsoft.Json.Linq.JObject.Parse(jobj["Meta Data"].ToString());

            //Build dictionary from meta data
            
            foreach (System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item in metaData)
            {
                metaDataDict.Add(item.Key, item.Value.ToString());
            }

            return metaDataDict;
        }

        public Dictionary<string, Dictionary<string, string>> GetTimeSeries(string APIQueryURL, string APITimeSeriesObjectHeader)
        {
            WebRequest webRequest = System.Net.WebRequest.Create(APIQueryURL);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";

            //Get the response
            System.Net.WebResponse webResponse = webRequest.GetResponseAsync().Result;
            System.IO.Stream recieverStream = webResponse.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(recieverStream);
            string response = reader.ReadToEnd();

            //Build dictionary of time series data
            Dictionary<string, Dictionary<string, string>> timeSeriesDataDict = new Dictionary<string, Dictionary<string, string>>();
            if (response.ToLower().Contains("error message") || response.ToLower().Contains("thank you for using alpha vantage!"))
            {
                return timeSeriesDataDict;
            }

            Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.Linq.JObject.Parse(response);

            //Store time series data
            Newtonsoft.Json.Linq.JObject timeSeriesData = Newtonsoft.Json.Linq.JObject.Parse(jobj[APITimeSeriesObjectHeader].ToString());

            foreach (System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item in timeSeriesData)
            {
                Newtonsoft.Json.Linq.JObject timeSeriesData_Day = Newtonsoft.Json.Linq.JObject.Parse(item.Value.ToString());

                Dictionary<string, string> timeSeriesData_DayDict = new Dictionary<string, string>();
                foreach (System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> item_day in timeSeriesData_Day)
                {
                    timeSeriesData_DayDict.Add(item_day.Key, item_day.Value.ToString());
                }
                timeSeriesDataDict.Add(item.Key, timeSeriesData_DayDict);
            }

            return timeSeriesDataDict;
        }


        public Dictionary<string, Dictionary<string, string>> GetTimeSeriesFromCSV(string APIQueryURL_CSV)
        {
            Dictionary<string, Dictionary<string, string>> timeSeriesDataDict = new Dictionary<string, Dictionary<string, string>>();
            Uri queryUri = new Uri(APIQueryURL_CSV);
            MessageBox.Show("start");
            // print the output
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US"); ;
            using (WebClient client = new WebClient())
            {
                using (MemoryStream stream = new MemoryStream(client.DownloadDataTaskAsync(queryUri).Result))
                {
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            MessageBox.Show("about to read");
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                foreach (string item in csv.Parser.Record)
                                {
                                    MessageBox.Show(item);
                                    //Dictionary<string, string> timeSeries = new Dictionary<string, string>();
                                    foreach (string header in csv.HeaderRecord)
                                    {
                                        MessageBox.Show(header);
                                        //if(header.ToLower() != "time" || header.ToLower() != "date")
                                        {
                                           // timeSeries.Add(header, item);
                                        }  
                                    }

                                    //timeSeriesDataDict.Add(item, timeSeries);
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("end");
            return timeSeriesDataDict;
        }
    }
}
