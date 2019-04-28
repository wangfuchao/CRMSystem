using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace CRMSystemApp.QRCode
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScanPage : ContentPage
	{
        int theId;
		public ScanPage ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out theId);
		}
        async void OnScan(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            dateTime = new DateTime(dateTime.Date.Year, dateTime.Date.Month, dateTime.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopModalAsync();
                    var Checks = DependencyService.Get<Interfaces.IClientInfo>();
                    bool handResult;
                    handResult=Checks.HandOverClient(DecryptBase64(result.Text), theId, dateTime);
                    if(handResult==true)
                    {
                        //先验证业务明细中是否有该电话，如果有，则删除该电话的所有业务明细，再添加新的业务明细
                        var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                        bool checkResult = theChecks.CheckBusinessInfo(DecryptBase64(result.Text));
                        if(checkResult==true)
                        {
                            bool isDelete=theChecks.DeleteBusinessInfos(DecryptBase64(result.Text));
                            if(isDelete==true)
                            {
                                bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), DecryptBase64(result.Text), "接收客户线索");
                            }
                        }
                        else
                        {
                            bool theResult = theChecks.AddBusinessInfo(dateTime.ToString(), DecryptBase64(result.Text), "接收客户线索");
                        }        
                        DisplayAlert("接收成功","成功接收一条线索！", "确认");
                    }
                    else
                    {
                        DisplayAlert("接收失败", "未能成功接收线索！", "确认");
                    }
                });
            };

            // Navigate to our scanner page
            await Navigation.PushModalAsync(scanPage);
        }
        //base64 解密算法

        static string DecryptBase64(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);

            return Encoding.UTF8.GetString(inputBytes);
        }
    }
}