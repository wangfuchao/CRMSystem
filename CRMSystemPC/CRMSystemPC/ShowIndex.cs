using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMSystemPC
{
    public partial class ShowIndex : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        public ShowIndex()
        {
            InitializeComponent();
            ComboBox_3Month.SelectedIndex = 0;
        }

        private void ComboBox_3Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            //连接数据库
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string theMonth = ComboBox_3Month.SelectedItem.ToString();
            int indexMonth = this.ComboBox_3Month.FindString(theMonth);
            string[] theIndexInfo = myWebService.GetPersonalgoal((indexMonth + 1).ToString()).ToArray();
            if(theIndexInfo.Length==0)
            {
                Label_3ShowOrder.Text = "0";
                Label_3ShowProject.Text = "0";
                Label_3ShowContract.Text = "0";
            }
            else
            {
                for(int i=0;i<theIndexInfo.Length;i++)
                {
                    Label_3ShowOrder.Text = theIndexInfo[i];
                    Label_3ShowProject.Text = theIndexInfo[i + 1];
                    Label_3ShowContract.Text = theIndexInfo[i + 2];
                    i = i + 3;
                }
            }
        }

        private void Button_3IndexConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
