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

[assembly: Dependency(typeof(GetStaffInfo))]
namespace CRMSystemApp.Droid
{
    public class GetStaffInfo:Interfaces.StaffInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] GetTheStaffInfo(int theId)
        {
            return service.GetStaffInfos(theId);
        }
        public bool UpdateStaffInfo(int theId, string thePassword, string theArea, string theName, string thePhone)
        {
            return service.UpdateStaff(theId, thePassword, theArea, theName, thePhone);
        }
    }
}