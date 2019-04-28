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
using CRMSystemApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AddCustomersInfo))]
namespace CRMSystemApp.Droid
{
    class AddCustomersInfo: IAddCustomersInfo
    {
        //WebReference.WebService service = new WebReference.WebService();
        public bool AddCustomersInfos(DateTime dateTime, string cName, string cPhone, float cArea, string cStituation, int uId)
        {
            //return service.InsertCustomerInfo(dateTime, cName, cPhone, cArea, cStituation, uId);
            return true;
        }
        public bool CheckPhone(string phoneNumber)
        {
            //return service.CheckPhone(phoneNumber);
            return true;
        }

    }
}