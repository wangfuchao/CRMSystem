using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.DataStatistic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KPIPage : ContentPage
	{
        int theId;
		public KPIPage (int theOrder,int theProject,int theContract)
		{
			InitializeComponent ();
            Title = "业务指标";
            int.TryParse(App.UserId, out theId);

		}
	}
}