using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CRMSystemApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(UploadImage))]
namespace CRMSystemApp.Droid
{
    class UploadImage:Interfaces.IUploadImages
    {
        WebReference.WebService service = new WebReference.WebService();
        public string UpLoadImage(byte[] fileBytes, string phone)
        {
            return service.UploadImg(fileBytes, phone);
        }
    }
}