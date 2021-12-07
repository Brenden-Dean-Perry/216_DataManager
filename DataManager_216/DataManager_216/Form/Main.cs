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
            LaunchBloombergTvStream();
        }

        private void LaunchBloombergTvStream()
        {
            webBrowser_Main_1.Navigate("https://www.youtube.com/watch?v=dp8PhLsUcFE");
        }

        private void dataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataViewer dataViewer = new frmDataViewer();
            dataViewer.Show();
        }

        private void aPIViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAPIViewer aPIViewer = new frmAPIViewer();
            aPIViewer.Show();
        }

        private void modelConstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataModelConstructor modelConstructor = new frmDataModelConstructor();
            modelConstructor.Show();
        }

        private void hasherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHasher hasher = new frmHasher();
            hasher.Show();
        }
    }
}
