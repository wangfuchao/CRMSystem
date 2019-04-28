using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalPage : ContentPage
	{
		public PersonalPage ()
		{
			InitializeComponent ();
            string theMonth = DateTime.Now.Date.Month.ToString();
            var theChecks = DependencyService.Get<Interfaces.IPersonalGoal>();
            string[] theGoals = theChecks.GetPersonalGoal(theMonth);
            for(int i=0;i<theGoals.Length;)
            {
                OrderNumber.Text = theGoals[i];
                ProjectNumber.Text = theGoals[i + 1];
                contractNumber.Text = theGoals[i + 2];
                i = i + 3;
            }
        }
	}
}