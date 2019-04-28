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

[assembly: Dependency(typeof(ContactLog))]
namespace CRMSystemApp.Droid
{
    class ContactLog:Interfaces.IContactLog
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] GetTheLog(string thePhone)
        {
            return service.GetTheLogs(thePhone);
        }
        public bool AddTheLog(string theDate, string thePhone, string theDetail)
        {
            return service.InsertTheLog(theDate, thePhone, theDetail);
        }
    }
}