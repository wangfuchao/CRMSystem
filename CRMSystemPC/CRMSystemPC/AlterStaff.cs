using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMSystemPC
{
    public partial class AlterStaff : MetroForm
    {
        private MainForm mainForm;
        string theName;
        string thePassword;
        string thePhone;
        string theArea;
        string theOldArea;
        string theOldName;
        string theOldId;
        int theId;
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        public AlterStaff()
        {
            InitializeComponent();
        }
        //添加一个构造函数
        public AlterStaff(MainForm form) : this()
        {
            mainForm = form;
        }

        private void AlterStaff_Load(object sender, EventArgs e)
        {
            string[] theList = mainForm.theCombox();
            for (int j = 0; j < theList.Length; j++)
            {
                CBox_AddZone.Items.Add(theList[j]);
            }
            CBox_AddZone.SelectedIndex = 0;
            string[] theStaffInfo = mainForm.GetStaffInfo();

            int i = 0;
            Label_StaffId.Text = theStaffInfo[i];
            theOldId= theStaffInfo[i];
            int.TryParse(theStaffInfo[i], out theId);
            TextBox_StaffName.Text = theStaffInfo[i + 1];
            theName = TextBox_StaffName.Text;
            theOldName= theStaffInfo[i + 1];
            TextBox_StaffPhone.Text = theStaffInfo[i + 2];
            theOldArea = theStaffInfo[i + 3];

            int index = this.CBox_AddZone.FindString(theOldArea);
            this.CBox_AddZone.SelectedIndex = index;

            TextBox_Password.Text = "12345678";
            TextBox_Password.UseSystemPasswordChar = true;
            thePassword = TextBox_Password.Text;//密码有问题
        }

        private void Button_AlterStaff_Click(object sender, EventArgs e)
        {
            if (TextBox_Password == null|| TextBox_StaffName == null || TextBox_StaffPhone == null)
            {
                MessageBox.Show("信息填写不完整！");
            }
            else
            {
                theArea = CBox_AddZone.SelectedItem.ToString();
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.UpdateStaff(theId, thePassword, theArea, theName, thePhone);
                if (theResult == true)
                {
                    //删除节点
                    mainForm.AlterTreeNode(theOldArea,theOldId+theOldName);
                    //增加节点
                    mainForm.AddTreeNode(theArea, theId.ToString() + theName);
                    //更新listview
                    mainForm.StaffManageStaffData();
                    //调用方法，更新树节点
                    //更新listview
                    MessageBox.Show("修改员工信息成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改员工信息失败！");
                    this.Close();
                }
            }
        }

        private void TextBox_Password_Leave(object sender, EventArgs e)
        {
            //正则表达式，只能输入8位数字
            if (!Regex.IsMatch(TextBox_Password.Text, @"^\d{8}$"))
            {
                MessageBox.Show("您填写的密码不符合8位数字的要求");
            }
            else
            {
                thePassword = TextBox_Password.Text;
            }
        }

        private void TextBox_StaffName_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox_StaffName.Text, @"^[\u4e00-\u9fa5]+$"))
            {
                MessageBox.Show("您填写的姓名含有非中文字符！");
            }
            else
            {
                if (TextBox_StaffName.Text.Length <= 5 && TextBox_StaffName.Text.Length >= 1)
                {
                    theName = TextBox_StaffName.Text;
                }
                else
                {
                    MessageBox.Show("您填写的姓名字符过长！");
                }
            }
        }

        private void TextBox_StaffPhone_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox_StaffPhone.Text, @"^(0|86|17951)?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$"))
            {
                MessageBox.Show("您填写的手机号不符合规范！");
            }
            else
            {
                thePhone = TextBox_StaffPhone.Text;
            }
        }
    }
}
