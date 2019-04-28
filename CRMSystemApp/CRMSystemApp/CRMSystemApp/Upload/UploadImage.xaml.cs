using CRMSystemApp.Business.Models;
using CRMSystemApp.Business.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Upload
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadImage : ContentPage
	{
        string theName;
        string thePhone;
        public UploadImage (string name,string phone)
		{
            Title = name;
            theName = name;
            thePhone = phone;
			InitializeComponent ();


            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Rear
                });

                if (file == null)
                    return;

                //await DisplayAlert("File Location", file.Path, "OK");

                //将图片转换为字节
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    // file.Dispose();
                    return stream;
                });
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    file.Dispose();
                    App.imageByte = memoryStream.ToArray();
                    uploadPhoto.IsEnabled = true;
                }
            };
        }
        void OnUpload(object sender, EventArgs e)
        {
            DateTime theDate = DateTime.Now.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(theDate.Date.Year, theDate.Date.Month, theDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            string theResult;
            var Checks = DependencyService.Get<Interfaces.IUploadImages>();
            theResult = Checks.UpLoadImage(App.imageByte, thePhone);
            if (theResult == "OK")
            {

                var Results = DependencyService.Get<Interfaces.IAddClientInfo>();
                bool Check = Results.UpdatePriorityState("高优先", "上传合同", thePhone);
                if (Check == true)
                {
                    DisplayAlert("成功", "合同上传成功！", "确认");
                    var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                    bool theResults = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "正式签订合同");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("失败", "合同上传失败！", "确认");
                    Navigation.PopAsync();
                }
            }
            else
            {
                DisplayAlert("失败！", theResult, "确认");
                Navigation.PopAsync();
            }
        }

    }
}