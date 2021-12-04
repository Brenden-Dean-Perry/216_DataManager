
namespace DataManager_216
{
    partial class frmLogin
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
            this.btn_Login_Login = new System.Windows.Forms.Button();
            this.btn_Login_Clear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_Login_Password = new System.Windows.Forms.TextBox();
            this.tb_Login_UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Login_Login
            // 
            this.btn_Login_Login.Location = new System.Drawing.Point(245, 95);
            this.btn_Login_Login.Name = "btn_Login_Login";
            this.btn_Login_Login.Size = new System.Drawing.Size(75, 30);
            this.btn_Login_Login.TabIndex = 0;
            this.btn_Login_Login.Text = "Login";
            this.btn_Login_Login.UseVisualStyleBackColor = true;
            this.btn_Login_Login.Click += new System.EventHandler(this.btn_Login_Login_Click);
            // 
            // btn_Login_Clear
            // 
            this.btn_Login_Clear.Location = new System.Drawing.Point(326, 95);
            this.btn_Login_Clear.Name = "btn_Login_Clear";
            this.btn_Login_Clear.Size = new System.Drawing.Size(75, 30);
            this.btn_Login_Clear.TabIndex = 1;
            this.btn_Login_Clear.Text = "Clear";
            this.btn_Login_Clear.UseVisualStyleBackColor = true;
            this.btn_Login_Clear.Click += new System.EventHandler(this.btn_Login_Clear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_Login_Password);
            this.panel1.Controls.Add(this.tb_Login_UserName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Login_Login);
            this.panel1.Controls.Add(this.btn_Login_Clear);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 146);
            this.panel1.TabIndex = 2;
            // 
            // tb_Login_Password
            // 
            this.tb_Login_Password.Location = new System.Drawing.Point(136, 57);
            this.tb_Login_Password.Name = "tb_Login_Password";
            this.tb_Login_Password.Size = new System.Drawing.Size(265, 22);
            this.tb_Login_Password.TabIndex = 5;
            // 
            // tb_Login_UserName
            // 
            this.tb_Login_UserName.Location = new System.Drawing.Point(136, 29);
            this.tb_Login_UserName.Name = "tb_Login_UserName";
            this.tb_Login_UserName.Size = new System.Drawing.Size(265, 22);
            this.tb_Login_UserName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 171);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(450, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip_Login";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(450, 193);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Login_Login;
        private System.Windows.Forms.Button btn_Login_Clear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_Login_Password;
        private System.Windows.Forms.TextBox tb_Login_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}