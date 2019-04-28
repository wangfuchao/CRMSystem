namespace CRMSystemPC
{
    partial class AlterStaff
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_StaffId = new MetroFramework.Controls.MetroLabel();
            this.TextBox_Password = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TextBox_StaffName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Button_AlterStaff = new MetroFramework.Controls.MetroButton();
            this.CBox_AddZone = new MetroFramework.Controls.MetroComboBox();
            this.TextBox_StaffPhone = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.Label_StaffId);
            this.groupBox1.Controls.Add(this.TextBox_Password);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.TextBox_StaffName);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.Button_AlterStaff);
            this.groupBox1.Controls.Add(this.CBox_AddZone);
            this.groupBox1.Controls.Add(this.TextBox_StaffPhone);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(36, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 320);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改信息";
            // 
            // Label_StaffId
            // 
            this.Label_StaffId.AutoSize = true;
            this.Label_StaffId.Location = new System.Drawing.Point(93, 35);
            this.Label_StaffId.Name = "Label_StaffId";
            this.Label_StaffId.Size = new System.Drawing.Size(83, 19);
            this.Label_StaffId.TabIndex = 18;
            this.Label_StaffId.Text = "metroLabel6";
            // 
            // TextBox_Password
            // 
            // 
            // 
            // 
            this.TextBox_Password.CustomButton.Image = null;
            this.TextBox_Password.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.TextBox_Password.CustomButton.Name = "";
            this.TextBox_Password.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_Password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_Password.CustomButton.TabIndex = 1;
            this.TextBox_Password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_Password.CustomButton.UseSelectable = true;
            this.TextBox_Password.CustomButton.Visible = false;
            this.TextBox_Password.Lines = new string[0];
            this.TextBox_Password.Location = new System.Drawing.Point(93, 71);
            this.TextBox_Password.MaxLength = 32767;
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.PasswordChar = '\0';
            this.TextBox_Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_Password.SelectedText = "";
            this.TextBox_Password.SelectionLength = 0;
            this.TextBox_Password.SelectionStart = 0;
            this.TextBox_Password.ShortcutsEnabled = true;
            this.TextBox_Password.Size = new System.Drawing.Size(108, 23);
            this.TextBox_Password.TabIndex = 17;
            this.TextBox_Password.UseSelectable = true;
            this.TextBox_Password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_Password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_Password.Leave += new System.EventHandler(this.TextBox_Password_Leave);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(22, 75);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(65, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "密       码";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(22, 35);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(67, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "职  工  号";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(22, 153);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(65, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "电话号码";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 196);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "工作区域";
            // 
            // TextBox_StaffName
            // 
            // 
            // 
            // 
            this.TextBox_StaffName.CustomButton.Image = null;
            this.TextBox_StaffName.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.TextBox_StaffName.CustomButton.Name = "";
            this.TextBox_StaffName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_StaffName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_StaffName.CustomButton.TabIndex = 1;
            this.TextBox_StaffName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_StaffName.CustomButton.UseSelectable = true;
            this.TextBox_StaffName.CustomButton.Visible = false;
            this.TextBox_StaffName.Lines = new string[0];
            this.TextBox_StaffName.Location = new System.Drawing.Point(93, 109);
            this.TextBox_StaffName.MaxLength = 32767;
            this.TextBox_StaffName.Name = "TextBox_StaffName";
            this.TextBox_StaffName.PasswordChar = '\0';
            this.TextBox_StaffName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_StaffName.SelectedText = "";
            this.TextBox_StaffName.SelectionLength = 0;
            this.TextBox_StaffName.SelectionStart = 0;
            this.TextBox_StaffName.ShortcutsEnabled = true;
            this.TextBox_StaffName.Size = new System.Drawing.Size(108, 23);
            this.TextBox_StaffName.TabIndex = 11;
            this.TextBox_StaffName.UseSelectable = true;
            this.TextBox_StaffName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_StaffName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_StaffName.Leave += new System.EventHandler(this.TextBox_StaffName_Leave);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 113);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "姓       名";
            // 
            // Button_AlterStaff
            // 
            this.Button_AlterStaff.Location = new System.Drawing.Point(22, 259);
            this.Button_AlterStaff.Name = "Button_AlterStaff";
            this.Button_AlterStaff.Size = new System.Drawing.Size(179, 23);
            this.Button_AlterStaff.TabIndex = 7;
            this.Button_AlterStaff.Text = "修改";
            this.Button_AlterStaff.UseSelectable = true;
            this.Button_AlterStaff.Click += new System.EventHandler(this.Button_AlterStaff_Click);
            // 
            // CBox_AddZone
            // 
            this.CBox_AddZone.FormattingEnabled = true;
            this.CBox_AddZone.ItemHeight = 23;
            this.CBox_AddZone.Location = new System.Drawing.Point(93, 196);
            this.CBox_AddZone.Name = "CBox_AddZone";
            this.CBox_AddZone.Size = new System.Drawing.Size(108, 29);
            this.CBox_AddZone.TabIndex = 6;
            this.CBox_AddZone.UseSelectable = true;
            // 
            // TextBox_StaffPhone
            // 
            // 
            // 
            // 
            this.TextBox_StaffPhone.CustomButton.Image = null;
            this.TextBox_StaffPhone.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.TextBox_StaffPhone.CustomButton.Name = "";
            this.TextBox_StaffPhone.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBox_StaffPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBox_StaffPhone.CustomButton.TabIndex = 1;
            this.TextBox_StaffPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBox_StaffPhone.CustomButton.UseSelectable = true;
            this.TextBox_StaffPhone.CustomButton.Visible = false;
            this.TextBox_StaffPhone.Lines = new string[0];
            this.TextBox_StaffPhone.Location = new System.Drawing.Point(93, 149);
            this.TextBox_StaffPhone.MaxLength = 32767;
            this.TextBox_StaffPhone.Name = "TextBox_StaffPhone";
            this.TextBox_StaffPhone.PasswordChar = '\0';
            this.TextBox_StaffPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBox_StaffPhone.SelectedText = "";
            this.TextBox_StaffPhone.SelectionLength = 0;
            this.TextBox_StaffPhone.SelectionStart = 0;
            this.TextBox_StaffPhone.ShortcutsEnabled = true;
            this.TextBox_StaffPhone.Size = new System.Drawing.Size(108, 23);
            this.TextBox_StaffPhone.TabIndex = 5;
            this.TextBox_StaffPhone.UseSelectable = true;
            this.TextBox_StaffPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBox_StaffPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextBox_StaffPhone.Leave += new System.EventHandler(this.TextBox_StaffPhone_Leave);
            // 
            // AlterStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "AlterStaff";
            this.Text = "修改信息";
            this.Load += new System.EventHandler(this.AlterStaff_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel Label_StaffId;
        private MetroFramework.Controls.MetroTextBox TextBox_Password;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TextBox_StaffName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton Button_AlterStaff;
        private MetroFramework.Controls.MetroComboBox CBox_AddZone;
        private MetroFramework.Controls.MetroTextBox TextBox_StaffPhone;
    }
}