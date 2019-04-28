using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlterClientInfoPage : ContentPage
	{
        public DateTime dateTime;
        string cName;
        string cPhone;
        string cPlot;
        string cHouseType;
        int aUserId;//职工ID
        public AlterClientInfoPage (string name,string phone,string plot,string housetype)
		{
			InitializeComponent ();
            addPhone.Text = phone;
            cPhone = phone;
            int.TryParse(App.UserId, out aUserId);
            dateTime = addDate.Date;
            addName.Text = name;
            cName = name;
            addPlot.Text = plot;
            cPlot = plot;
            cHouseType = housetype;
            addHouseType.Text = housetype;
        }
        public void NameUnfocus(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            if (addName.Text != null)
            {
                if (regex.IsMatch(addName.Text.ToString()))
                {
                    if (addName.Text.Length <= 10)
                    {
                        cName = addName.Text.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "姓名长度超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "姓名输入含有非法字符！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "姓名填写为空！", "确认");
            }
        }
        public void PlotUnfocus(object sender, EventArgs e)
        {
            if (addPlot.Text != null)
            {
                Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
                if (regex.IsMatch(addPlot.Text.ToString()))
                {
                    if (addPlot.Text.Length <= 10)
                    {
                        cPlot = addPlot.Text.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "小区填写长度超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "小区输入含有非法字符！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "小区输入为空！", "确认");
            }

        }
        public void HouseTypeUnfocus(object sender, EventArgs e)
        {
            if (addHouseType.Text != null)
            {
                Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
                if (regex.IsMatch(addHouseType.Text.ToString()))
                {
                    if (addHouseType.Text.Length <= 10)
                    {
                        cHouseType = addHouseType.Text.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "房屋类型填写长度超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "房屋类型输入含有非法字符！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "房屋类型输入为空！", "确认");
            }
        }
        public void OnSaveInfo(object sender, EventArgs e)
        {
            if (cName == null || cPhone == null | cPlot == null || cHouseType == null)
            {
                DisplayAlert("警告", "信息填写为空或有格式错误!请重新填写！", "确认");
            }
            else
            {
                var Checks = DependencyService.Get<Interfaces.IAddClientInfo>();
                bool results = Checks.UpdateClientInfo(dateTime, cName, cPhone, cPlot, cHouseType, aUserId,cHouseType);
                if (results == true)
                {
                    DisplayAlert("更新成功", "此客户信息成功更新！", "确认");
                    
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("更新失败", "此客户信息更新失败！", "确认");
                }
            }
        }
    }
}