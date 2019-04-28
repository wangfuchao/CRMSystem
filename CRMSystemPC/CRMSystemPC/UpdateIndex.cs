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
    public partial class UpdateIndex : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        string theMonth;
        int theOrderNumber;
        int theProjectNumber;
        int theContractNumber;
        public UpdateIndex()
        {
            InitializeComponent();
            ComboBox_3Month.SelectedIndex = 0;
        }

        private void ComboBox_3Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            //连接数据库
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            theMonth = ComboBox_3Month.SelectedItem.ToString();
            int indexMonth = this.ComboBox_3Month.FindString(theMonth);
            string[] theIndexInfo = myWebService.GetPersonalgoal((indexMonth + 1).ToString()).ToArray();
            if (theIndexInfo.Length == 0)
            {
                TextBox_3IndexOrder.Text = "0";
                TextBox_3IndexProject.Text = "0";
                TextBox_3IndexContract.Text = "0";
            }
            else
            {
                for (int i = 0; i < theIndexInfo.Length; i++)
                {
                    TextBox_3IndexOrder.Text = theIndexInfo[i];
                    int.TryParse(theIndexInfo[i], out theOrderNumber);
                    TextBox_3IndexProject.Text = theIndexInfo[i + 1];
                    int.TryParse(theIndexInfo[i+1], out theProjectNumber);
                    TextBox_3IndexContract.Text = theIndexInfo[i + 2];
                    int.TryParse(theIndexInfo[i + 2], out theContractNumber);
                    i = i + 3;
                }
            }
        }

        private void TextBox_3IndexOrder_Leave(object sender, EventArgs e)
        {
            string theOrder = TextBox_3IndexOrder.Text;
            Regex reg = new Regex(@"^[1-9]\d*$");
            if (reg.IsMatch(theOrder))
            {
                int theNumber;
                int.TryParse(theOrder, out theNumber);
                if (theNumber >= 1 && theNumber <= 100)
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

        private void Button_3IndexConfirm_Click(object sender, EventArgs e)
        {
            if (TextBox_3IndexOrder == null || TextBox_3IndexProject == null || TextBox_3IndexContract == null)
            {
                MessageBox.Show("有未填写项，为空！请填写");
            }
            else
            {
                theMonth = ComboBox_3Month.SelectedItem.ToString();
                int indexMonth = this.ComboBox_3Month.FindString(theMonth);
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.UpDateIndex((indexMonth + 1).ToString(), theOrderNumber, theProjectNumber, theContractNumber);
                if (theResult == true)
                {
                    MessageBox.Show("更新成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新失败！");
                    this.Close();
                }
            }
        }
    }
}
