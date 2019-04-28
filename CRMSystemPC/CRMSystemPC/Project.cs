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
    public partial class Project : MetroForm
    {
        private MainForm mainForm;
        string[] theProjectInfo;
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        string thePhone;
        public Project()
        {
            InitializeComponent();
        }
        //添加一个构造函数
        public Project(MainForm form) : this()
        {
            mainForm = form;
        }

        private void Project_Load(object sender, EventArgs e)
        {
            thePhone = mainForm.TheClientPhone();
            //连接数据库
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            theProjectInfo = myWebService.SelectProjectListInfo(thePhone).ToArray();
            for(int i=0;i<theProjectInfo.Length;)
            {
                Label_EName.Text= theProjectInfo[i];
                Label_EPhone.Text = theProjectInfo[i + 1];
                Label_EDate.Text = theProjectInfo[i + 2];
                Label_ETiemLimit.Text = theProjectInfo[i + 3];
                Label_EMaterial.Text= theProjectInfo[i + 4];
                Label_ELabor.Text = theProjectInfo[i + 5];
                Label_EManage.Text = theProjectInfo[i + 6];
                Label_EDesign.Text= theProjectInfo[i + 7];
                Label_EOthers.Text= theProjectInfo[i + 8];
                Label_ETotal.Text = theProjectInfo[i + 9];
                i = i + 11;
            }
        }

        private void Button_PConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
