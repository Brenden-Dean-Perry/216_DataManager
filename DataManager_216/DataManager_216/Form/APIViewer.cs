using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralFormLibrary1.DataModels;
using GeneralFormLibrary1;

namespace DataManager_216
{
    public partial class frmAPIViewer : Form
    {
        private List<Model_DataGridViewFilter> gridViewFilters = new List<Model_DataGridViewFilter>();

        public frmAPIViewer()
        {
            InitializeComponent();
        }

        private async void APIViewer_Load(object sender, EventArgs e)
        {
            GeneralFormLibrary1.DataAccess<Model_DataSource> ds = new DataAccess<Model_DataSource>(GlobalAppProperties.GetCredentials());
            SortableBindingList<Model_DataSource> dataSources =  new SortableBindingList<Model_DataSource>(await ds.GetAll());
            GeneralFormLibrary1.FormControls.AssignListToDataGridView<Model_DataSource>(dataGridView_APIViewer,dataSources);
            dataGridView_APIViewer.MouseClick += dataGridView_APIViewer_MouseClick;
        }

        private void dataGridView_APIViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                RightClickDropDownMenu<Model_DataSource> dropDownMenu = new RightClickDropDownMenu<Model_DataSource>(contextMenu, dataGridView_APIViewer, gridViewFilters, GlobalAppProperties.AppName, "APIViewer", GlobalAppProperties.GetCredentials());
                dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL, e);
            }
        }

        private void dataGridView_APIViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
