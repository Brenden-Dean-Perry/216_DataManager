using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
    [Table("Country")]
    public class Model_Country
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Alpha2Code { get; set; }
		public string Alpha3Code { get; set; }
		public int NumericCode { get; set; }
		public decimal AverageLatitude { get; set; }
		public decimal AverageLongitude { get; set; }
		public string Notes { get; set; }

		public Model_Country()
		{
		}
	}
}
