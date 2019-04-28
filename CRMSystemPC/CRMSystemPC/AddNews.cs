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
    public partial class AddNews : MetroForm
    {
        private MainForm mainForm;
        string theHead;
        string theContent;
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        public AddNews()
        {
            InitializeComponent();
        }
        //添加一个构造函数
        public AddNews(MainForm form) : this()
        {
            mainForm = form;
        }

        private void Button_4AddNews_Click(object sender, EventArgs e)
        {
            string theClass = mainForm.TheClass();//级别
            string thePost = null ;
            if(theClass=="1")
            {
                thePost = "管理员";
            }
            else if(theClass=="2")
            {
                thePost="总经理";
            }
            int theId = mainForm.TheId();//登录Id
            DateTime theNewsDate = DateTime_4NewsDateTime.Value;//时间
            string theTheme = ComboBox_4Theme.SelectedItem.ToString();//主题
           
            if(TextBox_4Content.Text==null || TextBox_4HeadLine.Text==null)
            {
                MessageBox.Show("消息内容填写不完整！");
            }
            else
            {
                //连接数据库
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.AddNewsInfo(theId, thePost, theNewsDate.ToString(), theTheme,theHead, theContent);
                if (theResult == true)
                {
                    //调用呈现消息列表的函数
                    mainForm.UpdateNewsInfoList();
                    MessageBox.Show("发布成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("发布失败！");
                    this.Close();
                }

            }
        }

        private void AddNews_Load(object sender, EventArgs e)
        {
            ComboBox_4Theme.SelectedIndex = 0;//设置默认选项
        }

        private void TextBox_4HeadLine_Leave(object sender, EventArgs e)
        {

            Regex P_regex = new Regex("^[\u4e00-\u9fa5_a-zA-Z0-9]+$");
            if(P_regex.IsMatch(TextBox_4HeadLine.Text))
            {
                if(TextBox_4HeadLine.Text.Length>=1 && TextBox_4HeadLine.Text.Length<=15)
                {
                    theHead = TextBox_4HeadLine.Text;
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

        private void TextBox_4Content_Leave(object sender, EventArgs e)
        {
            Regex P_regex = new Regex(@"[\u4e00-\u9fa5]|[\（\）\《\》\——\；\，\。\“\”\<\>\！]");
            if (P_regex.IsMatch(TextBox_4Content.Text))
            {
                if (TextBox_4Content.Text.Length >= 1 && TextBox_4Content.Text.Length <= 50)
                {
                    theContent = TextBox_4Content.Text;
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
