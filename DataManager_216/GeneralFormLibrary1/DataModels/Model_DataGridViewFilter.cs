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
        public int ColumnIndexToFilter { get; set; }
        public string FilterValue { get; set; }
        public ComparisonOperator Operator { get; set; }
        public TypeCode FilterValueDataType {get; set;}

        public Model_DataGridViewFilter(DataGridView dataGridView, int columnIndexToFiler, ComparisonOperator comparisonOperator, string filterValue, TypeCode filterValueDataType)
        {
            DataGridViewObj = dataGridView;
            ColumnIndexToFilter = columnIndexToFiler;
            Operator = comparisonOperator;
            FilterValue = filterValue;
            FilterValueDataType = filterValueDataType;
        }
    }
}
