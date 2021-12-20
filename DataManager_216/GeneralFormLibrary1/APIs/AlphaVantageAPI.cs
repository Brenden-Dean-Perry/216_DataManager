﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

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
            Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.Linq.JObject.Parse(response);

            //Store meta data
            Newtonsoft.Json.Linq.JObject metaData = Newtonsoft.Json.Linq.JObject.Parse(jobj["Meta Data"].ToString());

            //Build dictionary from meta data
            Dictionary<string, string> metaDataDict = new Dictionary<string, string>();
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
            if (response.ToLower().Contains("error message"))
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


    }
}