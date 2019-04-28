using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMSystemPC
{
    public partial class ViewContract : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        private MainForm mainForm;
        string thePhone;
        public ViewContract()
        {
            InitializeComponent();
           
        }
        //添加一个构造函数
        public ViewContract(MainForm form) : this()
        {
            mainForm = form;
        }

        private void Button_2Confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewContract_Load(object sender, EventArgs e)
        {
            Label_2ClientName.Text = mainForm.GetClientName();
            Label_2Time.Text = mainForm.GetUploadTime();
            thePhone = mainForm.TheClientPhone();

            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            byte[] theImage = myWebService.LoadImg(thePhone);
            if (theImage != null)
            {

                MemoryStream myStream = new MemoryStream();
                foreach (byte a in theImage)
                {
                    myStream.WriteByte(a);
                }
                Image myImage = Image.FromStream(myStream);
                myStream.Close();
                this.pictureBox_Contract.Image = myImage;
                this.pictureBox_Contract.Refresh();
            }
        }
    }
}
