using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;
using System.Data;

namespace GeneralFormLibrary1
{
    public partial class FormControls
    {

        private delegate void InvokeDelegate();

        /// <summary>
        /// Clears your Tool Strip and adds a new message item with text = to the value provided.
        /// </summary>
        /// <param name="toolStrip">Your Form's existing Tool Strip</param>
        /// <param name="value">Message you want to show</param>
        /// <returns></returns>
        public static ToolStripItem UpdateToolStripItemLabel(ToolStrip toolStrip, string value)
        {
            ToolStripItem statusLabel;

            //Clear old items
            toolStrip.Items.Clear();
            statusLabel = toolStrip.Items.Add(value);
            statusLabel.BackColor = Color.Transparent;
            statusLabel.ForeColor = Color.Black;

            return statusLabel;
        }

        public static ToolStripItem UpdateToolStripItemLabel_Async(ToolStrip toolStrip, string value)
        {
            //Initialize a default toolstrip & item in case the Begin Invoke doesn't properly assign one
            ToolStrip ts = new ToolStrip();
            ToolStripItem statusLabel = ts.Items.Add("");

            //Use Begin invoke so that we are async safe
            toolStrip.BeginInvoke(new InvokeDelegate(() =>
            {
                //Clear old items
                toolStrip.Items.Clear();
                statusLabel = toolStrip.Items.Add(value);
                statusLabel.BackColor = Color.Transparent;
                statusLabel.ForeColor = Color.Black;
            }));

            return statusLabel;
        }

        public static void AssignListToComboBox<T>(ComboBox comboBox, List<T> list, string displayMember, string valueMember = null)
        {
            comboBox.DataSource = list;
            comboBox.DisplayMember = displayMember;

            if (valueMember != null)
            {
                comboBox.ValueMember = valueMember;
            }

        }

        public static void AssignListToDataGridView<T>(DataGridView dataGridView, IList<T> list, bool SetToReadOnly = true)
        {
            dataGridView.DataSource = list;

            FormatDataGridView(dataGridView, SetToReadOnly);
        }

        public static void AssignDataTableToDataGridView(DataGridView dataGridView, DataTable dataTable, bool SetToReadOnly = true)
        {
            dataGridView.DataSource = dataTable;

            FormatDataGridView(dataGridView, SetToReadOnly);
        }


        private static void FormatDataGridView(DataGridView dataGridView, bool SetToReadOnly = true)
        {
            //Format and settings
            dataGridView.RowHeadersWidth = 25;
            SetDoubleBuffered(dataGridView);
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.EnableHeadersVisualStyles = true;


            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.ReadOnly = SetToReadOnly;
            }

        }

        private static void FormatDataGridView_DesignateFilteredColumns(DataGridView dataGridView, List<DataModels.Model_DataGridViewFilter> dataGridViewFilters)
        {
            string FilterDesignation = " (F)";
            //Remove filter designations
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.HeaderText.EndsWith(FilterDesignation))
                {
                    column.HeaderText = column.HeaderText.Substring(0, column.HeaderText.Length - FilterDesignation.Length);
                }
            }

            //Add filter designations
            foreach (DataModels.Model_DataGridViewFilter filterModel in dataGridViewFilters)
            {
                if (filterModel.DataGridViewObj == dataGridView)
                {
                    DataGridViewColumn column = dataGridView.Columns[filterModel.ColumnIndexToFilter];
                    column.HeaderText = column.HeaderText + FilterDesignation;
                    column.HeaderCell.Style.ForeColor = Color.Red;
                    column.HeaderCell.Style.BackColor = Color.Red;
                }
            }
        }

        private static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        public static void FilterDataGridView(DataGridView dataGridView, List<DataModels.Model_DataGridViewFilter> filters)
        {
            // Prevent exception when hiding rows out of view
            CurrencyManager currencyManager = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
            currencyManager.SuspendBinding();

            // Hide the ones that you want with the filter you want.
            foreach (DataModels.Model_DataGridViewFilter filter in filters)
            {
                TypeCode FilterValueDataTypeCode = Type.GetTypeCode(dataGridView.Rows[1].Cells[filter.ColumnIndexToFilter].Value.GetType());

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (dataGridView.Rows[i].Visible == false)
                    {
                        //Do nothing as we want to keep their visability set to false
                    }
                    else
                    {
                        if (filter.Operator == ComparisonOperator.Operator.Equals && dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString().IndexOf(filter.FilterValue.ToString()) >= 0)
                        {
                            //Do nothing keep this visable
                        }
                        else if (filter.Operator == ComparisonOperator.Operator.DoNotEqual && (dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value == null || dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString().IndexOf(filter.FilterValue.ToString()) < 0))
                        {
                            //Do nothing keep this visable
                        }
                        else if (filter.Operator == ComparisonOperator.Operator.Contains && (dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString().ToLower().Contains(filter.FilterValue.ToString().ToLower())))
                        {
                            //Do nothing keep this visable
                        }
                        //If Numeric 
                        else if (DataTypes.TypeCodeIsNumeric(FilterValueDataTypeCode) == true)
                        {
                            //If type code of cell value is double then try parse values as double
                            if (Type.GetTypeCode(dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.GetType()) == TypeCode.Double && Double.TryParse(filter.FilterValue.ToString(), out double FilterValue_Double) == true && Double.TryParse(dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString(), out double CellValue_Double) == true)
                            {
                                //Allow for >, >=, <, & <= operators here
                                if (filter.Operator == ComparisonOperator.Operator.GreaterThan && CellValue_Double > FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.Operator.GreaterThanOrEqualTo && CellValue_Double >= FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.Operator.LessThan && CellValue_Double < FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.Operator.LessThanOrEqualTo && CellValue_Double <= FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else
                                {
                                    dataGridView.Rows[i].Visible = false;
                                }
                            }
                            else if (Decimal.TryParse(filter.FilterValue.ToString(), out decimal FilterValue_Decimal) == true && Decimal.TryParse(dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString(), out decimal CellValue_Decimal) == true)
                            {
                                //Allow for >, >=, <, & <= operators here
                                if (filter.Operator == ComparisonOperator.Operator.GreaterThan && CellValue_Decimal > FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.Operator.GreaterThanOrEqualTo && CellValue_Decimal >= FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.Operator.LessThan && CellValue_Decimal < FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.Operator.LessThanOrEqualTo && CellValue_Decimal <= FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else
                                {
                                    dataGridView.Rows[i].Visible = false;
                                }
                            }
                        }
                        else
                        {
                            dataGridView.Rows[i].Visible = false;
                        }
                    }
                }
            }

            FormatDataGridView_DesignateFilteredColumns(dataGridView, filters);

            // Resume data grid view binding
            currencyManager.ResumeBinding();
        }


        public static void UnfilterDataGridView(DataGridView dataGridView)
        {
            // Show all lines
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Visible = true;
            }
 
        }

    }
}
