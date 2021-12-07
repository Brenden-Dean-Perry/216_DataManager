
namespace DataManager_216
{
    partial class frmHasher
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
            this.btn_Hasher_HashText = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_Hasher_HashedValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Hasher_Text = new System.Windows.Forms.TextBox();
            this.tb_Hasher_File = new System.Windows.Forms.TextBox();
            this.btn_Hasher_Select = new System.Windows.Forms.Button();
            this.btn_Hasher_HashFile = new System.Windows.Forms.Button();
            this.comboBox_Hasher_HashAlgo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Hasher_HashText
            // 
            this.btn_Hasher_HashText.Location = new System.Drawing.Point(324, 14);
            this.btn_Hasher_HashText.Name = "btn_Hasher_HashText";
            this.btn_Hasher_HashText.Size = new System.Drawing.Size(104, 30);
            this.btn_Hasher_HashText.TabIndex = 0;
            this.btn_Hasher_HashText.Text = "Hash Text";
            this.btn_Hasher_HashText.UseVisualStyleBackColor = true;
            this.btn_Hasher_HashText.Click += new System.EventHandler(this.btn_Hasher_HashText_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Hasher_Select);
            this.panel1.Controls.Add(this.tb_Hasher_File);
            this.panel1.Controls.Add(this.tb_Hasher_Text);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 337);
            this.panel1.TabIndex = 1;
            // 
            // tb_Hasher_HashedValue
            // 
            this.tb_Hasher_HashedValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_Hasher_HashedValue.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Hasher_HashedValue.ForeColor = System.Drawing.Color.White;
            this.tb_Hasher_HashedValue.Location = new System.Drawing.Point(23, 411);
            this.tb_Hasher_HashedValue.Multiline = true;
            this.tb_Hasher_HashedValue.Name = "tb_Hasher_HashedValue";
            this.tb_Hasher_HashedValue.Size = new System.Drawing.Size(1273, 392);
            this.tb_Hasher_HashedValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text:";
            // 
            // tb_Hasher_Text
            // 
            this.tb_Hasher_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_Hasher_Text.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Hasher_Text.ForeColor = System.Drawing.Color.White;
            this.tb_Hasher_Text.Location = new System.Drawing.Point(18, 105);
            this.tb_Hasher_Text.Multiline = true;
            this.tb_Hasher_Text.Name = "tb_Hasher_Text";
            this.tb_Hasher_Text.Size = new System.Drawing.Size(1233, 212);
            this.tb_Hasher_Text.TabIndex = 2;
            // 
            // tb_Hasher_File
            // 
            this.tb_Hasher_File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_Hasher_File.ForeColor = System.Drawing.Color.White;
            this.tb_Hasher_File.Location = new System.Drawing.Point(18, 49);
            this.tb_Hasher_File.Name = "tb_Hasher_File";
            this.tb_Hasher_File.Size = new System.Drawing.Size(1152, 22);
            this.tb_Hasher_File.TabIndex = 3;
            // 
            // btn_Hasher_Select
            // 
            this.btn_Hasher_Select.Location = new System.Drawing.Point(1176, 45);
            this.btn_Hasher_Select.Name = "btn_Hasher_Select";
            this.btn_Hasher_Select.Size = new System.Drawing.Size(75, 30);
            this.btn_Hasher_Select.TabIndex = 4;
            this.btn_Hasher_Select.Text = "Select";
            this.btn_Hasher_Select.UseVisualStyleBackColor = true;
            this.btn_Hasher_Select.Click += new System.EventHandler(this.btn_Hasher_Select_Click);
            // 
            // btn_Hasher_HashFile
            // 
            this.btn_Hasher_HashFile.Location = new System.Drawing.Point(444, 14);
            this.btn_Hasher_HashFile.Name = "btn_Hasher_HashFile";
            this.btn_Hasher_HashFile.Size = new System.Drawing.Size(104, 30);
            this.btn_Hasher_HashFile.TabIndex = 3;
            this.btn_Hasher_HashFile.Text = "Hash File";
            this.btn_Hasher_HashFile.UseVisualStyleBackColor = true;
            this.btn_Hasher_HashFile.Click += new System.EventHandler(this.btn_Hasher_HashFile_Click);
            // 
            // comboBox_Hasher_HashAlgo
            // 
            this.comboBox_Hasher_HashAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Hasher_HashAlgo.FormattingEnabled = true;
            this.comboBox_Hasher_HashAlgo.Location = new System.Drawing.Point(23, 18);
            this.comboBox_Hasher_HashAlgo.Name = "comboBox_Hasher_HashAlgo";
            this.comboBox_Hasher_HashAlgo.Size = new System.Drawing.Size(285, 24);
            this.comboBox_Hasher_HashAlgo.TabIndex = 4;
            // 
            // frmHasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1319, 815);
            this.Controls.Add(this.comboBox_Hasher_HashAlgo);
            this.Controls.Add(this.btn_Hasher_HashFile);
            this.Controls.Add(this.tb_Hasher_HashedValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Hasher_HashText);
            this.Name = "frmHasher";
            this.Text = "Hasher";
            this.Load += new System.EventHandler(this.frmHasher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Hasher_HashText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Hasher_Select;
        private System.Windows.Forms.TextBox tb_Hasher_File;
        private System.Windows.Forms.TextBox tb_Hasher_Text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Hasher_HashedValue;
        private System.Windows.Forms.Button btn_Hasher_HashFile;
        private System.Windows.Forms.ComboBox comboBox_Hasher_HashAlgo;
    }
}