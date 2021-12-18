using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("DataImportJobType")]
	public class Model_DataImportJobType
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int DataSourceId { get; set; }
		public string Query { get; set; }
		public string DemoQuery { get; set; }
		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime? CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime? ChangeDate { get; set; }

		public Model_DataImportJobType()
		{
		}


	}
}
