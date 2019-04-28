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

[assembly: Dependency(typeof(GetBusinessDetail))]
namespace CRMSystemApp.Droid
{
    class GetBusinessDetail:Interfaces.IBusinessDetail
    {
        WebReference.WebService service = new WebReference.WebService();
        public bool AddBusinessInfo(string date, string phone, string state)
        {
            return service.InsertBusinessDetail(date, phone, state);
        }
        public string[] SelectBusiness(string phone)
        {
            return service.SelectBusinessInfo(phone);
        }
        public bool DeleteBusinessInfos(string phone)
        {
            return service.DeleteBusinessInfo(phone);
        }
        public bool CheckBusinessInfo(string phone)
        {
            return service.CheckBusiness(phone);
        }
    }
}