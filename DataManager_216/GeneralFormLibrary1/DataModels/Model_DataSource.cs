using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1.DataModels
{
    public class Model_DataSource
    {
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
		public string CreateUser { get; set; }
		public DateTime CreateDate { get; set; }
		public string ChangeUser { get; set; }
		public DateTime ChangeDate { get; set; }

		public Model_DataSource()
		{
		}
	}
}
