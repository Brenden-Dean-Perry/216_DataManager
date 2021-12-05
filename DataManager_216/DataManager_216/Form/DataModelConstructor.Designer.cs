
namespace DataManager_216
{
    partial class frmDataModelConstructor
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
            this.tb_DataModelConstructor = new System.Windows.Forms.TextBox();
            this.comboBox_DataModelConstructor = new System.Windows.Forms.ComboBox();
            this.btn_DataModelConstructor_Generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_DataModelConstructor
            // 
            this.tb_DataModelConstructor.AcceptsReturn = true;
            this.tb_DataModelConstructor.AcceptsTab = true;
            this.tb_DataModelConstructor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_DataModelConstructor.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DataModelConstructor.ForeColor = System.Drawing.Color.White;
            this.tb_DataModelConstructor.Location = new System.Drawing.Point(26, 90);
            this.tb_DataModelConstructor.Multiline = true;
            this.tb_DataModelConstructor.Name = "tb_DataModelConstructor";
            this.tb_DataModelConstructor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_DataModelConstructor.Size = new System.Drawing.Size(898, 669);
            this.tb_DataModelConstructor.TabIndex = 0;
            // 
            // comboBox_DataModelConstructor
            // 
            this.comboBox_DataModelConstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataModelConstructor.FormattingEnabled = true;
            this.comboBox_DataModelConstructor.Location = new System.Drawing.Point(26, 32);
            this.comboBox_DataModelConstructor.Name = "comboBox_DataModelConstructor";
            this.comboBox_DataModelConstructor.Size = new System.Drawing.Size(333, 24);
            this.comboBox_DataModelConstructor.TabIndex = 1;
            // 
            // btn_DataModelConstructor_Generate
            // 
            this.btn_DataModelConstructor_Generate.Location = new System.Drawing.Point(381, 27);
            this.btn_DataModelConstructor_Generate.Name = "btn_DataModelConstructor_Generate";
            this.btn_DataModelConstructor_Generate.Size = new System.Drawing.Size(104, 33);
            this.btn_DataModelConstructor_Generate.TabIndex = 2;
            this.btn_DataModelConstructor_Generate.Text = "Generate";
            this.btn_DataModelConstructor_Generate.UseVisualStyleBackColor = true;
            this.btn_DataModelConstructor_Generate.Click += new System.EventHandler(this.btn_DataModelConstructor_Generate_Click);
            // 
            // frmDataModelConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(947, 790);
            this.Controls.Add(this.btn_DataModelConstructor_Generate);
            this.Controls.Add(this.comboBox_DataModelConstructor);
            this.Controls.Add(this.tb_DataModelConstructor);
            this.Name = "frmDataModelConstructor";
            this.Text = "DataModelConstructor";
            this.Load += new System.EventHandler(this.frmDataModelConstructor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_DataModelConstructor;
        private System.Windows.Forms.ComboBox comboBox_DataModelConstructor;
        private System.Windows.Forms.Button btn_DataModelConstructor_Generate;
    }
}