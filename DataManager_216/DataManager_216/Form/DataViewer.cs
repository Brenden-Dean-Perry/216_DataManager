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

        public frmDataViewer()
        {
            InitializeComponent();
        }

        private void frmDataViewer_Load(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls fc = new FormControls();
            GeneralFormLibrary1.DatabaseAPI db = new DatabaseAPI();

            List<GeneralFormLibrary1.DataModels.Model_User> users = db.GetData_List<GeneralFormLibrary1.DataModels.Model_User>("Use Pi Select * From Users;");

            GeneralFormLibrary1.FormControls.AssignListToComboBox<GeneralFormLibrary1.DataModels.Model_User>(comboBox_DataViewer_TableSelection, users, "FirstName");
        }

        private async void btn_DataViewer_Search_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls fc = new FormControls();

            //Start status animation
            var tokenSource = new CancellationTokenSource();
            StatusAnimation status = new StatusAnimation(this, statusStrip_DataViewer, tokenSource);
            status.Start();

            //Do task
            SortableBindingList<GeneralFormLibrary1.DataModels.Model_User> model = await Task.Run(() => GetDa());
            GeneralFormLibrary1.FormControls.AssignListToDataGridView<GeneralFormLibrary1.DataModels.Model_User>(dataGridView_DataViewer, model);

            //Cancel animation
            status.Cancel();

            await Task.Run(() => Thread.Sleep(3000));
            fc.UpdateToolStripItemLabel(statusStrip_DataViewer, "");
        }


        private SortableBindingList<GeneralFormLibrary1.DataModels.Model_User> GetDa()
        {
            GeneralFormLibrary1.DatabaseAPI db = new DatabaseAPI();
            SortableBindingList<GeneralFormLibrary1.DataModels.Model_User> model = new SortableBindingList<GeneralFormLibrary1.DataModels.Model_User>(GeneralFormLibrary1.DataAccess.GetDataList_PI_Users());
            return model;
        }



        private void btn_DataViewer_Export_Click(object sender, EventArgs e)
        {

        }

    }
}
