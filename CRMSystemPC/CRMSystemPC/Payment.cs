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
    public partial class Payment : MetroForm
    {
        private MainForm mainForm;
        string[] theContractInfo;
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        string thePhone;
        public Payment()
        {
            InitializeComponent();
        }
        //添加一个构造函数
        public Payment(MainForm form) : this()
        {
            mainForm = form;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            thePhone = mainForm.TheClientPhone();
            //连接数据库
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            theContractInfo=myWebService.SelectContractInfo(thePhone).ToArray();
            for(int i=0;i<theContractInfo.Length;)
            {
                Label_PDate.Text = theContractInfo[i];
                Label_PName.Text = theContractInfo[i + 1];
                Label_PPhone.Text = theContractInfo[i + 2];
                Label_PAddress.Text = theContractInfo[i + 3];
                Label_PHouse.Text = theContractInfo[i + 4];
                Label_PArea.Text = theContractInfo[i + 5];
                Label_PBudget.Text = theContractInfo[i + 6];
                Label_PPrePay.Text = theContractInfo[i + 7];
                i = i + 9;
            }

        }

        private void Button_PConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
