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
    public partial class AlterNews : MetroForm
    {
        private MainForm mainForm;
        int theId;
        DateTime theDate;
        string theHead;
        string theTheme;
        string theContent;
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        public AlterNews()
        {
            InitializeComponent();
        }
        //添加一个构造函数
        public AlterNews(MainForm form) : this()
        {
            mainForm = form;
        }

        private void AlterNews_Load(object sender, EventArgs e)
        {
            string[] theNewsInfo = null;
            theNewsInfo=mainForm.SendNewsInfo();
            for(int i=0;i<theNewsInfo.Length;)
            {
                int.TryParse(theNewsInfo[i], out theId);
                Label_4AlterDate.Text = theNewsInfo[i+1];
                DateTime.TryParse(theNewsInfo[i + 1], out theDate);
                theTheme = theNewsInfo[i + 2];
                TextBox_4AlterHead.Text = theNewsInfo[i + 3];
                TextBox_4AlterContent.Text = theNewsInfo[i + 4];
                i = i + 5;
            }
            for(int j=0;j< ComboBox_4AlterTheme.Items.Count;j++)
            {
                if(ComboBox_4AlterTheme.GetItemText(ComboBox_4AlterTheme.Items[j])== theTheme)
                {
                    ComboBox_4AlterTheme.SelectedItem = theTheme;
                }
            }
            
            theContent = TextBox_4AlterContent.Text;
            theHead = TextBox_4AlterHead.Text;
        }

        //更新签单
        private void Button_4AlterNews_Click(object sender, EventArgs e)
        {
            if(theContent==null||theHead==null)
            {
                MessageBox.Show("填写内容为空！请填写！");
            }
            else
            {
                theTheme = ComboBox_4AlterTheme.SelectedItem.ToString();

                //连接数据库
                if (theContent != null)
                {
                    myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                    bool theResult = myWebService.UpdateNewsInfo(theId, theDate.ToString(), theTheme,theHead, theContent);
                    if (theResult == true)
                    {
                        MessageBox.Show("更新成功！");
                        mainForm.UpdateNewsInfoList();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("更新失败！");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("内容不能为空！");
                }
            }
            
        }

        private void TextBox_4AlterHead_Leave(object sender, EventArgs e)
        {
            Regex P_regex = new Regex("^[\u4e00-\u9fa5_a-zA-Z0-9]+$");
            if (P_regex.IsMatch(TextBox_4AlterHead.Text))
            {
                if (TextBox_4AlterHead.Text.Length >= 1 && TextBox_4AlterHead.Text.Length <= 15)
                {
                    theHead = TextBox_4AlterHead.Text;
                }
                else
                {
                    MessageBox.Show("标题过长，请重新填写！");
                }
            }
            else
            {
                MessageBox.Show("填写含有非法字符,请重新填写！");
            }
        }

        private void TextBox_4AlterContent_Leave(object sender, EventArgs e)
        {
            Regex P_regex = new Regex(@"[\u4e00-\u9fa5]|[\（\）\《\》\——\；\，\。\“\”\<\>\！]");
            if (P_regex.IsMatch(TextBox_4AlterContent.Text))
            {
                if (TextBox_4AlterContent.Text.Length >= 1 && TextBox_4AlterContent.Text.Length <= 50)
                {
                    theContent = TextBox_4AlterContent.Text;
                }
                else
                {
                    MessageBox.Show("内容过长，不能超过50字符！");
                }
            }
            else
            {
                MessageBox.Show("填写含有非法字符,请重新填写！");
            }
        }
    }
}
