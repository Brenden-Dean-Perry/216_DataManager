
namespace DataManager_216
{
    partial class frmRSAEncryption
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
            this.btn_RSA_GenerateKeys = new System.Windows.Forms.Button();
            this.tb_RSA_PublicKey = new System.Windows.Forms.TextBox();
            this.tb_RSA_PrivateKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_RSA_GenerateKeys
            // 
            this.btn_RSA_GenerateKeys.Location = new System.Drawing.Point(1264, 864);
            this.btn_RSA_GenerateKeys.Name = "btn_RSA_GenerateKeys";
            this.btn_RSA_GenerateKeys.Size = new System.Drawing.Size(138, 37);
            this.btn_RSA_GenerateKeys.TabIndex = 0;
            this.btn_RSA_GenerateKeys.Text = "Generate Keys";
            this.btn_RSA_GenerateKeys.UseVisualStyleBackColor = true;
            this.btn_RSA_GenerateKeys.Click += new System.EventHandler(this.btn_RSA_GenerateKeys_Click);
            // 
            // tb_RSA_PublicKey
            // 
            this.tb_RSA_PublicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_PublicKey.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_PublicKey.Location = new System.Drawing.Point(181, 42);
            this.tb_RSA_PublicKey.Multiline = true;
            this.tb_RSA_PublicKey.Name = "tb_RSA_PublicKey";
            this.tb_RSA_PublicKey.Size = new System.Drawing.Size(1249, 240);
            this.tb_RSA_PublicKey.TabIndex = 1;
            // 
            // tb_RSA_PrivateKey
            // 
            this.tb_RSA_PrivateKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_PrivateKey.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_PrivateKey.Location = new System.Drawing.Point(181, 300);
            this.tb_RSA_PrivateKey.Multiline = true;
            this.tb_RSA_PrivateKey.Name = "tb_RSA_PrivateKey";
            this.tb_RSA_PrivateKey.Size = new System.Drawing.Size(1249, 240);
            this.tb_RSA_PrivateKey.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Public Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 314);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Private Key:";
            // 
            // frmRSAEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1456, 934);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_RSA_PrivateKey);
            this.Controls.Add(this.tb_RSA_PublicKey);
            this.Controls.Add(this.btn_RSA_GenerateKeys);
            this.Name = "frmRSAEncryption";
            this.Text = "RSAEncryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RSA_GenerateKeys;
        private System.Windows.Forms.TextBox tb_RSA_PublicKey;
        private System.Windows.Forms.TextBox tb_RSA_PrivateKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}