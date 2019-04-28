using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRMSystemApp
{
	public partial class App : Application
	{
        public static string UserId=null;
        public static byte[] imageByte;
        public App ()
		{
			InitializeComponent();
             MainPage = new Login();
            //MainPage = new Business.DetailInfoPage("王福超","121212");
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
