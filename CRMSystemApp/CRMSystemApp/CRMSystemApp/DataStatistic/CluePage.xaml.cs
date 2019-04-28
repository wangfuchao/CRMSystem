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
	public partial class CluePage : ContentPage
	{
		public CluePage ()
		{
			InitializeComponent ();
            Title = "线索转化";
		}
	}
}