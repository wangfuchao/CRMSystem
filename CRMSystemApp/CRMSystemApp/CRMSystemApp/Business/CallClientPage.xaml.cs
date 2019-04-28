using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallClientPage : ContentPage
    {
        string thePhone;
        string theName;
        string thePriority;
        string theState;
        public CallClientPage(string name, string phone, string priority, string state)
        {
            InitializeComponent();
            Title = name;
            thePhone = phone;
            thePriority = priority;
            theState = state;
            theName = name;
            var page = new LogPage(phone);
            LogHolder.Content = page.Content;

        }
        public void OnAddLog(object sender, EventArgs e)
        {
            if (TheLog.Text.Length == 0 || TheLog.Text == null ||TheLog.Text.Equals("") ||TheLog==null)
            {
                DisplayAlert("抱歉", "您所填写的联系备忘为空！", "确认");
            }
            else if (TheLog.Text.Length >= 20)
            {
                DisplayAlert("抱歉", "您所填写的联系备忘过长，不能超过20字符", "确认");
            }
            else
            {
                DateTime dateTime = DateTime.Now.Date;//日期
                TimeSpan timeSpan = DateTime.Now.TimeOfDay;//当前时间
                dateTime = new DateTime(dateTime.Date.Year, dateTime.Date.Month, dateTime.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                string theDetail = TheLog.Text;

                var theChecks = DependencyService.Get<Interfaces.IContactLog>();
                bool theResult = theChecks.AddTheLog(dateTime.ToString(), thePhone, theDetail);
                if(theResult==true)
                {
                    //更新联系备忘列表
                    DisplayAlert("成功", "成功添加该客户的联系备忘！", "确认");
                    //更新联系备忘列表
                    var page = new LogPage(thePhone);
                    LogHolder.Content = page.Content;
                    TheLog.Text = "";

                }
                else
                {
                    DisplayAlert("抱歉", "添加该客户的联系备忘失败！", "确认");
                }
            }
            //TheLog的正则表达式
            //连接数据库，添加数据
            //更新联系备忘列表
        }
        public void OnReset(object sender,EventArgs e)
        {
            if(theState=="已签定单"||theState=="上传合同"||theState=="已签工单")
            {
                DisplayAlert("抱歉！", "该用户为已签单用户,其状态无需手动更改", "确认");
            }
            else
            {
                StackLayout0.IsEnabled = true;
                StackLayout0.IsVisible = true;
                save.IsEnabled = true;
                save.IsVisible = true;
                state.IsEnabled = true;
                state.Title = theState;
            }   
        }
        public void OnCall(object sender,EventArgs e)
        {
            var dialer = DependencyService.Get<IDialer>();
            if (dialer != null)
            {
                bool asd;
                asd = dialer.Dial(thePhone);
            }
            else
            {
                DisplayAlert("号码无效", "您拨打的电话号码无效", "确认");
            }
        }
        public void OnSave(object sender,EventArgs e)
        {
            var Results= DependencyService.Get<Interfaces.IAddClientInfo>();
            string upState;
            string upPriority;
            DateTime dateTime=DateTime.Now.Date;//日期
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;//当前时间
            dateTime = new DateTime(dateTime.Date.Year, dateTime.Date.Month, dateTime.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            if (state.SelectedItem==null)
            {
                upState = theState;
            }
            else
            {
                upState = state.SelectedItem.ToString();
            }
            if(upState=="客户丢失")
            {
                upPriority = "低优先";
                //var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                //bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), thePhone,"客户遗憾丢失");
            }
            else
            {
                upPriority = "中优先";
            }
            bool Check=Results.UpdatePriorityState(upPriority, upState,thePhone);
            if(Check == true)
            {
                var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                if(upState=="客户丢失")
                {
                    bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), thePhone, "客户遗憾丢失");
                }
                else
                {
                    bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), thePhone, "客户正常追踪");
                }
                DisplayAlert("成功", "更新线索成功！", "确认");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("失败", "更新线索失败！", "确认");
                Navigation.PopAsync();
            }
        }
	}
}