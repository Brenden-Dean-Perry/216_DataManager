﻿
namespace DataManager_216
{
    partial class frmAPIViewer
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
            this.dataGridView_APIViewer = new System.Windows.Forms.DataGridView();
            this.btn_APIViewer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_APIViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_APIViewer
            // 
            this.dataGridView_APIViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_APIViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dataGridView_APIViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_APIViewer.Location = new System.Drawing.Point(12, 94);
            this.dataGridView_APIViewer.Name = "dataGridView_APIViewer";
            this.dataGridView_APIViewer.RowHeadersWidth = 51;
            this.dataGridView_APIViewer.RowTemplate.Height = 24;
            this.dataGridView_APIViewer.Size = new System.Drawing.Size(1324, 675);
            this.dataGridView_APIViewer.TabIndex = 0;
            // 
            // btn_APIViewer
            // 
            this.btn_APIViewer.Location = new System.Drawing.Point(210, 35);
            this.btn_APIViewer.Name = "btn_APIViewer";
            this.btn_APIViewer.Size = new System.Drawing.Size(75, 31);
            this.btn_APIViewer.TabIndex = 1;
            this.btn_APIViewer.Text = "Export";
            this.btn_APIViewer.UseVisualStyleBackColor = true;
            this.btn_APIViewer.Click += new System.EventHandler(this.btn_APIViewer_Click);
            // 
            // frmAPIViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1348, 781);
            this.Controls.Add(this.btn_APIViewer);
            this.Controls.Add(this.dataGridView_APIViewer);
            this.Name = "frmAPIViewer";
            this.Text = "APIViewer";
            this.Load += new System.EventHandler(this.APIViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_APIViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_APIViewer;
        private System.Windows.Forms.Button btn_APIViewer;
    }
}