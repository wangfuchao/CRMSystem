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
    public partial class AddIndex : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        string theMonth;
        int theId;
        int theOrderNumber;
        int theProjectNumber;
        int theContractNumber;
        private MainForm mainForm;
        public AddIndex()
        {
            InitializeComponent();
        }
        //添加一个构造函数
        public AddIndex(MainForm form) : this()
        {
            mainForm = form;
        }

        private void Button_3IndexConfirm_Click(object sender, EventArgs e)
        {
            if(theOrderNumber==0||theProjectNumber==0||theContractNumber==0)
            {
                MessageBox.Show("有未填写项，为空！请填写");
            }
            else
            {
                theId = mainForm.TheId();
                theMonth = ComboBox_3Month.SelectedItem.ToString();
                int indexMonth = this.ComboBox_3Month.FindString(theMonth);
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.AddIndex(theId, (indexMonth + 1).ToString(), theOrderNumber, theProjectNumber, theContractNumber);
                if (theResult == true)
                {
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("指标已经添加，无法再次添加！");
                    this.Close();
                }
            }
           
        }

        private void AddIndex_Load(object sender, EventArgs e)
        {
            ComboBox_3Month.SelectedIndex = 0;
        }

        private void TextBox_3IndexOrder_Leave(object sender, EventArgs e)
        {
            string theOrder=TextBox_3IndexOrder.Text;
            Regex reg = new Regex(@"^[1-9]\d*$");
            if(reg.IsMatch(theOrder))
            {
                int theNumber;
                int.TryParse(theOrder, out theNumber);
                if(theNumber>=1 && theNumber<=100)
                {
                    theOrderNumber = theNumber;
                }
                else
                {
                    MessageBox.Show("输入不合理");
                }
            }
            else
            {
                MessageBox.Show("输入不符合规范！");
            }
            
        }

        private void TextBox_3IndexProject_Leave(object sender, EventArgs e)
        {
            string theProject = TextBox_3IndexProject.Text;
            Regex reg = new Regex(@"^[1-9]\d*$");
            if (reg.IsMatch(theProject))
            {
                int theNumber;
                int.TryParse(theProject, out theNumber);
                if (theNumber >= 1 && theNumber <= 100)
                {
                    theProjectNumber = theNumber;
                }
                else
                {
                    MessageBox.Show("输入不合理");
                }
            }
            else
            {
                MessageBox.Show("输入不符合规范！");
            }
        }

        private void TextBox_3IndexContract_Leave(object sender, EventArgs e)
        {
            string theContract = TextBox_3IndexContract.Text;
            Regex reg = new Regex(@"^[1-9]\d*$");
            if (reg.IsMatch(theContract))
            {
                int theNumber;
                int.TryParse(theContract, out theNumber);
                if (theNumber >= 1 && theNumber <= 100)
                {
                    theContractNumber = theNumber;
                }
                else
                {
                    MessageBox.Show("输入不合理");
                }
            }
            else
            {
                MessageBox.Show("输入不符合规范！");
            }
        }
    }
}
