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
	public partial class BusinessFunctionPage : ContentPage
	{
		public BusinessFunctionPage ()
		{
			InitializeComponent ();
		}
        async void AddClientInfo_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout1.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.White;
            StackLayout3.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Business.AddClientInfoPage());
            StackLayout0.BackgroundColor = Color.White;
        }
        async void ContactClients_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.White;
            StackLayout1.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout2.BackgroundColor = Color.White;
            StackLayout3.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Business.ContactClientsPage());
            StackLayout1.BackgroundColor = Color.White;
        }
        async void InfoView_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.White;
            StackLayout1.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout3.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Business.InformationsViewerPage());
            StackLayout2.BackgroundColor = Color.White;
        }
        async void HandOver_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.White;
            StackLayout1.BackgroundColor = Color.White;
            StackLayout2.BackgroundColor = Color.White;
            StackLayout3.BackgroundColor = Color.FromHex("#E8E8E8");
            await ContentHolder.Navigation.PushAsync(new Business.HandOverPage());
            StackLayout3.BackgroundColor = Color.White;
        }
        async void AcceptClients_Tapped(object sender, EventArgs e)
        {
            StackLayout00.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout11.BackgroundColor = Color.White;
            StackLayout22.BackgroundColor = Color.White;
            StackLayout33.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new QRCode.ScanPage());
            StackLayout00.BackgroundColor = Color.White;
        }
        async void NewContract_Tapped(object sender, EventArgs e)
        {
            StackLayout000.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout111.BackgroundColor = Color.White;
            StackLayout222.BackgroundColor = Color.White;
            StackLayout333.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Contract.AddContractPage());
            StackLayout000.BackgroundColor = Color.White;
        }
        async void ContractView_Tapped(object sender, EventArgs e)
        {
            StackLayout000.BackgroundColor = Color.White;
            StackLayout111.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout222.BackgroundColor = Color.White;
            StackLayout333.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Contract.ViewDetailPage());
            StackLayout111.BackgroundColor = Color.White;
        }
        async void NewProject_Tapped(object sender, EventArgs e)
        {
            StackLayout000.BackgroundColor = Color.White;
            StackLayout111.BackgroundColor = Color.White;
            StackLayout222.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout333.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Contract.AddProjectPage());
            StackLayout222.BackgroundColor = Color.White;
        }
        async void ProjectView_Tapped(object sender, EventArgs e)
        {
            StackLayout000.BackgroundColor = Color.White;
            StackLayout111.BackgroundColor = Color.White;
            StackLayout222.BackgroundColor = Color.White;
            StackLayout333.BackgroundColor = Color.FromHex("#E8E8E8");
            await ContentHolder.Navigation.PushAsync(new Contract.ViewProjectPage());
            StackLayout333.BackgroundColor = Color.White;
        }
        async void Upload_Tapped(object sender, EventArgs e)
        {
            StackLayout0000.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout1111.BackgroundColor = Color.White;
            StackLayout2222.BackgroundColor = Color.White;
            StackLayout3333.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Upload.UploadList());
            StackLayout0000.BackgroundColor = Color.White;
        }
        async void Business_Tapped(object sender, EventArgs e)
        {
            StackLayout0000.BackgroundColor = Color.White;
            StackLayout1111.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout2222.BackgroundColor = Color.White;
            StackLayout3333.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new Upload.BusinessDetailList());
            StackLayout1111.BackgroundColor = Color.White;
        }
    }
}