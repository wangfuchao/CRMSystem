using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogPage : ContentPage
	{
		public LogPage (string thePhone)
		{
			InitializeComponent ();
            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;
            //连接数据库，读取数据库数据
            var theChecks = DependencyService.Get<Interfaces.IContactLog>();
            string[] theLogs = theChecks.GetTheLog(thePhone);
            if(theLogs.Length==0)
            {
                var label = new Label { Text="此客户暂时没有联系备忘", TextColor = Color.FromHex("#77d065"), FontSize = 15, HorizontalOptions = LayoutOptions.Center };
                layout.Children.Add(label);
            }
            else
            {
                for (int i = 0; i < theLogs.Length;)
                {
                    DateTime theDate;
                    DateTime.TryParse(theLogs[i], out theDate);
                    var label = new Label { Text ="                "+ theDate.ToShortDateString() +" "+ theLogs[i + 1], TextColor = Color.FromHex("#77d065"), FontSize = 15, HorizontalOptions = LayoutOptions.StartAndExpand };
                    layout.Children.Add(label);
                    i = i + 2;
                }
            }
		}
	}
}