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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = GlobalAppProperties.AppName;
        }

        private void dataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataViewer dataViewer = new frmDataViewer();
            dataViewer.Show();
        }
    }
}
