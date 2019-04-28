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

[assembly: Dependency(typeof(AddClientInfo))]
namespace CRMSystemApp.Droid
{
    class AddClientInfo:Interfaces.IAddClientInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        public bool AddClientInfos(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType, string cPriority, int uId, string cState,string cClientType)
        {
            return service.InsertCustomerInfo(dateTime, cName, cPhone, cPlot, cHouseType, cPriority, uId, cState,cClientType);
        }
        public bool CheckPhone(string phoneNumber)
        {
            return service.CheckPhone(phoneNumber);
        }
        public bool UpdatePriorityState(string thePriority, string theState,string thePhone)
        {
            return service.UpdatePriorityState(thePriority, theState, thePhone);
        }
        public  bool UpdateClientInfo(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType, int uId,string cClientType)
        {
            return service.UpdateClientInfos(dateTime, cName, cPhone, cPlot, cHouseType, uId,cClientType);
        }
        public bool DeleteClientInfo(string phone)
        {
            return service.DeletePersonalInfo(phone);
        }
    }
}