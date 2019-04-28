namespace CRMSystemPC
{
    partial class ViewContract
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
            this.pictureBox_Contract = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Label_2Time = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.Label_2ClientName = new MetroFramework.Controls.MetroLabel();
            this.Button_2Confirm = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Contract)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Contract
            // 
            this.pictureBox_Contract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Contract.Location = new System.Drawing.Point(48, 129);
            this.pictureBox_Contract.Name = "pictureBox_Contract";
            this.pictureBox_Contract.Size = new System.Drawing.Size(263, 273);
            this.pictureBox_Contract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Contract.TabIndex = 0;
            this.pictureBox_Contract.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(48, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "上传时间";
            // 
            // Label_2Time
            // 
            this.Label_2Time.AutoSize = true;
            this.Label_2Time.Location = new System.Drawing.Point(140, 93);
            this.Label_2Time.Name = "Label_2Time";
            this.Label_2Time.Size = new System.Drawing.Size(0, 0);
            this.Label_2Time.TabIndex = 2;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(48, 64);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(65, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "客户姓名";
            // 
            // Label_2ClientName
            // 
            this.Label_2ClientName.AutoSize = true;
            this.Label_2ClientName.Location = new System.Drawing.Point(140, 64);
            this.Label_2ClientName.Name = "Label_2ClientName";
            this.Label_2ClientName.Size = new System.Drawing.Size(0, 0);
            this.Label_2ClientName.TabIndex = 4;
            // 
            // Button_2Confirm
            // 
            this.Button_2Confirm.Location = new System.Drawing.Point(89, 438);
            this.Button_2Confirm.Name = "Button_2Confirm";
            this.Button_2Confirm.Size = new System.Drawing.Size(158, 23);
            this.Button_2Confirm.TabIndex = 5;
            this.Button_2Confirm.Text = "确认";
            this.Button_2Confirm.UseSelectable = true;
            this.Button_2Confirm.Click += new System.EventHandler(this.Button_2Confirm_Click);
            // 
            // ViewContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 484);
            this.Controls.Add(this.Button_2Confirm);
            this.Controls.Add(this.Label_2ClientName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.Label_2Time);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox_Contract);
            this.Name = "ViewContract";
            this.Text = "查看合同照片";
            this.Load += new System.EventHandler(this.ViewContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Contract)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Contract;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel Label_2Time;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel Label_2ClientName;
        private MetroFramework.Controls.MetroButton Button_2Confirm;
    }
}