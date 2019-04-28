using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRMSystemApp
{
	public partial class MainPage : MasterDetailPage
    {
		public MainPage()
		{
			InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            //重写，实体返回键
            //DependencyService.Get<IAndroidMethods>().CloseApp();
            //return base.OnBackButtonPressed();
            return true;
        }
    }
}
