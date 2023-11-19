
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
            this.btn_RSA_LoadKeys = new System.Windows.Forms.Button();
            this.tb_RSA_Message = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_RSA_CipherText = new System.Windows.Forms.TextBox();
            this.tb_RSA_DecryptedMessage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_RSA_Encrypt = new System.Windows.Forms.Button();
            this.btn_RSA_Decrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_RSA_GenerateKeys
            // 
            this.btn_RSA_GenerateKeys.Location = new System.Drawing.Point(1750, 1672);
            this.btn_RSA_GenerateKeys.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_RSA_GenerateKeys.Name = "btn_RSA_GenerateKeys";
            this.btn_RSA_GenerateKeys.Size = new System.Drawing.Size(276, 72);
            this.btn_RSA_GenerateKeys.TabIndex = 0;
            this.btn_RSA_GenerateKeys.Text = "Generate Keys";
            this.btn_RSA_GenerateKeys.UseVisualStyleBackColor = true;
            this.btn_RSA_GenerateKeys.Click += new System.EventHandler(this.btn_RSA_GenerateKeys_Click);
            // 
            // tb_RSA_PublicKey
            // 
            this.tb_RSA_PublicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_PublicKey.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_PublicKey.Location = new System.Drawing.Point(446, 81);
            this.tb_RSA_PublicKey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tb_RSA_PublicKey.Multiline = true;
            this.tb_RSA_PublicKey.Name = "tb_RSA_PublicKey";
            this.tb_RSA_PublicKey.Size = new System.Drawing.Size(2466, 461);
            this.tb_RSA_PublicKey.TabIndex = 1;
            // 
            // tb_RSA_PrivateKey
            // 
            this.tb_RSA_PrivateKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_PrivateKey.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_PrivateKey.Location = new System.Drawing.Point(446, 581);
            this.tb_RSA_PrivateKey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tb_RSA_PrivateKey.Multiline = true;
            this.tb_RSA_PrivateKey.Name = "tb_RSA_PrivateKey";
            this.tb_RSA_PrivateKey.Size = new System.Drawing.Size(2466, 461);
            this.tb_RSA_PrivateKey.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(52, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Public Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 608);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "Private Key:";
            // 
            // btn_RSA_LoadKeys
            // 
            this.btn_RSA_LoadKeys.Location = new System.Drawing.Point(2038, 1672);
            this.btn_RSA_LoadKeys.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_RSA_LoadKeys.Name = "btn_RSA_LoadKeys";
            this.btn_RSA_LoadKeys.Size = new System.Drawing.Size(276, 72);
            this.btn_RSA_LoadKeys.TabIndex = 6;
            this.btn_RSA_LoadKeys.Text = "Load Keys";
            this.btn_RSA_LoadKeys.UseVisualStyleBackColor = true;
            this.btn_RSA_LoadKeys.Click += new System.EventHandler(this.btn_RSA_LoadKeys_Click);
            // 
            // tb_RSA_Message
            // 
            this.tb_RSA_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_Message.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_Message.Location = new System.Drawing.Point(446, 1058);
            this.tb_RSA_Message.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tb_RSA_Message.Multiline = true;
            this.tb_RSA_Message.Name = "tb_RSA_Message";
            this.tb_RSA_Message.Size = new System.Drawing.Size(2466, 169);
            this.tb_RSA_Message.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 1077);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 40);
            this.label2.TabIndex = 8;
            this.label2.Text = "Message:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(52, 1261);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 40);
            this.label4.TabIndex = 10;
            this.label4.Text = "Encrypted Message:";
            // 
            // tb_RSA_CipherText
            // 
            this.tb_RSA_CipherText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_CipherText.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_CipherText.Location = new System.Drawing.Point(446, 1242);
            this.tb_RSA_CipherText.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tb_RSA_CipherText.Multiline = true;
            this.tb_RSA_CipherText.Name = "tb_RSA_CipherText";
            this.tb_RSA_CipherText.Size = new System.Drawing.Size(2466, 169);
            this.tb_RSA_CipherText.TabIndex = 9;
            // 
            // tb_RSA_DecryptedMessage
            // 
            this.tb_RSA_DecryptedMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_RSA_DecryptedMessage.ForeColor = System.Drawing.Color.White;
            this.tb_RSA_DecryptedMessage.Location = new System.Drawing.Point(446, 1426);
            this.tb_RSA_DecryptedMessage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tb_RSA_DecryptedMessage.Multiline = true;
            this.tb_RSA_DecryptedMessage.Name = "tb_RSA_DecryptedMessage";
            this.tb_RSA_DecryptedMessage.Size = new System.Drawing.Size(2466, 169);
            this.tb_RSA_DecryptedMessage.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(52, 1428);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 40);
            this.label5.TabIndex = 12;
            this.label5.Text = "Decrypted Message:";
            // 
            // btn_RSA_Encrypt
            // 
            this.btn_RSA_Encrypt.Location = new System.Drawing.Point(2326, 1672);
            this.btn_RSA_Encrypt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_RSA_Encrypt.Name = "btn_RSA_Encrypt";
            this.btn_RSA_Encrypt.Size = new System.Drawing.Size(276, 72);
            this.btn_RSA_Encrypt.TabIndex = 13;
            this.btn_RSA_Encrypt.Text = "Encrypt";
            this.btn_RSA_Encrypt.UseVisualStyleBackColor = true;
            this.btn_RSA_Encrypt.Click += new System.EventHandler(this.btn_RSA_Encrypt_Click);
            // 
            // btn_RSA_Decrypt
            // 
            this.btn_RSA_Decrypt.Location = new System.Drawing.Point(2614, 1672);
            this.btn_RSA_Decrypt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_RSA_Decrypt.Name = "btn_RSA_Decrypt";
            this.btn_RSA_Decrypt.Size = new System.Drawing.Size(276, 72);
            this.btn_RSA_Decrypt.TabIndex = 14;
            this.btn_RSA_Decrypt.Text = "Decrypt";
            this.btn_RSA_Decrypt.UseVisualStyleBackColor = true;
            this.btn_RSA_Decrypt.Click += new System.EventHandler(this.btn_RSA_Decrypt_Click);
            // 
            // frmRSAEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(2960, 1810);
            this.Controls.Add(this.btn_RSA_Decrypt);
            this.Controls.Add(this.btn_RSA_Encrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_RSA_DecryptedMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_RSA_CipherText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_RSA_Message);
            this.Controls.Add(this.btn_RSA_LoadKeys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_RSA_PrivateKey);
            this.Controls.Add(this.tb_RSA_PublicKey);
            this.Controls.Add(this.btn_RSA_GenerateKeys);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmRSAEncryption";
            this.Text = "RSAEncryption";
            this.Load += new System.EventHandler(this.frmRSAEncryption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RSA_GenerateKeys;
        private System.Windows.Forms.TextBox tb_RSA_PublicKey;
        private System.Windows.Forms.TextBox tb_RSA_PrivateKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RSA_LoadKeys;
        private System.Windows.Forms.TextBox tb_RSA_Message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_RSA_CipherText;
        private System.Windows.Forms.TextBox tb_RSA_DecryptedMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_RSA_Encrypt;
        private System.Windows.Forms.Button btn_RSA_Decrypt;
    }
}