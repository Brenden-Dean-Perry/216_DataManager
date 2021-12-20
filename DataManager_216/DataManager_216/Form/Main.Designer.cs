
namespace DataManager_216
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelConstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIDataImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cryptographyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symmetricEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asymmeticEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaVantageAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser_Main_1 = new System.Windows.Forms.WebBrowser();
            this.dataCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_Main_DataImportReport = new System.Windows.Forms.DataGridView();
            this.dataGridView_Main_SecurityPriceReport = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main_DataImportReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main_SecurityPriceReport)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 817);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1197, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.aPIsToolStripMenuItem,
            this.cryptographyToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1197, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataViewerToolStripMenuItem,
            this.dataImporterToolStripMenuItem,
            this.modelConstructorToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // dataViewerToolStripMenuItem
            // 
            this.dataViewerToolStripMenuItem.Name = "dataViewerToolStripMenuItem";
            this.dataViewerToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.dataViewerToolStripMenuItem.Text = "Data Viewer";
            this.dataViewerToolStripMenuItem.Click += new System.EventHandler(this.dataViewerToolStripMenuItem_Click);
            // 
            // dataImporterToolStripMenuItem
            // 
            this.dataImporterToolStripMenuItem.Name = "dataImporterToolStripMenuItem";
            this.dataImporterToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.dataImporterToolStripMenuItem.Text = "Data Importer";
            // 
            // modelConstructorToolStripMenuItem
            // 
            this.modelConstructorToolStripMenuItem.Name = "modelConstructorToolStripMenuItem";
            this.modelConstructorToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.modelConstructorToolStripMenuItem.Text = "Data Model Constructor";
            this.modelConstructorToolStripMenuItem.Click += new System.EventHandler(this.modelConstructorToolStripMenuItem_Click);
            // 
            // aPIsToolStripMenuItem
            // 
            this.aPIsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPIViewerToolStripMenuItem,
            this.aPIDataImporterToolStripMenuItem});
            this.aPIsToolStripMenuItem.Name = "aPIsToolStripMenuItem";
            this.aPIsToolStripMenuItem.Size = new System.Drawing.Size(45, 26);
            this.aPIsToolStripMenuItem.Text = "API";
            // 
            // aPIViewerToolStripMenuItem
            // 
            this.aPIViewerToolStripMenuItem.Name = "aPIViewerToolStripMenuItem";
            this.aPIViewerToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.aPIViewerToolStripMenuItem.Text = "API Viewer";
            this.aPIViewerToolStripMenuItem.Click += new System.EventHandler(this.aPIViewerToolStripMenuItem_Click);
            // 
            // aPIDataImporterToolStripMenuItem
            // 
            this.aPIDataImporterToolStripMenuItem.Name = "aPIDataImporterToolStripMenuItem";
            this.aPIDataImporterToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.aPIDataImporterToolStripMenuItem.Text = "API Data Importer";
            // 
            // cryptographyToolStripMenuItem
            // 
            this.cryptographyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hasherToolStripMenuItem,
            this.symmetricEncryptionToolStripMenuItem,
            this.asymmeticEncryptionToolStripMenuItem});
            this.cryptographyToolStripMenuItem.Name = "cryptographyToolStripMenuItem";
            this.cryptographyToolStripMenuItem.Size = new System.Drawing.Size(113, 26);
            this.cryptographyToolStripMenuItem.Text = "Cryptography";
            // 
            // hasherToolStripMenuItem
            // 
            this.hasherToolStripMenuItem.Name = "hasherToolStripMenuItem";
            this.hasherToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.hasherToolStripMenuItem.Text = "Hasher";
            this.hasherToolStripMenuItem.Click += new System.EventHandler(this.hasherToolStripMenuItem_Click);
            // 
            // symmetricEncryptionToolStripMenuItem
            // 
            this.symmetricEncryptionToolStripMenuItem.Name = "symmetricEncryptionToolStripMenuItem";
            this.symmetricEncryptionToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.symmetricEncryptionToolStripMenuItem.Text = "Symmetric Encryption - AES";
            this.symmetricEncryptionToolStripMenuItem.Click += new System.EventHandler(this.symmetricEncryptionToolStripMenuItem_Click);
            // 
            // asymmeticEncryptionToolStripMenuItem
            // 
            this.asymmeticEncryptionToolStripMenuItem.Name = "asymmeticEncryptionToolStripMenuItem";
            this.asymmeticEncryptionToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.asymmeticEncryptionToolStripMenuItem.Text = "Asymmetic Encryption - RSA";
            this.asymmeticEncryptionToolStripMenuItem.Click += new System.EventHandler(this.asymmeticEncryptionToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1,
            this.alphaVantageAPIToolStripMenuItem,
            this.dataCollectorToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.testToolStripMenuItem1.Text = "Test";
            this.testToolStripMenuItem1.Click += new System.EventHandler(this.testToolStripMenuItem1_Click);
            // 
            // alphaVantageAPIToolStripMenuItem
            // 
            this.alphaVantageAPIToolStripMenuItem.Name = "alphaVantageAPIToolStripMenuItem";
            this.alphaVantageAPIToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.alphaVantageAPIToolStripMenuItem.Text = "Alpha Vantage API";
            this.alphaVantageAPIToolStripMenuItem.Click += new System.EventHandler(this.alphaVantageAPIToolStripMenuItem_Click);
            // 
            // webBrowser_Main_1
            // 
            this.webBrowser_Main_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser_Main_1.Location = new System.Drawing.Point(541, 31);
            this.webBrowser_Main_1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Main_1.Name = "webBrowser_Main_1";
            this.webBrowser_Main_1.Size = new System.Drawing.Size(656, 391);
            this.webBrowser_Main_1.TabIndex = 0;
            // 
            // dataCollectorToolStripMenuItem
            // 
            this.dataCollectorToolStripMenuItem.Name = "dataCollectorToolStripMenuItem";
            this.dataCollectorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataCollectorToolStripMenuItem.Text = "Data Collector";
            this.dataCollectorToolStripMenuItem.Click += new System.EventHandler(this.dataCollectorToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 428);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1197, 386);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tabPage1.Controls.Add(this.dataGridView_Main_DataImportReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1189, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Import Report";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tabPage2.Controls.Add(this.dataGridView_Main_SecurityPriceReport);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1189, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Security Price Report";
            // 
            // dataGridView_Main_DataImportReport
            // 
            this.dataGridView_Main_DataImportReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Main_DataImportReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dataGridView_Main_DataImportReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Main_DataImportReport.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Main_DataImportReport.Name = "dataGridView_Main_DataImportReport";
            this.dataGridView_Main_DataImportReport.RowHeadersWidth = 51;
            this.dataGridView_Main_DataImportReport.RowTemplate.Height = 24;
            this.dataGridView_Main_DataImportReport.Size = new System.Drawing.Size(1183, 348);
            this.dataGridView_Main_DataImportReport.TabIndex = 0;
            // 
            // dataGridView_Main_SecurityPriceReport
            // 
            this.dataGridView_Main_SecurityPriceReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Main_SecurityPriceReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dataGridView_Main_SecurityPriceReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Main_SecurityPriceReport.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Main_SecurityPriceReport.Name = "dataGridView_Main_SecurityPriceReport";
            this.dataGridView_Main_SecurityPriceReport.RowHeadersWidth = 51;
            this.dataGridView_Main_SecurityPriceReport.RowTemplate.Height = 24;
            this.dataGridView_Main_SecurityPriceReport.Size = new System.Drawing.Size(1183, 348);
            this.dataGridView_Main_SecurityPriceReport.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1197, 839);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.webBrowser_Main_1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "216";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main_DataImportReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main_SecurityPriceReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataImporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelConstructorToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser_Main_1;
        private System.Windows.Forms.ToolStripMenuItem cryptographyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem symmetricEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asymmeticEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alphaVantageAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIDataImporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataCollectorToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_Main_DataImportReport;
        private System.Windows.Forms.DataGridView dataGridView_Main_SecurityPriceReport;
    }
}

