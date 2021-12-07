using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using GeneralFormLibrary1;

namespace DataManager_216
{
    public partial class frmDataViewer : Form
    {
        private delegate void InvokeDelegate();
        private List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter> gridViewFilters = new List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter>();

        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {
            GeneralFormLibrary1.DataAccess<GeneralFormLibrary1.DataModels.Model_TableName> dataAccess = new DataAccess<GeneralFormLibrary1.DataModels.Model_TableName>(GlobalAppProperties.GetCredentials());
            List<GeneralFormLibrary1.DataModels.Model_TableName> tables = dataAccess.GetDatabaseTableNames();
            GeneralFormLibrary1.FormControls.AssignListToComboBox<GeneralFormLibrary1.DataModels.Model_TableName>(comboBox_DataViewer_TableSelection, tables, "TableName");
            dataGridView_DataViewer.MouseClick += dataGridView_DataViewer_MouseClick;
        }

        private void dataGridView_DataViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                RightClickDropDownMenu dropDownMenu = new RightClickDropDownMenu(contextMenu, dataGridView_DataViewer, gridViewFilters);
                dropDownMenu.Show(CustomRightClickMenu.DefaultMenu, e);
            }
        }

        private void dataGridView_DataViewer_Sorted(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.FilterDataGridView(dataGridView_DataViewer, gridViewFilters);
        }

        private async void btn_DataViewer_Search_Click(object sender, EventArgs e)
        {
            //Start status animation
            var tokenSource = new CancellationTokenSource();
            StatusAnimation status = new StatusAnimation(this, statusStrip_DataViewer, tokenSource);
            status.Start();

            //Do task
            SortableBindingList<GeneralFormLibrary1.DataModels.Model_Country> model = await Task.Run(() => GetData());
            GeneralFormLibrary1.FormControls.AssignListToDataGridView<GeneralFormLibrary1.DataModels.Model_Country>(dataGridView_DataViewer, model);

            //Cancel animation
            status.Cancel();

            await Task.Run(() => Thread.Sleep(3000));
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "");
        }


        private async Task<SortableBindingList<GeneralFormLibrary1.DataModels.Model_Country>> GetData()
        {
            GeneralFormLibrary1.DataAccess<GeneralFormLibrary1.DataModels.Model_Country> dataAccess = new DataAccess<GeneralFormLibrary1.DataModels.Model_Country>(GlobalAppProperties.GetCredentials());
            SortableBindingList<GeneralFormLibrary1.DataModels.Model_Country> model = new SortableBindingList<GeneralFormLibrary1.DataModels.Model_Country>(await dataAccess.GetAll());
            return model;
        }


        private void btn_DataViewer_Export_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.DataGridViewExportToExcel<GeneralFormLibrary1.DataModels.Model_User>(dataGridView_DataViewer, GlobalAppProperties.AppName, "DataViewer", GlobalAppProperties.Directroy_Downloads, false);
        }

        private void dataGridView_DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
