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
    public partial class AlterPassword : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        private MainForm mainForm;
        int theId;
        string thePassword;
        public AlterPassword()
        {
            InitializeComponent();
           
        }
        //添加一个构造函数
        public AlterPassword(MainForm form) : this()
        {
            mainForm = form;
            TextBox_AlterNewPassword.UseSystemPasswordChar = true;
            TextBox_ConfirmNewPasswword.UseSystemPasswordChar = true;
        }

        private void TextBox_AlterNewPassword_Leave(object sender, EventArgs e)
        {
            //正则表达式，只能输入8位数字
            if (!Regex.IsMatch(TextBox_AlterNewPassword.Text, @"^\d{8}$"))
            {
                MessageBox.Show("您填写的密码不符合8位数字的要求");
            }
        }

        private void TextBox_ConfirmNewPasswword_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox_ConfirmNewPasswword.Text, @"^\d{8}$"))
            {
                MessageBox.Show("您填写的密码不符合8位数字的要求");
            }
            else
            {
                if (TextBox_ConfirmNewPasswword.Text != TextBox_AlterNewPassword.Text)
                {
                    MessageBox.Show("您填写的确认密码与密码不一致");
                }
                else
                {
                    thePassword = TextBox_ConfirmNewPasswword.Text;
                }
            }
        }

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            bool theResult = myWebService.AlterTheRootPassword(theId, thePassword);
            if (theResult ==true)
            {
                MessageBox.Show("更改密码成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("更改密码失败！");
                this.Close();
            }
        }

        private void AlterPassword_Load(object sender, EventArgs e)
        {
            theId = mainForm.TheId();
        }
    }
}
