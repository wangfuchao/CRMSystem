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

[assembly: Dependency(typeof(GetPerosnalGoals))]
namespace CRMSystemApp.Droid
{
    class GetPerosnalGoals:Interfaces.IPersonalGoal
    {
        WebReference.WebService service = new WebReference.WebService();
        public string[] GetPersonalGoal(string theMonth)
        {
            return service.GetPersonalgoal(theMonth);
        }
    }
}