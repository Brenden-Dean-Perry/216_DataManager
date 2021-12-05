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
    public partial class frmAPIViewer : Form
    {
        private List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter> gridViewFilters = new List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter>();

        public frmAPIViewer()
        {
            InitializeComponent();
        }

        private void APIViewer_Load(object sender, EventArgs e)
        {
            SortableBindingList<GeneralFormLibrary1.DataModels.Model_DataSource> dataSources = new SortableBindingList<GeneralFormLibrary1.DataModels.Model_DataSource>(DataAccess.GetDataList_Quant_DataSources(GlobalAppProperties.GetCredentials()).ToList());
            GeneralFormLibrary1.FormControls.AssignListToDataGridView<GeneralFormLibrary1.DataModels.Model_DataSource>(dataGridView_APIViewer,dataSources);
            dataGridView_APIViewer.MouseClick += dataGridView_APIViewer_MouseClick;
        }

        private void dataGridView_APIViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                RightClickDropDownMenu dropDownMenu = new RightClickDropDownMenu(contextMenu, dataGridView_APIViewer, gridViewFilters);
                dropDownMenu.Show(RightClickDropDownMenu.MenuOption.DefaultMenu_URL, e);
            }
        }

        private void btn_APIViewer_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.DataGridViewToList<GeneralFormLibrary1.DataModels.Model_DataSource>(dataGridView_APIViewer, true);
        }
    }
}
