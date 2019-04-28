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

[assembly: Dependency(typeof(GetSchedule))]
namespace CRMSystemApp.Droid
{
    class GetSchedule:Interfaces.Schedule
    {
        WebReference.WebService service = new WebReference.WebService();
        public bool AddTheSchedule(int UserId, DateTime theDate, TimeSpan theStartTime, TimeSpan theEndTime, string theColor, string theSubject)
        {
            return service.AddSchedule(UserId, theDate, theStartTime.ToString(), theEndTime.ToString(), theColor, theSubject);
        }
        public string[] ViewSchedule(int UserId)
        {
            return service.GetSchedule(UserId);
        }
    }
}