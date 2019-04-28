using CRMSystemApp.Business.Models;
using CRMSystemApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Upload
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadList : ContentPage
	{
        public string[] clientInfo;
        int theuId;
        public UploadList ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out theuId);
            //做集合
            var soure = from clients in LoadData()
                        orderby clients.Name
                        group clients by clients.State into clientsGroup
                        select new Grouping<string, Clients>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        //跳转到上传合同页面
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var clients = e.Item as Clients;
            if (clients.State == "客户丢失" || clients.State == "已签单")
            {
                if (clients.State == "客户丢失")
                    DisplayAlert("抱歉", "跟踪状态为客户丢失，无法为该客户新建签单", "确认");
                else
                    DisplayAlert("抱歉", "该客户已签单，无法为该客户新建签单", "确认");
            }
            else
            {
                Navigation.PushAsync(new UploadImage(clients.Name, clients.Phone));
            }

            //Navigation.PushAsync(new DetailInfoPage(clients.Name, clients.Phone));
        }
        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            await Task.Delay(2000);
            listView.IsRefreshing = false;
            var soure = from clients in LoadData()
                        orderby clients.Name
                        group clients by clients.State into clientsGroup
                        select new Grouping<string, Clients>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        #region "LoadData"
        protected IList<Clients> LoadData()
        {
            var Checks = DependencyService.Get<Interfaces.ISthClientInfo>();
            string[] clientInfo;
            clientInfo = Checks.SelectSthClientInfos(theuId);
            int infoLength = clientInfo.Length;
            var clients = new List<Clients>();
            for (int i = 0; i < infoLength;)
            {
                if (clientInfo[i + 4] == "已签工单")
                {
                    clients.Add(new Clients
                    {
                        Name = clientInfo[i],
                        Phone = clientInfo[i + 1],
                        HouseType = clientInfo[i + 2],
                        Priority = clientInfo[i + 3],
                        State = clientInfo[i + 4],
                        Photo = ImageSource.FromFile("Customer.png")
                    });
                    i = i + 5;
                }
                else
                {
                    i = i + 5;
                    continue;
                }
            }
            return clients;
        }
        #endregion
    }
}