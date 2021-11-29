using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Threading;
using System.Threading;

namespace GeneralFormLibrary1
{
    public class FormControls
    {
        
        private delegate void InvokeDelegate();

        /// <summary>
        /// Clears your Tool Strip and adds a new message item with text = to the value provided.
        /// </summary>
        /// <param name="toolStrip">Your Form's existing Tool Strip</param>
        /// <param name="value">Message you want to show</param>
        /// <returns></returns>
        public ToolStripItem UpdateToolStripItemLabel(ToolStrip toolStrip, string value)
        {
            ToolStripItem statusLabel;

            //Clear old items
            toolStrip.Items.Clear();
            statusLabel = toolStrip.Items.Add(value);
            statusLabel.BackColor = Color.Transparent;
            statusLabel.ForeColor = Color.Black;

            return statusLabel;
        }

        public ToolStripItem UpdateToolStripItemLabel_Async(ToolStrip toolStrip, string value)
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

        public static void AssignListToDataGridView<T>(DataGridView dataGridView, List<T> list)
        {
            dataGridView.DataSource = list;
        }
    }
}
