using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp
{
	public partial class MasterPage : ContentPage
	{
        public ListView ListView { get { return listView; } }
        public MasterPage ()
		{
			InitializeComponent ();
            UserInfo.Text += App.UserId;
		}
        //void Set_Tapped(object sender, EventArgs e)
        //{
        //    //BottomLayout0.BackgroundColor = Color.FromHex("#E8E8E8");
        //    //BottomLayout1.BackgroundColor = Color.White;
        //    ////ItemHolder.Content = page.Content;
        //    //Navigation.PushAsync(new SetPage());
        //    //BottomLayout0.BackgroundColor = Color.White;
        //}
    }
}