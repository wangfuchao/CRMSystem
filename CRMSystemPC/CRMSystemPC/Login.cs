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
    public partial class Login : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null;
        public Login()
        {
            InitializeComponent();
            Password.UseSystemPasswordChar = true;
        }

        private void User_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            Regex checkId = new Regex("^\\d{6}$");
            bool ismatch = checkId.IsMatch(UserId.Text);
            if (ismatch == false)
            {
                MessageBox.Show("抱歉，用户名或者密码错误！");
            }
            else
            {
                Regex checkPassword = new Regex("^\\d{8}$");
                bool theResults = checkPassword.IsMatch(Password.Text);
                if (theResults == false)
                {
                    MessageBox.Show("抱歉，用户名或者密码错误！");
                }
                else
                {
                    int theId;
                    int.TryParse(UserId.Text, out theId);
                    string thePassword;
                    thePassword = Password.Text;
                    myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");

                    string[] theUserCheck = myWebService.UserCheck(theId, thePassword).ToArray();

                    if (theUserCheck.Length != 0)
                    {
                        if (theUserCheck[0] == "1" || theUserCheck[0] == "2")
                        {
                            //MessageBox.Show("登录成功");
                            Form newForm = new MainForm(theUserCheck[0], theId);
                            newForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("抱歉，用户名或密码错误，登录失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("抱歉，用户名或密码错误，登录失败！");
                    }
                }
            }
        }
    }
}
