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
	public partial class BusinessHomePage : ContentPage
	{
		public BusinessHomePage ()
		{
			InitializeComponent ();
		}
        async void Demo0_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout1.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.White;
            StackLayout3.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new AddPage());
            StackLayout0.BackgroundColor = Color.White;

        }
    }
}