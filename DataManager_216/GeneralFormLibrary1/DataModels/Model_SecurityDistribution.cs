﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
	[Table("SecurityDistribution")]
	public class Model_SecurityDistribution
	{
		[Key]
		public long Id { get; set; }
		public int SecurityId { get; set; }
		public int DistributionTypeId { get; set; }
		public DateTime? Date { get; set; }
		public decimal Value { get; set; }
		public int DataSourceId { get; set; }
		[Write(false)]
		public string CreateUser { get; set; }
		[Write(false)]
		public DateTime? CreateDate { get; set; }
		[Write(false)]
		public string ChangeUser { get; set; }
		[Write(false)]
		public DateTime? ChangeDate { get; set; }

		public Model_SecurityDistribution()
		{
		}

	}
}
