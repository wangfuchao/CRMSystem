using CRMSystemApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
			InitializeComponent ();
		}
        void OnSave(object sender,EventArgs e)
        {
            DateTime dateTime = addDate.Date;//新建日期
            string cNames = addName.Text.ToString();//客户姓名
            string cPhones = addPhone.Text.ToString();//联系电话
            float cAreas;//建筑面积
            float.TryParse(addArea.Text.ToString(), out cAreas);
            string cStituations = addSituation.Text.ToString();//跟踪情况
            int aUserId;
            int.TryParse(App.UserId, out aUserId);

            var Checks = DependencyService.Get<IAddCustomersInfo>();
            bool result = Checks.CheckPhone(cPhones);
            if(result==true)
            {
                DisplayAlert("添加失败", "此客户信息已追踪,无法添加", "确认");
            }
            else
            {
                bool results = Checks.AddCustomersInfos(dateTime,cNames,cPhones,cAreas,cStituations,aUserId);
                if(results==true)
                {
                    DisplayAlert("添加成功！", "此客户信息成功添加！", "确认");

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("添加失败！", "此客户信息添加失败！", "确认");
                }
            }
        }
	}
}