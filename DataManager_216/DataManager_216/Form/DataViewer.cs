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
        private bool RowNeedsInsert { get; set; } = false;
        private int PriorRowIndex { get; set; } = -2;
        private string ComboBoxItemSelected { get; set; }
        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {
            checkBox_DataViewer_AllowEdit.Checked = false;

            //Build table list
            DataAccess<Model_TableName> dataAccess = new DataAccess<Model_TableName>(GlobalAppProperties.GetCredentials());
            List<Model_TableName> tables = dataAccess.GetDatabaseTableNames();
            GeneralFormLibrary1.FormControls.AssignListToComboBox<GeneralFormLibrary1.DataModels.Model_TableName>(comboBox_DataViewer_TableSelection, tables, "TableName");
            dataGridView_DataViewer.MouseClick += dataGridView_DataViewer_MouseClick;
        }


        private void dataGridView_DataViewer_MouseClick(object sender, MouseEventArgs e)
        {
            string ExportFileName = "DataViewer_" + ComboBoxItemSelected + "_";

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                if (ComboBoxItemSelected == "Users")
                {
                    RightClickDropDownMenu<Model_User> dropDownMenu = new RightClickDropDownMenu<Model_User>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "Country")
                {
                    RightClickDropDownMenu<Model_Country> dropDownMenu = new RightClickDropDownMenu<Model_Country>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "Currency")
                {
                    RightClickDropDownMenu<Model_Currency> dropDownMenu = new RightClickDropDownMenu<Model_Currency>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "Entity")
                {
                    RightClickDropDownMenu<Model_Entity> dropDownMenu = new RightClickDropDownMenu<Model_Entity>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "EntityType")
                {
                    RightClickDropDownMenu<Model_EntityType> dropDownMenu = new RightClickDropDownMenu<Model_EntityType>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "AssetType")
                {
                    RightClickDropDownMenu<Model_AssetType> dropDownMenu = new RightClickDropDownMenu<Model_AssetType>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "UnderlyingAsset")
                {
                    RightClickDropDownMenu<Model_UnderlyingAsset> dropDownMenu = new RightClickDropDownMenu<Model_UnderlyingAsset>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "Contract")
                {
                    RightClickDropDownMenu<Model_Contract> dropDownMenu = new RightClickDropDownMenu<Model_Contract>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "Security")
                {
                    RightClickDropDownMenu<Model_Security> dropDownMenu = new RightClickDropDownMenu<Model_Security>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecurityPrice")
                {
                    RightClickDropDownMenu<Model_SecurityPrice> dropDownMenu = new RightClickDropDownMenu<Model_SecurityPrice>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecurityPriceType")
                {
                    RightClickDropDownMenu<Model_SecurityPriceType> dropDownMenu = new RightClickDropDownMenu<Model_SecurityPriceType>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecurityVolume")
                {
                    RightClickDropDownMenu<Model_SecurityVolume> dropDownMenu = new RightClickDropDownMenu<Model_SecurityVolume>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "DataSource")
                {
                    RightClickDropDownMenu<Model_DataSource> dropDownMenu = new RightClickDropDownMenu<Model_DataSource>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "DataImportJob")
                {
                    RightClickDropDownMenu<Model_DataImportJob> dropDownMenu = new RightClickDropDownMenu<Model_DataImportJob>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "DataImportJobType")
                {
                    RightClickDropDownMenu<Model_DataImportJobType> dropDownMenu = new RightClickDropDownMenu<Model_DataImportJobType>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "DataImportJobTypeOccuranceType")
                {
                    RightClickDropDownMenu<Model_DataImportOccuranceType> dropDownMenu = new RightClickDropDownMenu<Model_DataImportOccuranceType>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecurityPriceIntraday")
                {
                    RightClickDropDownMenu<Model_SecurityPriceIntraday> dropDownMenu = new RightClickDropDownMenu<Model_SecurityPriceIntraday>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecurityVolumeIntraday")
                {
                    RightClickDropDownMenu<Model_SecurityVolumeIntraday> dropDownMenu = new RightClickDropDownMenu<Model_SecurityVolumeIntraday>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecurityDistribution")
                {
                    RightClickDropDownMenu<Model_SecurityDistribution> dropDownMenu = new RightClickDropDownMenu<Model_SecurityDistribution>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "DistributionType")
                {
                    RightClickDropDownMenu<Model_DistributionType> dropDownMenu = new RightClickDropDownMenu<Model_DistributionType>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else if (ComboBoxItemSelected == "SecuritySplit")
                {
                    RightClickDropDownMenu<Model_SecuritySplit> dropDownMenu = new RightClickDropDownMenu<Model_SecuritySplit>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL_Delete, e);
                }
                else
                {
                    RightClickDropDownMenu<object> dropDownMenu = new RightClickDropDownMenu<object>(contextMenu, dataGridView_DataViewer, gridViewFilters, GlobalAppProperties.AppName, ExportFileName, GlobalAppProperties.GetCredentials());
                    dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL, e);
                }

            }
        }

        private void dataGridView_DataViewer_Sorted(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.FilterDataGridView(dataGridView_DataViewer, gridViewFilters);
        }



        private async void btn_DataViewer_Search_Click(object sender, EventArgs e)
        {
            //Lock the combobox
            bool IsUnlockedForEditing = checkBox_DataViewer_AllowEdit.Checked;

            ComboBoxItemSelected = null;
            comboBox_DataViewer_TableSelection.Enabled = false;
            checkBox_DataViewer_AllowEdit.Checked = false;
            ComboBoxItemSelected = comboBox_DataViewer_TableSelection.GetItemText(comboBox_DataViewer_TableSelection.SelectedItem);

            //Start status animation
            var tokenSource = new CancellationTokenSource();
            StatusAnimation status = new StatusAnimation(this, statusStrip_DataViewer, tokenSource);
            status.Start();

            //Do task
            if(ComboBoxItemSelected == "Users")
            {
                SortableBindingList<Model_User> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_User>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_User>(dataGridView_DataViewer, model, true);
            }
            else if(ComboBoxItemSelected == "Country")
            {
                SortableBindingList<Model_Country> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_Country>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_Country>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "Currency")
            {
                SortableBindingList<Model_Currency> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_Currency>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_Currency>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "Entity")
            {
                SortableBindingList<Model_Entity> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_Entity>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_Entity>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "EntityType")
            {
                SortableBindingList<Model_EntityType> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_EntityType>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_EntityType>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "AssetType")
            {
                SortableBindingList<Model_AssetType> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_AssetType>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_AssetType>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "UnderlyingAsset")
            {
                SortableBindingList<Model_UnderlyingAsset> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_UnderlyingAsset>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_UnderlyingAsset>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "Contract")
            {
                SortableBindingList<Model_Contract> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_Contract>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_Contract>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "Security")
            {
                SortableBindingList<Model_Security> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_Security>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_Security>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecurityPrice")
            {
                SortableBindingList<Model_SecurityPrice> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecurityPrice>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecurityPrice>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecurityPriceType")
            {
                SortableBindingList<Model_SecurityPriceType> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecurityPriceType>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecurityPriceType>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecurityVolume")
            {
                SortableBindingList<Model_SecurityVolume> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecurityVolume>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecurityVolume>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "DataSource")
            {
                SortableBindingList<Model_DataSource> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_DataSource>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_DataSource>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "DataImportJob")
            {
                SortableBindingList<Model_DataImportJob> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_DataImportJob>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_DataImportJob>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "DataImportJobType")
            {
                SortableBindingList<Model_DataImportJobType> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_DataImportJobType>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_DataImportJobType>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "DataImportOccuranceType")
            {
                SortableBindingList<Model_DataImportOccuranceType> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_DataImportOccuranceType>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_DataImportOccuranceType>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecurityPriceIntraday")
            {
                SortableBindingList<Model_SecurityPriceIntraday> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecurityPriceIntraday>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecurityPriceIntraday>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecurityVolumeIntraday")
            {
                SortableBindingList<Model_SecurityVolumeIntraday> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecurityVolumeIntraday>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecurityVolumeIntraday>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecuritySplit")
            {
                SortableBindingList<Model_SecuritySplit> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecuritySplit>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecuritySplit>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "SecurityDistribution")
            {
                SortableBindingList<Model_SecurityDistribution> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_SecurityDistribution>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_SecurityDistribution>(dataGridView_DataViewer, model, true);
            }
            else if (ComboBoxItemSelected == "DistributionType")
            {
                SortableBindingList<Model_DistributionType> model = await Task.Run(() => FormControl_DataAccess.GetSortableBindingListOfData<Model_DistributionType>(GlobalAppProperties.GetCredentials()));
                FormControls.AssignListToDataGridView<Model_DistributionType>(dataGridView_DataViewer, model, true);
            }
            else
            {
                SortableBindingList<string> model = null;
                FormControls.AssignListToDataGridView<string>(dataGridView_DataViewer, model, true);
            }
            
            //Cancel animation
            status.Cancel();

            //Re-set allow edit option after update
            checkBox_DataViewer_AllowEdit.Checked = IsUnlockedForEditing;

            await Task.Run(() => Thread.Sleep(3000));
            FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "");

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

            FormControl_DataAccess form_DataAccess = new FormControl_DataAccess();
            //Subscribe to the update data event
            form_DataAccess.UpdateData += btn_DataViewer_Search_Click;
            if (RowNeedsInsert)
            {
                int recordID = 0;
                RowNeedsInsert = false;
                if (ComboBoxItemSelected == "Users")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_User>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "Country")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_Country>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "Currency")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_Currency>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "Entity")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_Entity>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "EntityType")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_EntityType>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "AssetType")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_AssetType>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "UnderlyingAsset")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_UnderlyingAsset>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "Contract")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_Contract>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "Security")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_Security>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecurityPrice")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecurityPrice>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecurityPriceType")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecurityPriceType>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecurityVolume")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecurityVolume>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "DataSource")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_DataSource>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "DataImportJob")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_DataImportJob>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "DataImportJobType")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_DataImportJobType>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "DataImportOccuranceType")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_DataImportOccuranceType>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecurityPriceIntraday")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecurityPriceIntraday>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecurityVolumeIntraday")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecurityVolumeIntraday>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecurityDistribution")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecurityDistribution>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "DistributionType")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_DistributionType>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else if (ComboBoxItemSelected == "SecuritySplit")
                {
                    recordID = await form_DataAccess.AddNewRecordFromDataGridView<Model_SecuritySplit>(GlobalAppProperties.GetCredentials(), dataGridView_DataViewer, PriorRowIndex, GlobalAppProperties.AppName);
                }
                else
                {
                    MessageBox.Show(null, "Invalid ComboBox item selected", GlobalAppProperties.AppName);
                    return;
                }

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

        private void btn_DataViewer_Clear_Click(object sender, EventArgs e)
        {
            dataGridView_DataViewer.DataSource = null;
            comboBox_DataViewer_TableSelection.Enabled = true;
        }

    }
}
