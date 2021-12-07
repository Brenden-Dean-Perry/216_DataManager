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
        private static string FilterDesignation { get; } = " (F)";
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
            if(displayMember == null)
            {
                foreach (T item in list)
                {
                    comboBox.Items.Add(item.ToString());
                }
            }
            else
            {
                comboBox.DataSource = list;
                comboBox.DisplayMember = displayMember;

                if (valueMember != null)
                {
                    comboBox.ValueMember = valueMember;
                }
            }
        }

        public static string GetPathFromFileDirectory()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if(System.IO.File.Exists(fileDialog.FileName))
                {
                    return fileDialog.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
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
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.ReadOnly = SetToReadOnly;
            }

        }

        private static void FormatDataGridView_DesignateFilteredColumns(DataGridView dataGridView, List<DataModels.Model_DataGridViewFilter> dataGridViewFilters)
        {
            
            //Remove filter designations
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.HeaderText.EndsWith(FilterDesignation))
                {
                    column.HeaderText = column.HeaderText.Substring(0, column.HeaderText.Length - FilterDesignation.Length);
                }
                
                if(column.HeaderCell.Style.ForeColor == Color.Red)
                {
                    column.HeaderCell.Style.ForeColor = Color.Black;
                }
            }

            //Add filter designations
            List<DataModels.Model_DataGridViewFilter> filtersForThisDGV = dataGridViewFilters.Where(person => person.DataGridViewObj == dataGridView).ToList();
            List<int> columnIndexes = filtersForThisDGV.Select(x => x.ColumnIndexToFilter).Distinct().ToList();
            foreach (int columnIndex in columnIndexes)
            {
                DataGridViewColumn column = dataGridView.Columns[columnIndex];
                column.HeaderText = column.HeaderText + FilterDesignation;
                column.HeaderCell.Style.ForeColor = Color.Red;
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
                TypeCode FilterValueDataTypeCode = Type.GetTypeCode(dataGridView.Rows[0].Cells[filter.ColumnIndexToFilter].Value.GetType());

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (dataGridView.Rows[i].Visible == false)
                    {
                        //Do nothing as we want to keep their visability set to false
                    }
                    else
                    {
                        if (filter.Operator == ComparisonOperator.Equals && dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString().IndexOf(filter.FilterValue.ToString()) >= 0)
                        {
                            //Do nothing keep this visable
                        }
                        else if (filter.Operator == ComparisonOperator.DoNotEqual && (dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value == null || dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString().IndexOf(filter.FilterValue.ToString()) < 0))
                        {
                            //Do nothing keep this visable
                        }
                        else if (filter.Operator == ComparisonOperator.Contains && (dataGridView.Rows[i].Cells[filter.ColumnIndexToFilter].Value.ToString().ToLower().Contains(filter.FilterValue.ToString().ToLower())))
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
                                if (filter.Operator == ComparisonOperator.GreaterThan && CellValue_Double > FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.GreaterThanOrEqualTo && CellValue_Double >= FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.LessThan && CellValue_Double < FilterValue_Double)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.LessThanOrEqualTo && CellValue_Double <= FilterValue_Double)
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
                                if (filter.Operator == ComparisonOperator.GreaterThan && CellValue_Decimal > FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.GreaterThanOrEqualTo && CellValue_Decimal >= FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.LessThan && CellValue_Decimal < FilterValue_Decimal)
                                {
                                    //Do nothing keep this visable
                                }
                                else if (filter.Operator == ComparisonOperator.LessThanOrEqualTo && CellValue_Decimal <= FilterValue_Decimal)
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

        public static void DataGridViewExportToExcel<T>(DataGridView dataGridView, string AppName, string FileName, string saveDirectory, bool ExportFilteredView = true) where T : class, new()
        {
            ExcelAPI excel = new ExcelAPI();
            List<T> list;
            if (ExportFilteredView == true)
            {
                list = DataGridViewToList<T>(dataGridView, true);
            }
            else
            {
                list = DataGridViewToList<T>(dataGridView, false);
            }

            excel.ExportDataToSheet<T>(list, true, AppName, FileName, saveDirectory);
        }
         

        public static List<T> DataGridViewToList<T>(DataGridView dataGridView, bool ExcludeInvisableRows = true) where T: class, new()
        {
            List<T> list = new List<T>();
            T entry = new T();
            var properties = entry.GetType().GetProperties();
            List<string> HeaderNames = new List<string>();
            int propertiesFoundCount = 0;
            foreach(DataGridViewColumn column in dataGridView.Columns)
            {
                HeaderNames.Add(column.HeaderText);
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (ExcludeInvisableRows == true && row.Visible == false)
                {
                    //Do nothing
                }
                else
                {
                    entry = new T();
                    for (int i = 0; i < HeaderNames.Count; i++)
                    {
                        foreach (var prop in properties)
                        {
                            //Property found
                            if (prop.Name == HeaderNames[i] || prop.Name + FilterDesignation == HeaderNames[i])
                            {
                                propertiesFoundCount++;
                                if(row.Cells[i].Value != null)
                                {
                                    try
                                    {
                                        prop.SetValue(entry, Convert.ChangeType(row.Cells[i].Value, prop.PropertyType));
                                    }
                                    catch
                                    {
                                        list.Clear();
                                        MessageBox.Show(null, "Failed to parse values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                       return list;
                                    }
                                }
                                break;
                            }

                        }
                    }
                    list.Add(entry);
                }
            }

            return list;
        }


    }
}
