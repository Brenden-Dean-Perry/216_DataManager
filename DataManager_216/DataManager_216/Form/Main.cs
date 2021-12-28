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
using GeneralFormLibrary1.DataModels.Query_DataModels;
using System.Timers;

namespace DataManager_216
{
    public partial class frmMain : Form
    {
        private List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter> gridViewFilters = new List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter>();
        private frmLogin frmlogin {get; set;}

        public frmMain(frmLogin login)
        {
            InitializeComponent();
            frmlogin = login;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = GlobalAppProperties.AppName;
            //LaunchBloombergTvStream();
            LoadDataGridViews();
            dataGridView_Main_SecurityPriceReport.MouseClick += dataGridView_Main_SecurityPriceReport_MouseClick;
            dataGridView_Main_DataImportReport.MouseClick += dataGridView_Main_DataImportReport_MouseClick;
        }

        private void dataGridView_Main_SecurityPriceReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                RightClickDropDownMenu<Model_SecurityPriceAndVolumeReport> dropDownMenu = new RightClickDropDownMenu<Model_SecurityPriceAndVolumeReport>(contextMenu, dataGridView_Main_SecurityPriceReport, gridViewFilters, GlobalAppProperties.AppName, "SecurityPrice&VolumeReport", GlobalAppProperties.GetCredentials());
                dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL, e);
            }
        }

        private void dataGridView_Main_DataImportReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                RightClickDropDownMenu<Model_DataImportReport> dropDownMenu = new RightClickDropDownMenu<Model_DataImportReport>(contextMenu, dataGridView_Main_DataImportReport, gridViewFilters, GlobalAppProperties.AppName, "DataImportReport", GlobalAppProperties.GetCredentials());
                dropDownMenu.Show(CustomRightClickMenu.DefaultMenu_URL, e);
            }
        }

        private void dataGridView_Main_SecurityPriceReport_Sorted(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.FilterDataGridView(dataGridView_Main_SecurityPriceReport, gridViewFilters);
        }

        private void dataGridView_Main_DataImportReport_Sorted(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.FilterDataGridView(dataGridView_Main_DataImportReport, gridViewFilters);
            ColorDGVs();
        }

        private void LoadDataGridViews()
        {
            string query_PriceReport = System.IO.File.ReadAllText(GlobalAppProperties.GetSqlFilePath() + "Main_SecurityPriceAndVolumeReport.sql");
            SortableBindingList<Model_SecurityPriceAndVolumeReport> list_PriceReport = new SortableBindingList<Model_SecurityPriceAndVolumeReport>(DatabaseAPI.GetData_List<Model_SecurityPriceAndVolumeReport>(DatabaseAPI.ConnectionString("QuantDB", GlobalAppProperties.GetCredentials()), query_PriceReport));
            FormControls.AssignListToDataGridView<Model_SecurityPriceAndVolumeReport>(dataGridView_Main_SecurityPriceReport, list_PriceReport);

            string query_ImportReport = System.IO.File.ReadAllText(GlobalAppProperties.GetSqlFilePath() + "Main_DataImportReport.sql");
            SortableBindingList<Model_DataImportReport> list_ImportReport = new SortableBindingList<Model_DataImportReport>(DatabaseAPI.GetData_List<Model_DataImportReport>(DatabaseAPI.ConnectionString("QuantDB", GlobalAppProperties.GetCredentials()), query_ImportReport));
            FormControls.AssignListToDataGridView<Model_DataImportReport>(dataGridView_Main_DataImportReport, list_ImportReport);
            ColorDGVs();

            string query_Prices = System.IO.File.ReadAllText(GlobalAppProperties.GetSqlFilePath() + "Main_PriceSnapshot.sql");
            SortableBindingList<Model_PriceSnapshot> list_Prices = new SortableBindingList<Model_PriceSnapshot>(DatabaseAPI.GetData_List<Model_PriceSnapshot>(DatabaseAPI.ConnectionString("QuantDB", GlobalAppProperties.GetCredentials()), query_Prices));
            UpdateListView(list_Prices);

           
        }

        private void UpdateListView(IList<Model_PriceSnapshot> list)
        {
            listView_Main_Prices.Clear();
            string[] headers = { "Contract","Ticker","Date", "Close","PriorClose","Low","High"};
            foreach(string item in headers)
            {
                listView_Main_Prices.Columns.Add(item);
            }
            
            foreach(Model_PriceSnapshot it in list)
            {
                string[] rowitem = {it.Contract, it.Ticker, it.Date.ToString("d"), Math.Round(it.Close,4).ToString(), Math.Round(it.PriorClose, 4).ToString(), Math.Round(it.Low,4).ToString(), Math.Round(it.High,4).ToString()};
                var listViewItem = new ListViewItem(rowitem);
                listView_Main_Prices.Items.Add(listViewItem);
            }

            listView_Main_Prices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void ColorDGVs()
        {
            FormControls.ColorDataGridViewCellThatContains(dataGridView_Main_DataImportReport, "Status", "OK", Color.LightGreen, "Status");
            FormControls.ColorDataGridViewCellThatContains(dataGridView_Main_DataImportReport, "Status", "Not Run", Color.Red, "Status", false);
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

        private void symmetricEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAESEncryption aESEncryption = new frmAESEncryption();
            aESEncryption.Show();
        }

        private void asymmeticEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRSAEncryption rsa = new frmRSAEncryption();
            rsa.Show();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GeneralFormLibrary1.DataModelAPI.TableName<GeneralFormLibrary1.DataModels.Model_User>());
        }

        private void alphaVantageAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("start");
            AlphaVantageAPI api = new AlphaVantageAPI();
            api.GetTimeSeries(@"https://www.alphavantage.co/query?function=CRYPTO_INTRADAY&symbol=ETH&market=USD&interval=5min&outputsize=full&apikey=demo", "Time Series (Digital Currency Daily)");
            MessageBox.Show("end");
        }

        private void dataCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 30000000;
            //aTimer.Enabled = true;
            //aTimer.Start();
            OnTimedEvent(this, null);
        }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            DataCollector dataCollector = new DataCollector(GlobalAppProperties.GetCredentials());
            dataCollector.GetDataFromActiveJobs(DataCollector.Frequency.Daily, statusStrip_Main);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataGridViews();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmlogin.Close();
        }

        private void dataImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataUploader uploader = new frmDataUploader();
            uploader.Show();
        }

        private void alphaVanatageCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlphaVantageAPI api = new AlphaVantageAPI();
            api.GetTimeSeriesFromCSV(@"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY_EXTENDED&symbol=IBM&interval=15min&slice=year1month1&apikey=demo");
        }


    }
}
