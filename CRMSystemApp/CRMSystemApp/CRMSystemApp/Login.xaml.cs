using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
       
        public Login ()
		{
			InitializeComponent ();
		}
        void OnLogin(object sender, EventArgs e)
        {
            Regex checkId = new Regex("^\\d{6}$");
            bool ismatch = checkId.IsMatch(UserIds.Text);
            if(ismatch==false)
            {
                DisplayAlert("抱歉", "工号或密码错误！", "确定");
            }
            else
            {
                Regex checkPassword = new Regex("^\\d{8}$");
                bool theResults = checkPassword.IsMatch(Passwords.Text);
                if(theResults==false)
                {
                    DisplayAlert("抱歉", "工号或密码错误！", "确定");
                }
                else
                {
                    int Id;
                    var Checks = DependencyService.Get<ILogin>();
                    int.TryParse(UserIds.Text, out Id);
                    string[] theResult = Checks.CheckClass(Id, Passwords.Text);
                    if (theResult.Length != 0)
                    {
                        if (theResult[0] == "3")
                        {
                            App.UserId = UserIds.Text;
                            Navigation.PushModalAsync(new MainPage());
                        }
                        else
                        {
                            DisplayAlert("抱歉", "工号或密码错误！", "确定");
                        }
                    }
                    else
                    {
                        DisplayAlert("抱歉", "工号或密码错误！", "确定");
                    }
                }
            }  
        }
    }
}