namespace CRMSystemPC
{
    partial class ShowIndex
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
            this.Label_3ShowContract = new MetroFramework.Controls.MetroLabel();
            this.Label_3ShowProject = new MetroFramework.Controls.MetroLabel();
            this.Label_3ShowOrder = new MetroFramework.Controls.MetroLabel();
            this.Button_3IndexConfirm = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ComboBox_3Month = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_3ShowContract);
            this.groupBox1.Controls.Add(this.Label_3ShowProject);
            this.groupBox1.Controls.Add(this.Label_3ShowOrder);
            this.groupBox1.Controls.Add(this.Button_3IndexConfirm);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.ComboBox_3Month);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(54, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 354);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看业务指标";
            // 
            // Label_3ShowContract
            // 
            this.Label_3ShowContract.AutoSize = true;
            this.Label_3ShowContract.Location = new System.Drawing.Point(97, 185);
            this.Label_3ShowContract.Name = "Label_3ShowContract";
            this.Label_3ShowContract.Size = new System.Drawing.Size(0, 0);
            this.Label_3ShowContract.TabIndex = 21;
            // 
            // Label_3ShowProject
            // 
            this.Label_3ShowProject.AutoSize = true;
            this.Label_3ShowProject.Location = new System.Drawing.Point(96, 139);
            this.Label_3ShowProject.Name = "Label_3ShowProject";
            this.Label_3ShowProject.Size = new System.Drawing.Size(0, 0);
            this.Label_3ShowProject.TabIndex = 20;
            // 
            // Label_3ShowOrder
            // 
            this.Label_3ShowOrder.AutoSize = true;
            this.Label_3ShowOrder.Location = new System.Drawing.Point(97, 91);
            this.Label_3ShowOrder.Name = "Label_3ShowOrder";
            this.Label_3ShowOrder.Size = new System.Drawing.Size(0, 0);
            this.Label_3ShowOrder.TabIndex = 19;
            // 
            // Button_3IndexConfirm
            // 
            this.Button_3IndexConfirm.Location = new System.Drawing.Point(26, 261);
            this.Button_3IndexConfirm.Name = "Button_3IndexConfirm";
            this.Button_3IndexConfirm.Size = new System.Drawing.Size(192, 23);
            this.Button_3IndexConfirm.TabIndex = 18;
            this.Button_3IndexConfirm.Text = "确认";
            this.Button_3IndexConfirm.UseSelectable = true;
            this.Button_3IndexConfirm.Click += new System.EventHandler(this.Button_3IndexConfirm_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(25, 185);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(65, 19);
            this.metroLabel4.TabIndex = 16;
            this.metroLabel4.Text = "合同数量";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(25, 139);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(65, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "工单数量";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(25, 92);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "订单数量";
            // 
            // ComboBox_3Month
            // 
            this.ComboBox_3Month.FormattingEnabled = true;
            this.ComboBox_3Month.ItemHeight = 23;
            this.ComboBox_3Month.Items.AddRange(new object[] {
            "一月",
            "二月",
            "三月",
            "四月",
            "五月",
            "六月",
            "七月",
            "八月",
            "九月",
            "十月",
            "十一月",
            "十二月"});
            this.ComboBox_3Month.Location = new System.Drawing.Point(97, 36);
            this.ComboBox_3Month.Name = "ComboBox_3Month";
            this.ComboBox_3Month.Size = new System.Drawing.Size(121, 29);
            this.ComboBox_3Month.TabIndex = 11;
            this.ComboBox_3Month.UseSelectable = true;
            this.ComboBox_3Month.SelectedIndexChanged += new System.EventHandler(this.ComboBox_3Month_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(26, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "选择月份";
            // 
            // ShowIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 454);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShowIndex";
            this.Text = "查看业务指标";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton Button_3IndexConfirm;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ComboBox_3Month;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel Label_3ShowContract;
        private MetroFramework.Controls.MetroLabel Label_3ShowProject;
        private MetroFramework.Controls.MetroLabel Label_3ShowOrder;
    }
}