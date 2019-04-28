using CRMSystemApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMSystemApp.Business.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactClientsPage : ContentPage
	{
        int theuId;
        public string[] clientInfo;
        public ContactClientsPage ()
		{
            InitializeComponent();

            int.TryParse(App.UserId, out theuId);

            //做集合
            var soure = from clients in LoadData()
                        orderby clients.Name
                        group clients by clients.State into clientsGroup
                        select new Grouping<string, Clients>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        //打电话联系客户
        void Handle_ItemTapped(object sender,Xamarin.Forms.ItemTappedEventArgs e)
        {
            var clients = e.Item as Clients;
            
            Navigation.PushAsync(new CallClientPage(clients.Name, clients.Phone,clients.Priority,clients.State));
        }
        async void Handle_Refreshing(object sender,System.EventArgs e)
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
            clientInfo = Checks.SelectSthClientInfos(theuId);
            int infoLength = clientInfo.Length;
            var clients = new List<Clients>();
            for (int i=0;i<infoLength;)
            {
                clients.Add(new Clients
                {
                    Name = clientInfo[i],
                    Phone = clientInfo[i + 1],
                    HouseType=clientInfo[i+2],
                    Priority = clientInfo[i + 3],
                    State=clientInfo[i+4],
                    Photo = ImageSource.FromFile("Customer.png")
                });
                i = i + 5;
            }
            return clients;
        }
        #endregion
    }
}