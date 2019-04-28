using CRMSystemApp.Business.Models;
using CRMSystemApp.Business.ViewModels;
using CRMSystemApp.QRCode;
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
	public partial class HandOverPage : ContentPage
	{
        public string[] clientInfo;
        int theId;
        public HandOverPage ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out theId);
            //做集合
            var soure = from clients in LoadData()
                        orderby clients.Name
                        group clients by clients.State into clientsGroup
                        select new Grouping<string, Clients>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        //选择待移交的客户
        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var clients = e.Item as Clients;
            if(clients.State=="已签单")
            {
                await DisplayAlert("抱歉", "已签单的客户无法移交！", "确认");
            }
            else
            {
               if(await DisplayAlert("确认", "确认将此客户线索移交？", "确认", "取消"))
                {
                    await Navigation.PushAsync(new CodePage(clients.Phone));
                }
            }
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
            clientInfo = Checks.SelectSthClientInfos(theId);
            int infoLength = clientInfo.Length;
            var clients = new List<Clients>();
            for (int i = 0; i < infoLength;)
            {
                if (clientInfo[i + 4] == "正在跟踪" || clientInfo[i + 4] == "稳步推进" || clientInfo[i + 4] == "客户丢失")
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