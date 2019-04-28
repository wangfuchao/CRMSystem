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
	public partial class AddClientInfoPage : ContentPage
	{
        public DateTime dateTime;//日期
        public TimeSpan timeSpan=DateTime.Now.TimeOfDay;//当前时间
        string cName;
        string cPhone;
        string cPlot;
        string cHouseType;
        string cClientType;
        string cPriority = "中优先";
        string cState = "正在跟踪";
        int aUserId;//职工ID
        public AddClientInfoPage ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out aUserId);
        }
        public void NameUnfocus(object sender,EventArgs e)
        {
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            if(addName.Text!=null)
            {
                if (regex.IsMatch(addName.Text.ToString()))
                {
                    if (addName.Text.Length <= 10)
                    {
                        cName = addName.Text.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "姓名输入长度超过限制！", "确认");
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
        public void PhoneUnfocus(object sender,EventArgs e)
        {
            if(addPhone.Text!=null)
            {
                Regex mobileReg = new Regex("^1[34578]\\d{9}$");
                if (mobileReg.IsMatch(addPhone.Text.ToString()))
                {
                    var Checks = DependencyService.Get<Interfaces.IAddClientInfo>();
                    bool result = Checks.CheckPhone(addPhone.Text.ToString());
                    if (result == true)
                    {
                        DisplayAlert("抱歉", "此客户信息已追踪,无法添加！", "确认");
                    }
                    else
                    {
                        cPhone = addPhone.Text.ToString();
                    }
                }
                else
                {
                    DisplayAlert("警告", "手机号格式填写错误！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "手机号填写为空！", "确认");
            }
        }
        public void PlotUnfocus(object sender,EventArgs e)
        {
            if(addPlot.Text!=null)
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
        public void HouseTypeUnfocus(object sender,EventArgs e)
        {
            if (addHouseType.SelectedItem != null)
            {
                cHouseType = addHouseType.SelectedItem.ToString();
            }
            else
            {
                DisplayAlert("警告", "房屋类型选择为空！", "确认");
            }
        }
        public void ClientTypeSelected(object sender,EventArgs e)
        {
            if(addClientType.SelectedItem!=null)
            {
                cClientType = addClientType.SelectedItem.ToString();
            }
            else
            {
                DisplayAlert("警告", "客户类型选择为空！", "确认");
            }
        }
        public void OnSaveInfo(object sender,EventArgs e)
        {
            dateTime = addDate.Date;
            dateTime = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            if (cName==null||cPhone==null|cPlot==null||cHouseType==null ||cClientType==null)
            {
                DisplayAlert("警告", "信息填写为空或有格式错误!请重新填写！", "确认");
            }
            else
            {
                var Checks = DependencyService.Get<Interfaces.IAddClientInfo>();
                bool results = Checks.AddClientInfos(dateTime, cName, cPhone, cPlot, cHouseType, cPriority, aUserId, cState, cClientType);
                if (results == true)
                {
                    var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                    bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), cPhone, "建立客户线索");
                    if(theResult==true)
                    DisplayAlert("添加成功", "此客户信息成功添加！", "确认");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("添加失败", "此客户信息添加失败！", "确认");
                }
            }  
        }
	}
}