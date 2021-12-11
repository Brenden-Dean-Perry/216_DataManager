using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("Currency")]
	public class Model_Currency
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Symbol { get; set; }
		public string Notes { get; set; }
		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime ChangeDate { get; set; }

		public Model_Currency()
		{
		}

	}
}
