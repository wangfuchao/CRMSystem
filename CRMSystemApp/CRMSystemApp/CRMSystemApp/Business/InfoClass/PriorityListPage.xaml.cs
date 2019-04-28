﻿using CRMSystemApp.Business.Models;
using CRMSystemApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business.InfoClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PriorityListPage : ContentPage
	{
        int theuId;
        public static string[] clientInfo;
        public PriorityListPage ()
		{
			InitializeComponent ();

            int.TryParse(App.UserId, out theuId);

            //做集合
            var soure = from clients in LoadData()
                        orderby clients.Name
                        group clients by clients.Priority into clientsGroup
                        select new Grouping<string, Clients>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var clients = e.Item as Clients;

            //转到详情页面
            Navigation.PushAsync(new DetailInfoPage(clients.Name, clients.Phone));
        }
        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            await Task.Delay(2000);
            listView.IsRefreshing = false;
            var soure = from clients in LoadData()
                        orderby clients.Name
                        group clients by clients.Priority into clientsGroup
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