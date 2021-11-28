using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GeneralFormLibrary1
{
    public static class FormControls
    {
        public static ToolStripItem UpdateToolStripItemLabel(ToolStrip statusStrip, string value, ToolStripItem existingLabel = null)
        {
            //Clear old items
            statusStrip.Items.Clear();

            ToolStripItem statusLabel;
            statusLabel = statusStrip.Items.Add(value);
            statusLabel.BackColor = Color.Transparent;
            statusLabel.ForeColor = Color.Black;

            return statusLabel;
        }
    }
}
