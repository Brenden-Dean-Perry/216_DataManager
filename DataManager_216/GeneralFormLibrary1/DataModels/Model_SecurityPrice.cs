using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("SecurityPrice")]
	public class Model_SecurityPrice
	{
		[Key]
		public int Id { get; set; }
		public int SecurityId { get; set; }
		public int SecurityPriceTypeId { get; set; }
		public DateTime DateTime { get; set; }
		public decimal Value { get; set; }
		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime ChangeDate { get; set; }

		public Model_SecurityPrice()
		{
		}

	}
}
