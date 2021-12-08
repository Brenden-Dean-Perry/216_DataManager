
namespace DataManager_216
{
    partial class frmAESEncryption
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
            this.tb_AES_Message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_AES_IV = new System.Windows.Forms.TextBox();
            this.tb_AES_Key = new System.Windows.Forms.TextBox();
            this.tb_AES_EncryptedMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_AES_DecryptedMessage = new System.Windows.Forms.TextBox();
            this.btn_AES_Encrypt = new System.Windows.Forms.Button();
            this.btn_AES_Decrypt = new System.Windows.Forms.Button();
            this.btn_AES_GenerateKey = new System.Windows.Forms.Button();
            this.btn_AES_GenerateIV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_AES_Message
            // 
            this.tb_AES_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_Message.ForeColor = System.Drawing.Color.White;
            this.tb_AES_Message.Location = new System.Drawing.Point(311, 175);
            this.tb_AES_Message.Margin = new System.Windows.Forms.Padding(4);
            this.tb_AES_Message.Multiline = true;
            this.tb_AES_Message.Name = "tb_AES_Message";
            this.tb_AES_Message.Size = new System.Drawing.Size(686, 92);
            this.tb_AES_Message.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 179);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initialization Vector (hexidecimal):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Key (hexidecimal):";
            // 
            // tb_AES_IV
            // 
            this.tb_AES_IV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_IV.ForeColor = System.Drawing.Color.White;
            this.tb_AES_IV.Location = new System.Drawing.Point(311, 139);
            this.tb_AES_IV.Name = "tb_AES_IV";
            this.tb_AES_IV.ReadOnly = true;
            this.tb_AES_IV.Size = new System.Drawing.Size(686, 27);
            this.tb_AES_IV.TabIndex = 4;
            // 
            // tb_AES_Key
            // 
            this.tb_AES_Key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_Key.ForeColor = System.Drawing.Color.White;
            this.tb_AES_Key.Location = new System.Drawing.Point(311, 30);
            this.tb_AES_Key.Multiline = true;
            this.tb_AES_Key.Name = "tb_AES_Key";
            this.tb_AES_Key.ReadOnly = true;
            this.tb_AES_Key.Size = new System.Drawing.Size(686, 103);
            this.tb_AES_Key.TabIndex = 5;
            // 
            // tb_AES_EncryptedMessage
            // 
            this.tb_AES_EncryptedMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_EncryptedMessage.ForeColor = System.Drawing.Color.White;
            this.tb_AES_EncryptedMessage.Location = new System.Drawing.Point(311, 275);
            this.tb_AES_EncryptedMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tb_AES_EncryptedMessage.Multiline = true;
            this.tb_AES_EncryptedMessage.Name = "tb_AES_EncryptedMessage";
            this.tb_AES_EncryptedMessage.Size = new System.Drawing.Size(686, 187);
            this.tb_AES_EncryptedMessage.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 279);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Encrypted Message:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 474);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Decrypted Message:";
            // 
            // tb_AES_DecryptedMessage
            // 
            this.tb_AES_DecryptedMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_DecryptedMessage.ForeColor = System.Drawing.Color.White;
            this.tb_AES_DecryptedMessage.Location = new System.Drawing.Point(311, 470);
            this.tb_AES_DecryptedMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tb_AES_DecryptedMessage.Multiline = true;
            this.tb_AES_DecryptedMessage.Name = "tb_AES_DecryptedMessage";
            this.tb_AES_DecryptedMessage.Size = new System.Drawing.Size(686, 92);
            this.tb_AES_DecryptedMessage.TabIndex = 8;
            // 
            // btn_AES_Encrypt
            // 
            this.btn_AES_Encrypt.Location = new System.Drawing.Point(755, 570);
            this.btn_AES_Encrypt.Name = "btn_AES_Encrypt";
            this.btn_AES_Encrypt.Size = new System.Drawing.Size(102, 35);
            this.btn_AES_Encrypt.TabIndex = 10;
            this.btn_AES_Encrypt.Text = "Encrypt";
            this.btn_AES_Encrypt.UseVisualStyleBackColor = true;
            this.btn_AES_Encrypt.Click += new System.EventHandler(this.btn_AES_Encrypt_Click);
            // 
            // btn_AES_Decrypt
            // 
            this.btn_AES_Decrypt.Location = new System.Drawing.Point(863, 570);
            this.btn_AES_Decrypt.Name = "btn_AES_Decrypt";
            this.btn_AES_Decrypt.Size = new System.Drawing.Size(102, 35);
            this.btn_AES_Decrypt.TabIndex = 11;
            this.btn_AES_Decrypt.Text = "Decrypt";
            this.btn_AES_Decrypt.UseVisualStyleBackColor = true;
            this.btn_AES_Decrypt.Click += new System.EventHandler(this.btn_AES_Decrypt_Click);
            // 
            // btn_AES_GenerateKey
            // 
            this.btn_AES_GenerateKey.Location = new System.Drawing.Point(461, 571);
            this.btn_AES_GenerateKey.Name = "btn_AES_GenerateKey";
            this.btn_AES_GenerateKey.Size = new System.Drawing.Size(141, 35);
            this.btn_AES_GenerateKey.TabIndex = 12;
            this.btn_AES_GenerateKey.Text = "Generate Key";
            this.btn_AES_GenerateKey.UseVisualStyleBackColor = true;
            this.btn_AES_GenerateKey.Click += new System.EventHandler(this.btn_AES_GenerateKey_Click);
            // 
            // btn_AES_GenerateIV
            // 
            this.btn_AES_GenerateIV.Location = new System.Drawing.Point(608, 570);
            this.btn_AES_GenerateIV.Name = "btn_AES_GenerateIV";
            this.btn_AES_GenerateIV.Size = new System.Drawing.Size(141, 35);
            this.btn_AES_GenerateIV.TabIndex = 13;
            this.btn_AES_GenerateIV.Text = "Generate IV";
            this.btn_AES_GenerateIV.UseVisualStyleBackColor = true;
            this.btn_AES_GenerateIV.Click += new System.EventHandler(this.btn_AES_GenerateIV_Click);
            // 
            // frmAESEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1029, 675);
            this.Controls.Add(this.btn_AES_GenerateIV);
            this.Controls.Add(this.btn_AES_GenerateKey);
            this.Controls.Add(this.btn_AES_Decrypt);
            this.Controls.Add(this.btn_AES_Encrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_AES_DecryptedMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_AES_EncryptedMessage);
            this.Controls.Add(this.tb_AES_Key);
            this.Controls.Add(this.tb_AES_IV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_AES_Message);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAESEncryption";
            this.Text = "AES Encryption";
            this.Load += new System.EventHandler(this.frmAESEncryption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_AES_Message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AES_IV;
        private System.Windows.Forms.TextBox tb_AES_Key;
        private System.Windows.Forms.TextBox tb_AES_EncryptedMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_AES_DecryptedMessage;
        private System.Windows.Forms.Button btn_AES_Encrypt;
        private System.Windows.Forms.Button btn_AES_Decrypt;
        private System.Windows.Forms.Button btn_AES_GenerateKey;
        private System.Windows.Forms.Button btn_AES_GenerateIV;
    }
}