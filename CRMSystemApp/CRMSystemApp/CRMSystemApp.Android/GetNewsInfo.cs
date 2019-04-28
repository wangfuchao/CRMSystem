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

[assembly: Dependency(typeof(GetNewsInfo))]
namespace CRMSystemApp.Droid
{
    class GetNewsInfo:Interfaces.NewsInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] GetNewsInfos()
        {
            return service.TheNewsInfo();
        }
    }
}