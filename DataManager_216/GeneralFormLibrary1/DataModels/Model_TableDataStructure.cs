using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1.DataModels
{
    public class Model_TableDataStructure
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set;}

        public Model_TableDataStructure()
        {

        }
    }
}
