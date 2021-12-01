﻿using System;
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
            List<GeneralFormLibrary1.DataModels.Model_TableName> tables = GeneralFormLibrary1.DataAccess.GetDatabaseTableNames_PI();
            GeneralFormLibrary1.FormControls.AssignListToComboBox<GeneralFormLibrary1.DataModels.Model_TableName>(comboBox_DataViewer_TableSelection, tables, "TableName");
        }

        private async void btn_DataViewer_Search_Click(object sender, EventArgs e)
        {
            //Start status animation
            var tokenSource = new CancellationTokenSource();
            StatusAnimation status = new StatusAnimation(this, statusStrip_DataViewer, tokenSource);
            status.Start();

            //Do task
            SortableBindingList<GeneralFormLibrary1.DataModels.Model_User> model = await Task.Run(() => GetData());
            GeneralFormLibrary1.FormControls.AssignListToDataGridView<GeneralFormLibrary1.DataModels.Model_User>(dataGridView_DataViewer, model);

            //Cancel animation
            status.Cancel();

            await Task.Run(() => Thread.Sleep(3000));
            GeneralFormLibrary1.FormControls.UpdateToolStripItemLabel(statusStrip_DataViewer, "");
        }


        private SortableBindingList<GeneralFormLibrary1.DataModels.Model_User> GetData()
        {

            SortableBindingList<GeneralFormLibrary1.DataModels.Model_User> model = new SortableBindingList<GeneralFormLibrary1.DataModels.Model_User>(GeneralFormLibrary1.DataAccess.GetDataList_PI_Users());
            return model;
        }



        private void btn_DataViewer_Export_Click(object sender, EventArgs e)
        {
            string rowFilter = string.Format("[{0}] = '{1}'", "FirstName", "Isla");
            if(dataGridView_DataViewer.Rows.Count != 0)
            {
                GeneralFormLibrary1.FormControls.FilterDataGridView(dataGridView_DataViewer, 1, FormControls.ComparisonOperator.Equals, "Isla");
                MessageBox.Show("Stop");
                GeneralFormLibrary1.FormControls.UnfilterDataGridView(dataGridView_DataViewer);
            }
            
        }
    }
}
