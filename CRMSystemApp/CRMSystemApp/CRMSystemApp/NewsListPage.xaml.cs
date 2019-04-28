using CRMSystemApp.Business.Models;
using CRMSystemApp.Business.ViewModels;
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
	public partial class NewsListPage : ContentPage
	{
		public NewsListPage ()
		{
			InitializeComponent ();

            var soure = from news in LoadData()
                        orderby news.Date
                        group news by news.Theme into clientsGroup
                        select new Grouping<string, News>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        //跳转到通知详情页面
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var news= e.Item as News;

            Navigation.PushAsync(new MessagePage(news.Post,news.Date,news.Theme,news.Head,news.Content));
        }
        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            await Task.Delay(2000);
            listView.IsRefreshing = false;
            var soure = from news in LoadData()
                        orderby news.Date
                        group news by news.Theme into clientsGroup
                        select new Grouping<string, News>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        #region "LoadData"
        protected IList<News> LoadData()
        {
            var Checks = DependencyService.Get<Interfaces.NewsInfo>();
            string[] theNewsInfo;
            theNewsInfo = Checks.GetNewsInfos();
            int infoLength = theNewsInfo.Length;
            var news = new List<News>();
            for (int i = 0; i < infoLength;)
            {
                news.Add(new News
                {
                    Post = theNewsInfo[i+1],
                    Date = theNewsInfo[i + 2],
                    Theme = theNewsInfo[i + 3],
                    Head = theNewsInfo[i + 4],
                    Content= theNewsInfo[i + 5],
                    Photo = ImageSource.FromFile("Inform.png")
                });
                i = i + 6;
            }
            return news;
        }
        #endregion
    }
}