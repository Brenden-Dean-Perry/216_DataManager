using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1.DataModels.Query_DataModels
{
    public class Model_PriceSnapshot
    {
		public string Contract { get; set; }
		public string Ticker { get; set; }
		public DateTime Date { get; set; }
		public Decimal Close { get; set; }
		public Decimal Low { get; set; }
		public Decimal High { get; set; }
		public Decimal PriorClose { get; set; }

	}
}
