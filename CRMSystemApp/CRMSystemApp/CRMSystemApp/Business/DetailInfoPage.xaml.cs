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
	public partial class DetailInfoPage : ContentPage
	{
        public DateTime dateTime;
        string cName;
        string cPhone;
        string cPlot;
        string cHouseType;
        string theState;
        string cClientType;
        int aUserId;//职工ID
        string[] clientDetailInfo;//客户详细信息
		public DetailInfoPage (string name,string phone)
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out aUserId);
            cPhone = phone;
            Title = name;
            string theDate;
            //获取详细信息
            var Checks = DependencyService.Get<Interfaces.IClientInfo>();
            clientDetailInfo=Checks.SelectDetailInfo(phone);
            int i = 0;
            theDate = clientDetailInfo[i];
            DateTime newDate;
            DateTime.TryParse(theDate,out newDate); //日期
            showDate.Date = newDate;
            showName.Text = clientDetailInfo[i + 1]; //姓名
            cName = showName.Text;
            showPhone.Text = clientDetailInfo[i + 2]; //电话号码 
            showPlot.Text = clientDetailInfo[i + 3]; //小区
            cPlot = showPlot.Text;
            showHouseType.SelectedItem = clientDetailInfo[i + 4]; //房屋类型
            cHouseType = showHouseType.SelectedItem.ToString();
            showClientType.SelectedItem = clientDetailInfo[i + 8];//客户类型
            cClientType = showClientType.SelectedItem.ToString();
            showPriority.Text = clientDetailInfo[i + 5]; //优先级
            showState.Text = clientDetailInfo[i + 7]; //跟踪状态
            theState = showState.Text;

            if (theState == "客户丢失")
            {
                btSave.IsEnabled = false;
                btSave.IsVisible = false;
                btDelete.IsEnabled = true;
            }
            else
            {
                btSave.IsEnabled = true;
                btSave.IsVisible = false;
                btDelete.IsEnabled = true;
            }

        }
        public void OnDateSelect(object sender,EventArgs e)
        {
            if(theState== "客户丢失")
            {
                btSave.IsEnabled = false;
                //btDelete.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
                btSave.IsVisible = true;
                btDelete.IsEnabled = true;
            }
        }
        public void NameUnfocus(object sender, EventArgs e)
        {
            if (theState == "客户丢失")
            {
                btSave.IsEnabled = false;
                //btDelete.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
                btSave.IsVisible = true;
                btDelete.IsEnabled = true;
            }
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            if (showName.Text != null)
            {
                if (regex.IsMatch(showName.Text.ToString()))
                {
                    if (showName.Text.Length <= 10)
                    {
                        cName = showName.Text.ToString();
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
            if (theState == "客户丢失")
            {
                btSave.IsEnabled = false;
                //btDelete.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
                btSave.IsVisible = true;
                btDelete.IsEnabled = true;
            }
            if (showPlot.Text != null)
            {
                Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
                if (regex.IsMatch(showPlot.Text.ToString()))
                {
                    if (showPlot.Text.Length <= 10)
                    {
                        cPlot = showPlot.Text.ToString();
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
            if (theState == "客户丢失")
            {
                btSave.IsEnabled = false;
                //btDelete.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
                btSave.IsVisible = true;
                btDelete.IsEnabled = true;
            }
            if (showHouseType.SelectedItem!=null)
            {
                cHouseType = showHouseType.SelectedItem.ToString();
            }
            else
            {
                cHouseType = null;
            }
        }
        public void ClientTypeSelected(object sender,EventArgs e)
        {
            if (theState == "客户丢失")
            {
                btSave.IsEnabled = false;
                //btDelete.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
                btSave.IsVisible = true;
                btDelete.IsEnabled = true;
            }
            if (showClientType.SelectedItem!=null)
            {
                cClientType = showClientType.SelectedItem.ToString();
            }
            else
            {
                cClientType = null;
            }
        }
        public void OnSave(object sender,EventArgs e)
        {
            dateTime = showDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;//当前时间
            dateTime = new DateTime(showDate.Date.Year, showDate.Date.Month, showDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

            if (cName == null || cPhone == null | cPlot == null || cHouseType == null ||cClientType==null)
            {
                DisplayAlert("警告", "线索信息填写为空或有格式错误!请重新填写！", "确认");
            }
            else
            {
                var Checks = DependencyService.Get<Interfaces.IAddClientInfo>();
                bool results = Checks.UpdateClientInfo(dateTime, cName, cPhone, cPlot, cHouseType, aUserId,cClientType);
                if (results == true)
                {
                    var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                    bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), cPhone, "修改客户线索");
                    DisplayAlert("更新成功", "此客户线索信息成功更新！", "确认");

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("更新失败", "此客户线索信息更新失败！", "确认");
                }
            }
        }
        async public void OnDelete(object sender,EventArgs e)
        {
            if (await DisplayAlert("确认", "确认删除该客户线索？", "确认", "取消"))
            {
                var Checks = DependencyService.Get<Interfaces.IAddClientInfo>();
                bool results = Checks.DeleteClientInfo(cPhone);
                if (results == true)
                {
                    //删除业务明细的信息
                    var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                    bool theResult = theChecks.DeleteBusinessInfos(cPhone);

                    await DisplayAlert("删除成功", "已成功删除此客户线索信息！", "确认");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("删除失败", "删除该客户线索信息失败！", "确认");
                    await Navigation.PopAsync();
                }
            }
        }
	}
}