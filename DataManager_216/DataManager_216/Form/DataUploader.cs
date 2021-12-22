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
    public partial class frmDataUploader : Form
    {
        public frmDataUploader()
        {
            InitializeComponent();
        }

        private void btn_DataUploader_Search_Click(object sender, EventArgs e)
        {
            tb_DataUploader_CSVPath.Text = FormControls.GetPathFromFileDirectory();
        }

        private void frmDataUploader_Load(object sender, EventArgs e)
        {
            string[] items = { "SecurityPrice", "SecurityPriceIntraday" };
            comboBox_DataUploader_Table.Items.AddRange(items);
        }
    }
}
