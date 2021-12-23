using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1.DataModels.Query_DataModels
{
    public class Model_SecurityPriceAndVolumeReport
    {
        public string Entity { get; set; }
        public string UnderlyingAsset { get; set; }
        public string Contract { get; set; }
        public int SecurityId { get; set; }
        public string Ticker { get; set; }
        public string AssetType { get; set; }
        public DateTime? MinDate_Price { get; set; }

        public DateTime? MaxDate_Price { get; set; }

        public DateTime? MinDate_Price_Intraday { get; set; }

        public DateTime? MaxDate_Price_Intraday { get; set; }

        public DateTime? MinDate_Volume{ get; set; }

        public DateTime? MaxDate_Volume { get; set; }

        public DateTime? MinDate_Volume_Intraday { get; set; }

        public DateTime? MaxDate_Volume_Intraday { get; set; }

        public Model_SecurityPriceAndVolumeReport()
        {

        }
    }
}
