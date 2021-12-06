using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{

	[Table("DataSource")]
    public class Model_DataSource
    {
		[Key] 
		public int Id { get; set; }
		public string Name { get; set; }
		public string Key { get; set; }
		public string URL { get; set; }
		public int RequestLimitPerMin { get; set; }
		public int RequestLimitPerHour { get; set; }
		public int RequestLimitPerDay { get; set; }
		public int RequestLimitPerWeek { get; set; }
		public int RequestLimitPerMonth { get; set; }
		public decimal CostPerPeriod { get; set; }
		public int PeriodsPerYear { get; set; }
		public decimal CostPerTransaction { get; set; }
		public int CurrencyId { get; set; }
		public string Notes { get; set; }

		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime ChangeDate { get; set; }

		public Model_DataSource()
		{
		}
	}
}
