using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace CRMSystemApp.QRCode
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CodePage : ContentPage
	{
        ZXingBarcodeImageView barcode;
        public CodePage(string phone)
        {
            Title = "移交客户线索";
            string encryptPhone= EncryptBase64(phone);
            //InitializeComponent ();
            var red = new Label
            {
                Text = "已成功生成移交客户二维码！",
                BackgroundColor = Color.Default,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 20
            };
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = encryptPhone;

            //Content = barcode;
            Content = new StackLayout
            {
                Spacing = 10,
                Children = { red, barcode }
            };

        }
        //base64 加密算法
        static string EncryptBase64(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(inputBytes);
        }
    }
}