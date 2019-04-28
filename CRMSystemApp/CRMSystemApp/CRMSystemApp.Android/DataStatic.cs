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

[assembly: Dependency(typeof(DataStatic))]
namespace CRMSystemApp.Droid
{
    class DataStatic:Interfaces.IDataStatistic
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] GetClueInfos(int userId)
        {
            return service.GetClueInfo(userId);
        }
        public string[] GetDateState(int userId)
        {
            return service.GetDateState(userId);
        }
    }
}