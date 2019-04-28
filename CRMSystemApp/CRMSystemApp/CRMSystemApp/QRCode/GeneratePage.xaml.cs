using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.QRCode
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GeneratePage : ContentPage
	{

        //ZXingBarcodeImageView barcode;
        public GeneratePage()
        {
            InitializeComponent();
        }
        void OnGenerate(object sender, EventArgs e)
        {
            //barcode = new ZXingBarcodeImageView
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //};
            //barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            //barcode.BarcodeOptions.Width = 300;
            //barcode.BarcodeOptions.Height = 300;
            //barcode.BarcodeOptions.Margin = 10;
            //barcode.BarcodeValue = "ZXing.Net.Mobile";

            //Content = barcode;
            //await PlaceHolder.Navigation.PushAsync(new CodePage());
        }
    }
}