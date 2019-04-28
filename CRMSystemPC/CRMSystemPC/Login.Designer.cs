namespace CRMSystemPC
{
    partial class Login
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.UserId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.Password = new MetroFramework.Controls.MetroTextBox();
            this.BtLogin = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(125, 187);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(37, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "工号";
            // 
            // UserId
            // 
            // 
            // 
            // 
            this.UserId.CustomButton.Image = null;
            this.UserId.CustomButton.Location = new System.Drawing.Point(84, 1);
            this.UserId.CustomButton.Name = "";
            this.UserId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.UserId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserId.CustomButton.TabIndex = 1;
            this.UserId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UserId.CustomButton.UseSelectable = true;
            this.UserId.CustomButton.Visible = false;
            this.UserId.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.UserId.Lines = new string[0];
            this.UserId.Location = new System.Drawing.Point(168, 187);
            this.UserId.MaxLength = 32767;
            this.UserId.Name = "UserId";
            this.UserId.PasswordChar = '\0';
            this.UserId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserId.SelectedText = "";
            this.UserId.SelectionLength = 0;
            this.UserId.SelectionStart = 0;
            this.UserId.ShortcutsEnabled = true;
            this.UserId.Size = new System.Drawing.Size(106, 23);
            this.UserId.TabIndex = 1;
            this.UserId.UseSelectable = true;
            this.UserId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UserId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.UserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.User_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(125, 231);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(37, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "密码";
            // 
            // Password
            // 
            // 
            // 
            // 
            this.Password.CustomButton.Image = null;
            this.Password.CustomButton.Location = new System.Drawing.Point(84, 1);
            this.Password.CustomButton.Name = "";
            this.Password.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Password.CustomButton.TabIndex = 1;
            this.Password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Password.CustomButton.UseSelectable = true;
            this.Password.CustomButton.Visible = false;
            this.Password.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.Password.Lines = new string[0];
            this.Password.Location = new System.Drawing.Point(168, 231);
            this.Password.MaxLength = 32767;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '\0';
            this.Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Password.SelectedText = "";
            this.Password.SelectionLength = 0;
            this.Password.SelectionStart = 0;
            this.Password.ShortcutsEnabled = true;
            this.Password.Size = new System.Drawing.Size(106, 23);
            this.Password.TabIndex = 3;
            this.Password.UseSelectable = true;
            this.Password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BtLogin
            // 
            this.BtLogin.Location = new System.Drawing.Point(125, 295);
            this.BtLogin.Name = "BtLogin";
            this.BtLogin.Size = new System.Drawing.Size(149, 23);
            this.BtLogin.TabIndex = 4;
            this.BtLogin.Text = "登录";
            this.BtLogin.UseSelectable = true;
            this.BtLogin.Click += new System.EventHandler(this.BtLogin_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(67, 82);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(299, 25);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "成都寰宝建设客户关系管理系统 V1.0";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 420);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.BtLogin);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Login";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox UserId;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox Password;
        private MetroFramework.Controls.MetroButton BtLogin;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}