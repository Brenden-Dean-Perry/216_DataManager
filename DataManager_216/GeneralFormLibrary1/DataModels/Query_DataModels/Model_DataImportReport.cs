using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1.DataModels.Query_DataModels
{
	public class Model_DataImportReport
	{
		public string Entity {get; set;}
		public string UnderlyingAsset {get; set;}
		public string Contract { get; set; }
		public int SecurityId { get; set; }
		public string Ticker { get; set; }
		public bool ActiveState { get; set; }
		public string AssetType { get; set; }
		public string DataImportJobType { get; set; }
		public string DataSource { get; set; }
		public string DataImportOccuranceType { get; set; }
		public DateTime? LastRunDateTime { get; set; }
		public int PriceUpdatesNeeded { get; set; }
		public string Status { get; set; }

        public Model_DataImportReport()
        {

        }
	}
}
