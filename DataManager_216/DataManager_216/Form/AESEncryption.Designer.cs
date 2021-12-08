
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
            this.tb_AES_InitalValue = new System.Windows.Forms.TextBox();
            this.tb_AES_Key = new System.Windows.Forms.TextBox();
            this.tb_AES_EncryptedMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_AES_DecryptedMessage = new System.Windows.Forms.TextBox();
            this.btn_AES_Encrypt = new System.Windows.Forms.Button();
            this.btn_AES_Decrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_AES_Message
            // 
            this.tb_AES_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_Message.ForeColor = System.Drawing.Color.White;
            this.tb_AES_Message.Location = new System.Drawing.Point(183, 97);
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
            this.label1.Location = new System.Drawing.Point(30, 101);
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
            this.label2.Location = new System.Drawing.Point(30, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initial Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(30, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Key:";
            // 
            // tb_AES_InitalValue
            // 
            this.tb_AES_InitalValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_InitalValue.ForeColor = System.Drawing.Color.White;
            this.tb_AES_InitalValue.Location = new System.Drawing.Point(183, 63);
            this.tb_AES_InitalValue.Name = "tb_AES_InitalValue";
            this.tb_AES_InitalValue.Size = new System.Drawing.Size(686, 27);
            this.tb_AES_InitalValue.TabIndex = 4;
            // 
            // tb_AES_Key
            // 
            this.tb_AES_Key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_Key.ForeColor = System.Drawing.Color.White;
            this.tb_AES_Key.Location = new System.Drawing.Point(183, 30);
            this.tb_AES_Key.Name = "tb_AES_Key";
            this.tb_AES_Key.Size = new System.Drawing.Size(686, 27);
            this.tb_AES_Key.TabIndex = 5;
            // 
            // tb_AES_EncryptedMessage
            // 
            this.tb_AES_EncryptedMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_AES_EncryptedMessage.ForeColor = System.Drawing.Color.White;
            this.tb_AES_EncryptedMessage.Location = new System.Drawing.Point(183, 197);
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
            this.label4.Location = new System.Drawing.Point(13, 201);
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
            this.label5.Location = new System.Drawing.Point(13, 396);
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
            this.tb_AES_DecryptedMessage.Location = new System.Drawing.Point(183, 392);
            this.tb_AES_DecryptedMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tb_AES_DecryptedMessage.Multiline = true;
            this.tb_AES_DecryptedMessage.Name = "tb_AES_DecryptedMessage";
            this.tb_AES_DecryptedMessage.Size = new System.Drawing.Size(686, 92);
            this.tb_AES_DecryptedMessage.TabIndex = 8;
            // 
            // btn_AES_Encrypt
            // 
            this.btn_AES_Encrypt.Location = new System.Drawing.Point(627, 492);
            this.btn_AES_Encrypt.Name = "btn_AES_Encrypt";
            this.btn_AES_Encrypt.Size = new System.Drawing.Size(102, 35);
            this.btn_AES_Encrypt.TabIndex = 10;
            this.btn_AES_Encrypt.Text = "Encrypt";
            this.btn_AES_Encrypt.UseVisualStyleBackColor = true;
            this.btn_AES_Encrypt.Click += new System.EventHandler(this.btn_AES_Encrypt_Click);
            // 
            // btn_AES_Decrypt
            // 
            this.btn_AES_Decrypt.Location = new System.Drawing.Point(735, 492);
            this.btn_AES_Decrypt.Name = "btn_AES_Decrypt";
            this.btn_AES_Decrypt.Size = new System.Drawing.Size(102, 35);
            this.btn_AES_Decrypt.TabIndex = 11;
            this.btn_AES_Decrypt.Text = "Decrypt";
            this.btn_AES_Decrypt.UseVisualStyleBackColor = true;
            // 
            // frmAESEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(892, 569);
            this.Controls.Add(this.btn_AES_Decrypt);
            this.Controls.Add(this.btn_AES_Encrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_AES_DecryptedMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_AES_EncryptedMessage);
            this.Controls.Add(this.tb_AES_Key);
            this.Controls.Add(this.tb_AES_InitalValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_AES_Message);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAESEncryption";
            this.Text = "AES Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_AES_Message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AES_InitalValue;
        private System.Windows.Forms.TextBox tb_AES_Key;
        private System.Windows.Forms.TextBox tb_AES_EncryptedMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_AES_DecryptedMessage;
        private System.Windows.Forms.Button btn_AES_Encrypt;
        private System.Windows.Forms.Button btn_AES_Decrypt;
    }
}