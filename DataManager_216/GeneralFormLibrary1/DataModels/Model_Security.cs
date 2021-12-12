using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("Security")]
	public class Model_Security
	{
		[Key]
		public int Id { get; set; }
		public string Ticker { get; set; }
		public int ContractId { get; set; }
		public DateTime Expiration { get; set; }
		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime ChangeDate { get; set; }

		public Model_Security()
		{
		}

	}
}
