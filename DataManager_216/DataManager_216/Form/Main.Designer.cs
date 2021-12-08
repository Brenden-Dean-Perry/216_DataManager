
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
            this.aPIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelConstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser_Main_1 = new System.Windows.Forms.WebBrowser();
            this.cryptographyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symmetricEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asymmeticEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.cryptographyToolStripMenuItem});
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
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
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
            // aPIsToolStripMenuItem
            // 
            this.aPIsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPIViewerToolStripMenuItem});
            this.aPIsToolStripMenuItem.Name = "aPIsToolStripMenuItem";
            this.aPIsToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.aPIsToolStripMenuItem.Text = "API";
            // 
            // aPIViewerToolStripMenuItem
            // 
            this.aPIViewerToolStripMenuItem.Name = "aPIViewerToolStripMenuItem";
            this.aPIViewerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aPIViewerToolStripMenuItem.Text = "API Viewer";
            this.aPIViewerToolStripMenuItem.Click += new System.EventHandler(this.aPIViewerToolStripMenuItem_Click);
            // 
            // modelConstructorToolStripMenuItem
            // 
            this.modelConstructorToolStripMenuItem.Name = "modelConstructorToolStripMenuItem";
            this.modelConstructorToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.modelConstructorToolStripMenuItem.Text = "Data Model Constructor";
            this.modelConstructorToolStripMenuItem.Click += new System.EventHandler(this.modelConstructorToolStripMenuItem_Click);
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
            // cryptographyToolStripMenuItem
            // 
            this.cryptographyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hasherToolStripMenuItem,
            this.symmetricEncryptionToolStripMenuItem,
            this.asymmeticEncryptionToolStripMenuItem});
            this.cryptographyToolStripMenuItem.Name = "cryptographyToolStripMenuItem";
            this.cryptographyToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.cryptographyToolStripMenuItem.Text = "Cryptography";
            // 
            // hasherToolStripMenuItem
            // 
            this.hasherToolStripMenuItem.Name = "hasherToolStripMenuItem";
            this.hasherToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.hasherToolStripMenuItem.Text = "Hasher";
            this.hasherToolStripMenuItem.Click += new System.EventHandler(this.hasherToolStripMenuItem_Click);
            // 
            // symmetricEncryptionToolStripMenuItem
            // 
            this.symmetricEncryptionToolStripMenuItem.Name = "symmetricEncryptionToolStripMenuItem";
            this.symmetricEncryptionToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.symmetricEncryptionToolStripMenuItem.Text = "Symmetric Encryption";
            // 
            // asymmeticEncryptionToolStripMenuItem
            // 
            this.asymmeticEncryptionToolStripMenuItem.Name = "asymmeticEncryptionToolStripMenuItem";
            this.asymmeticEncryptionToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.asymmeticEncryptionToolStripMenuItem.Text = "Asymmetic Encryption";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1197, 839);
            this.Controls.Add(this.webBrowser_Main_1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "216";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

