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
    public class FormControls
    {
        
        private delegate void InvokeDelegate();

        public enum ComparisonOperator
        {
            Equals,
            DoNotEqual,
            LessThan,
            GreaterThan,
            LessThanOrEqualTo,
            GreaterThanOrEqualTo
        }

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

        public static void FilterDataGridView(DataGridView dataGridView, int ColumnIndex, ComparisonOperator comparisonOperator, string FilterValue)
        {
            // Prevent exception when hiding rows out of view
            CurrencyManager currencyManager = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
            currencyManager.SuspendBinding();
            TypeCode FilterValueDataTypeCode = Type.GetTypeCode(dataGridView.Rows[1].Cells[ColumnIndex].Value.GetType());

            // Show all lines
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Visible = true;
                i++;
            }

            // Hide the ones that you want with the filter you want.
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (comparisonOperator == ComparisonOperator.Equals && dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString().IndexOf(FilterValue) >= 0)
                {
                    dataGridView.Rows[i].Visible = true;
                }
                else if(comparisonOperator == ComparisonOperator.DoNotEqual && (dataGridView.Rows[i].Cells[ColumnIndex].Value == null || dataGridView.Rows[i].Cells[ColumnIndex].Value.ToString().IndexOf(FilterValue) < 0))
                {
                    dataGridView.Rows[i].Visible = true;
                }
                //If Numeric 
                else if (TypeCodeIsNumeric(FilterValueDataTypeCode) == true)
                {
                    //Allow for >, >=, <, & <= operators here
                    throw new Exception("Not implemented");
                }
                else
                {
                    dataGridView.Rows[i].Visible = false;
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
                dataGridView.Rows[i].Visible = true;
                i++;
            }

        }



    }
}
