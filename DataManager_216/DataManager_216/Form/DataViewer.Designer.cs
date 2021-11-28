
namespace DataManager_216
{
    partial class frmDataViewer
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
            this.statusStrip_DataViewer = new System.Windows.Forms.StatusStrip();
            this.dataGridView_DataViewer = new System.Windows.Forms.DataGridView();
            this.comboBox_DataViewer_TableSelection = new System.Windows.Forms.ComboBox();
            this.btn_DataViewer_Search = new System.Windows.Forms.Button();
            this.btn_DataViewer_Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_DataViewer
            // 
            this.statusStrip_DataViewer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_DataViewer.Location = new System.Drawing.Point(0, 762);
            this.statusStrip_DataViewer.Name = "statusStrip_DataViewer";
            this.statusStrip_DataViewer.Size = new System.Drawing.Size(1209, 22);
            this.statusStrip_DataViewer.TabIndex = 0;
            this.statusStrip_DataViewer.Text = "statusStrip1";
            // 
            // dataGridView_DataViewer
            // 
            this.dataGridView_DataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DataViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dataGridView_DataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DataViewer.Location = new System.Drawing.Point(12, 58);
            this.dataGridView_DataViewer.Name = "dataGridView_DataViewer";
            this.dataGridView_DataViewer.RowHeadersWidth = 51;
            this.dataGridView_DataViewer.RowTemplate.Height = 24;
            this.dataGridView_DataViewer.Size = new System.Drawing.Size(1185, 690);
            this.dataGridView_DataViewer.TabIndex = 1;
            // 
            // comboBox_DataViewer_TableSelection
            // 
            this.comboBox_DataViewer_TableSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataViewer_TableSelection.FormattingEnabled = true;
            this.comboBox_DataViewer_TableSelection.Location = new System.Drawing.Point(37, 13);
            this.comboBox_DataViewer_TableSelection.Name = "comboBox_DataViewer_TableSelection";
            this.comboBox_DataViewer_TableSelection.Size = new System.Drawing.Size(282, 24);
            this.comboBox_DataViewer_TableSelection.TabIndex = 2;
            // 
            // btn_DataViewer_Search
            // 
            this.btn_DataViewer_Search.Location = new System.Drawing.Point(337, 13);
            this.btn_DataViewer_Search.Name = "btn_DataViewer_Search";
            this.btn_DataViewer_Search.Size = new System.Drawing.Size(75, 30);
            this.btn_DataViewer_Search.TabIndex = 3;
            this.btn_DataViewer_Search.Text = "Search";
            this.btn_DataViewer_Search.UseVisualStyleBackColor = true;
            this.btn_DataViewer_Search.Click += new System.EventHandler(this.btn_DataViewer_Search_Click);
            // 
            // btn_DataViewer_Export
            // 
            this.btn_DataViewer_Export.Location = new System.Drawing.Point(418, 13);
            this.btn_DataViewer_Export.Name = "btn_DataViewer_Export";
            this.btn_DataViewer_Export.Size = new System.Drawing.Size(75, 30);
            this.btn_DataViewer_Export.TabIndex = 4;
            this.btn_DataViewer_Export.Text = "Export";
            this.btn_DataViewer_Export.UseVisualStyleBackColor = true;
            this.btn_DataViewer_Export.Click += new System.EventHandler(this.btn_DataViewer_Export_Click);
            // 
            // frmDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1209, 784);
            this.Controls.Add(this.btn_DataViewer_Export);
            this.Controls.Add(this.btn_DataViewer_Search);
            this.Controls.Add(this.comboBox_DataViewer_TableSelection);
            this.Controls.Add(this.dataGridView_DataViewer);
            this.Controls.Add(this.statusStrip_DataViewer);
            this.Name = "frmDataViewer";
            this.Text = "DataViewer";
            this.Load += new System.EventHandler(this.frmDataViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_DataViewer;
        private System.Windows.Forms.DataGridView dataGridView_DataViewer;
        private System.Windows.Forms.ComboBox comboBox_DataViewer_TableSelection;
        private System.Windows.Forms.Button btn_DataViewer_Search;
        private System.Windows.Forms.Button btn_DataViewer_Export;
    }
}