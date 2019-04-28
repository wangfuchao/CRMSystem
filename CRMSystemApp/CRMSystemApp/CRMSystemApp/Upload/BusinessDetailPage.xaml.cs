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
	public partial class BusinessDetailPage : ContentPage
	{
        public string[] clientInfo;
        int theuId;
        string thePhone;
        public BusinessDetailPage (string name,string phone)
		{
			InitializeComponent ();
            Title = name;
            thePhone = phone;


            int.TryParse(App.UserId, out theuId);
            //做集合
            var soure = from clients in LoadData()
                        orderby clients.Date
                        //select clients;
                        group clients by clients.Date into clientsGroup
                        select new Grouping<string, TheBusiness>(clientsGroup.Key, clientsGroup);
            listView.ItemsSource = soure;
        }
        #region "LoadData"
        protected IList<TheBusiness> LoadData()
        {
            var Checks = DependencyService.Get<Interfaces.IBusinessDetail>();
            string[] clientInfo;
            clientInfo = Checks.SelectBusiness(thePhone);
            int infoLength = clientInfo.Length;
            var clients = new List<TheBusiness>();
            for (int i = 0; i < infoLength;)
            {
                clients.Add(new TheBusiness
                {
                    Date = clientInfo[i],
                    State = clientInfo[i + 2],
                });
                i = i + 3;
            }
            return clients;
        }
        #endregion
    }
}