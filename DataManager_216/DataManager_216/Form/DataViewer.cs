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
using GeneralFormLibrary1.DataModels;

namespace DataManager_216
{
    public partial class frmDataViewer : Form
    {
        private delegate void InvokeDelegate();
        private List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter> gridViewFilters = new List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter>();
        private bool RowNeedsInsert {get; set;}
        private int PriorRowIndex { get; set; }
        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {
            checkBox_DataViewer_AllowEdit.Checked = false;
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
                RightClickDropDownMenu<Model_User> dropDownMenu = new RightClickDropDownMenu<Model_User>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, "DataViewer",GlobalAppProperties.GetCredentials());
                dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
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
            SortableBindingList<Model_User> model = await Task.Run(() => GetData());
            GeneralFormLibrary1.FormControls.AssignListToDataGridView<Model_User>(dataGridView_DataViewer, model, true);

            //Cancel animation
            status.Cancel();

            await Task.Run(() => Thread.Sleep(3000));
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "");
        }


        private async Task<SortableBindingList<Model_User>> GetData()
        {
            GeneralFormLibrary1.DataAccess<Model_User> dataAccess = new DataAccess<Model_User>(GlobalAppProperties.GetCredentials());
            SortableBindingList<Model_User> model = new SortableBindingList<Model_User>(await dataAccess.GetAll());
            return model;
        }

        private void dataGridView_DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_DataViewer_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            RowNeedsInsert = true;
        }

        private async void dataGridView_DataViewer_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Store reference to inserted row index
                PriorRowIndex = dataGridView_DataViewer.CurrentRow.Index;

                //Snap to the next rows first cell to ensure all values are accepted into the datagridview
                dataGridView_DataViewer.CurrentCell = dataGridView_DataViewer.Rows[PriorRowIndex].Cells[0];
            }
            catch
            {
                PriorRowIndex = -2;
            }

            if (RowNeedsInsert)
            {
                Model_User newItem = GeneralFormLibrary1.FormControls.DataGridViewToObject<Model_User>(dataGridView_DataViewer, PriorRowIndex);
                GeneralFormLibrary1.DataAccess<Model_User> dataAccess = new DataAccess<Model_User>(GlobalAppProperties.GetCredentials());
                int recordID = await dataAccess.Add(newItem);

                if(recordID > 0)
                {
                    MessageBox.Show("Record inserted");
                }
                else
                {
                    MessageBox.Show("Record failed to insert");
                }

                RowNeedsInsert = false;
            }
        }

        private void checkBox_DataViewer_AllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_DataViewer_AllowEdit.Checked == true)
            {
                //Unlock
                GeneralFormLibrary1.FormControls.DataGridViewMakeUneditable(dataGridView_DataViewer, false, false);
            }
            else
            {
                //Lock
                dataGridView_DataViewer.AllowUserToAddRows = false;
                GeneralFormLibrary1.FormControls.DataGridViewMakeUneditable(dataGridView_DataViewer, true, true);
            }
        }
    }
}
