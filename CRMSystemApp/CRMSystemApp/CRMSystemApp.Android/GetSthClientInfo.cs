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

[assembly: Dependency(typeof(GetSthClientInfo))]
namespace CRMSystemApp.Droid
{
    public class GetSthClientInfo:Interfaces.ISthClientInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] SelectSthClientInfos(int uId)
        {
            return service.SelectSthClientInfo(uId);
        }
    }
}