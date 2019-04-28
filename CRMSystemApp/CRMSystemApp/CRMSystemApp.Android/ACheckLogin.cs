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

[assembly: Dependency(typeof(ACheckLogin))]
namespace CRMSystemApp.Droid
{
    class ACheckLogin:ILogin
    {
        WebReference.WebService service = new WebReference.WebService();
        public bool LoginCheck(int username, string password)
        {
            return service.UserLogin(username, password);
            //return true;
        }
        public string[] CheckClass(int UserId, string Password)
        {
            return service.UserCheck(UserId, Password);
        }
    }
}