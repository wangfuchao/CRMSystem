using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp
{
    public partial class MainTabPage : ContentPage
	{
        void Function1_Tapped(object sender, EventArgs e)
        {
            var page = new BusinessFunctionPage();
            cvContenPlaceHolder.Content = page.Content;
            Title = "业务主页";
            StackLayout0.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout1.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.White;
        }
        void Function2_Tapped(object sender, EventArgs e)
        {
            var page = new DataStatistic.MainDataPage();
            // var page = new ListViewPage1();
            //  cvContenPlaceHolder.Content = page.Content;
            // cvContenPlaceHolder.Navigation.PushAsync(new ListViewPage1());
            cvContenPlaceHolder.Content = page.Content;
            Title = "数据统计";
            StackLayout1.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout0.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.White;
        }
        void MyCalendar_Tapped(object sender, EventArgs e)
        {
            var page = new SChedule.AddSchedule();
            cvContenPlaceHolder.Content = page.Content;
            Title = "我的日程";
            StackLayout2.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout0.BackgroundColor = Color.White;
            StackLayout1.BackgroundColor = Color.White;
        }
        public MainTabPage ()
		{
			InitializeComponent ();
            var page = new BusinessFunctionPage();
            cvContenPlaceHolder.Content = page.Content;
            Title = "业务主页";
            StackLayout0.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout1.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.White;
        }
	}
}