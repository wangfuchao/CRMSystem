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

[assembly: Dependency(typeof(GetClientInfo))]
namespace CRMSystemApp.Droid
{
    class GetClientInfo:Interfaces.IClientInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] SelectClientInfos(int uid)
        {
            return service.SelectClientInfo(uid);
        }
        public string[] SelectDetailInfo(string phone)
        {
            return service.SelectPersonalInfo(phone);
        }
        public bool HandOverClient(string phone, int uid,DateTime dateTime)
        {
            return service.ScanReceiveClient(phone, uid,dateTime);
        }
    }
}