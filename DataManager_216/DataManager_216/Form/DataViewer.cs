using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralFormLibrary1;

namespace DataManager_216
{
    public partial class frmDataViewer : Form
    {

        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "Loaded");
        }

        private void btn_DataViewer_Search_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, DateTime.Now.ToString());
        }
    }
}
