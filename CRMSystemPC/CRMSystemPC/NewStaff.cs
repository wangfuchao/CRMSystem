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
using MetroFramework.Forms;

namespace CRMSystemPC
{
    public partial class NewStaff : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        private MainForm mainForm;
        int theId;
        string theName;
        string thePhone;
        public NewStaff()
        {
            InitializeComponent();
            

        }
        //添加一个构造函数
        public NewStaff(MainForm form) : this()
        {
            mainForm = form;
        }

        private void NewStaff_Load(object sender, EventArgs e)
        {
            theId = mainForm.TheMaxId();
            Label_StaffId.Text = (theId+1).ToString();
            //添加Comboox的列表项
            string[] theList= mainForm.theCombox();
            for(int i=0;i<theList.Length;i++)
            {
                CBox_AddZone.Items.Add(theList[i]);
            }
            CBox_AddZone.SelectedIndex = 0;

        }
        private void Button_AddNewStaff_Click(object sender, EventArgs e)
        {
            if(TextBox_StaffName==null ||TextBox_Phone==null )
            {
                MessageBox.Show("信息填写不完整！");
            }
            else
            {
               
                int UserId = theId+1;
                string Password = "12345678";
                int Class = 3;
                string Distinct = CBox_AddZone.SelectedItem.ToString();
                string Name = theName;
                string Phone = thePhone;

                //插入数据进入数据库中
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.AddStaff(Password, Class, Distinct, Name, Phone);
                //更新listview数据
                //更新tree数据
                if (theResult==true)
                {
                    mainForm.AddTreeNode(Distinct, UserId.ToString() + Name);
                    mainForm.StaffManageStaffData();
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败！");
                    this.Close();
                }
               
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
                if(TextBox_StaffName.Text.Length<=5 && TextBox_StaffName.Text.Length>=1)
                {
                    theName = TextBox_StaffName.Text;
                }
                else
                {
                    MessageBox.Show("您填写的姓名字符过长！");
                }
            }

        }

        private void TextBox_Phone_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox_Phone.Text, @"^(0|86|17951)?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$"))
            {
                MessageBox.Show("您填写的手机号不符合规范！");
            }
            else
            {
                thePhone = TextBox_Phone.Text;
            }
        }
    }
}
