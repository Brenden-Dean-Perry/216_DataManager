using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralFormLibrary1.DataModels
{
    public class Model_DataGridViewFilter
    {
        public DataGridView DataGridViewObj { get; set; }
        public int ColumnNumber { get; set; }
        public string FilterValue { get; set; }
        public ComparisonOperator.Operator ComparsionOperator { get; set; }

        public Model_DataGridViewFilter()
        {

        }
    }
}
