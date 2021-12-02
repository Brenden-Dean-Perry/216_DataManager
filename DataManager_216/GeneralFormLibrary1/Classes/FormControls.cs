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

            if(valueMember != null)
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

            
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.ReadOnly = SetToReadOnly;
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

        public static void FilterDataGridView<T>(DataGridView dataGridView, int ColumnIndex, ComparisonOperator.Operator comparisonOperator, T FilterValue)
        {
            // Prevent exception when hiding rows out of view
            CurrencyManager currencyManager = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
            currencyManager.SuspendBinding();
            TypeCode FilterValueDataTypeCode = Type.GetTypeCode(dataGridView.Rows[1].Cells[ColumnIndex].Value.GetType());

            // Hide the ones that you want with the filter you want.
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if(dataGridView.Rows[i].Visible == false)
                {
                    //Do nothing as we want to keep their visability set to false
                }
                else
                {
                    if (comparisonOperator == ComparisonOperator.Operator.Equals && dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString().IndexOf(FilterValue.ToString()) >= 0)
                    {
                        //Do nothing keep this visable
                    }
                    else if (comparisonOperator == ComparisonOperator.Operator.DoNotEqual && (dataGridView.Rows[i].Cells[ColumnIndex].Value == null || dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString().IndexOf(FilterValue.ToString()) < 0))
                    {
                        //Do nothing keep this visable
                    }
                    else if(comparisonOperator == ComparisonOperator.Operator.Contains && (dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString().ToLower().Contains(FilterValue.ToString().ToLower())))
                    {
                        //Do nothing keep this visable
                    }
                    //If Numeric 
                    else if (TypeCodeIsNumeric(FilterValueDataTypeCode) == true)
                    {
                        //If type code of cell value is double then try parse values as double
                        if (Type.GetTypeCode(dataGridView.Rows[i].Cells[ColumnIndex].Value.GetType()) == TypeCode.Double && Double.TryParse(FilterValue.ToString(), out double FilterValue_Double) == true && Double.TryParse(dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString(), out double CellValue_Double) == true)
                        {
                            //Allow for >, >=, <, & <= operators here
                            if (comparisonOperator == ComparisonOperator.Operator.GreaterThan && CellValue_Double > FilterValue_Double)
                            {
                                //Do nothing keep this visable
                            }
                            else if (comparisonOperator == ComparisonOperator.Operator.GreaterThanOrEqualTo && CellValue_Double >= FilterValue_Double)
                            {
                                //Do nothing keep this visable
                            }
                            else if (comparisonOperator == ComparisonOperator.Operator.LessThan && CellValue_Double < FilterValue_Double)
                            {
                                //Do nothing keep this visable
                            }
                            else if (comparisonOperator == ComparisonOperator.Operator.LessThanOrEqualTo && CellValue_Double <= FilterValue_Double)
                            {
                                //Do nothing keep this visable
                            }
                            else
                            {
                                dataGridView.Rows[i].Visible = false;
                            }
                        }
                        else if (Decimal.TryParse(FilterValue.ToString(), out decimal FilterValue_Decimal) == true && Decimal.TryParse(dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString(), out decimal CellValue_Decimal) == true)
                        {
                            //Allow for >, >=, <, & <= operators here
                            if (comparisonOperator == ComparisonOperator.Operator.GreaterThan && CellValue_Decimal > FilterValue_Decimal)
                            {
                                //Do nothing keep this visable
                            }
                            else if (comparisonOperator == ComparisonOperator.Operator.GreaterThanOrEqualTo && CellValue_Decimal >= FilterValue_Decimal)
                            {
                                //Do nothing keep this visable
                            }
                            else if(comparisonOperator == ComparisonOperator.Operator.LessThan && CellValue_Decimal< FilterValue_Decimal)
                            {
                                //Do nothing keep this visable
                            }
                            else if (comparisonOperator == ComparisonOperator.Operator.LessThanOrEqualTo && CellValue_Decimal <= FilterValue_Decimal)
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

            // Resume data grid view binding
            currencyManager.ResumeBinding();
        }


        private static bool TypeCodeIsNumeric(TypeCode type)
        {
            if (type == TypeCode.Byte || type == TypeCode.DateTime || type == TypeCode.Decimal || type == TypeCode.Double ||
                type == TypeCode.Int16 || type == TypeCode.Int32 || type == TypeCode.Int64 || type == TypeCode.SByte ||
                type == TypeCode.Single || type == TypeCode.UInt16 || type == TypeCode.UInt32 || type == TypeCode.UInt64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void UnfilterDataGridView(DataGridView dataGridView)
        {

            // Show all lines
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                MessageBox.Show(i.ToString());
                dataGridView.Rows[i].Visible = true;
            }

        }



    }
}
