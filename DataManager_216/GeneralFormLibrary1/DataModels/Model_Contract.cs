using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("Contract")]
	public class Model_Contract
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string ContractCode { get; set; }
		public int UnderlyingAssetId { get; set; }
		public decimal LotSize { get; set; }
		public int QuotedCurrencyId { get; set; }
		public int Multiplier { get; set; }
		public decimal PriceMultiplier { get; set; }
		public byte AllowShort { get; set; }
		public byte AllowTrade { get; set; }
		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime ChangeDate { get; set; }

		public Model_Contract()
		{
		}

	}
}
