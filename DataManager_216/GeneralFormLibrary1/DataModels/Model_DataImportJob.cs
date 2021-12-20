using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("DataImportJob")]
	public class Model_DataImportJob
	{
		[Key]
		public int Id { get; set; }
		public int SecurityId { get; set; }
		public byte ActiveState { get; set; }
		public int DataImportJobTypeId { get; set; }
		public int DataImportOccuranceTypeId { get; set; }
		public DateTime? LastRunDateTime { get; set; }
		public int PriceUpdatesNeeded { get; set; }

		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime? CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime? ChangeDate { get; set; }

		public Model_DataImportJob()
		{
		}

	}
}
