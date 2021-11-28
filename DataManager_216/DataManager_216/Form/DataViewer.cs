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
            GeneralFormLibrary1.DatabaseAPI db = new DatabaseAPI();

            List<DataModels.Model_User> users = db.GetData_List<DataModels.Model_User>("Use Pi Select * From Users;");

            GeneralFormLibrary1.FormControls.AssignListToComboBox<DataModels.Model_User>(comboBox_DataViewer_TableSelection, users, "FirstName");
        }

        private async void btn_DataViewer_Search_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, DateTime.Now.ToString());
            await RunAsync();
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "After Async");

        }

        private async Task RunAsync()
        {
            GeneralFormLibrary1.DatabaseAPI db = new DatabaseAPI();
            List<DataModels.Model_User> model = await db.GetData_List_Async<DataModels.Model_User>("Use Pi DECLARE @cnt INT = 0 WHILE @cnt < 10000000 BEGIN SET @cnt = @cnt + 1 END; Select * From Users;");

            GeneralFormLibrary1.FormControls.AssignListToDataGridView<DataModels.Model_User>(dataGridView_DataViewer, model);
        }


        private async Task RunAsync2()
        {
            GeneralFormLibrary1.DatabaseAPI db = new DatabaseAPI();
            List<DataModels.Model_SubAssetClass> model = await db.GetData_List_Async<DataModels.Model_SubAssetClass>("Use Pi DECLARE @cnt INT = 0 WHILE @cnt < 10000000 BEGIN SET @cnt = @cnt + 1 END; Select * From SubAssetClass;");

            GeneralFormLibrary1.FormControls.AssignListToDataGridView<DataModels.Model_SubAssetClass>(dataGridView_DataViewer, model);
            
            int counter = 0;
            for (int i = 0; i<20;  i++)
            {
                GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, counter.ToString());
                System.Threading.Thread.Sleep(1000);
                counter++;
            }
            
        }

        private async void btn_DataViewer_Export_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, DateTime.Now.ToString());
            await RunAsync2();
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "After Async");
        }
    }
}
