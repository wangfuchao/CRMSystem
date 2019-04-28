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
	public partial class SettingPage : ContentPage
	{
        int theUserId;
		public SettingPage ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out theUserId);
            var Checks = DependencyService.Get<Interfaces.StaffInfo>();
            string[] theInfos = Checks.GetTheStaffInfo(theUserId);
            for(int i=0;i<theInfos.Length;)
            {
                theName.Text = theInfos[i+2];
                theId.Text = theInfos[i];
                theArea.Text = theInfos[i + 1];
                thePhone.Text = theInfos[i + 3];
                i = i + 4;
            }
        }
        public void theReset(object sender,EventArgs e)
        {
            St0.IsVisible = true;
            St1.IsVisible = true;
        }
        public void UnfocusPassword(object sender,EventArgs e)
        {
            Regex reg = new Regex(@"^\d{8}$");
            if(!reg.IsMatch(thePassword.Text))
            {
                DisplayAlert("警告", "您输入的密码不符合规范，请重新输入！", "确认");
            }
        }
        public void OnUpdate(object sender,EventArgs e)
        {
            Regex reg = new Regex(@"^\d{8}$");
            if (!reg.IsMatch(theCPassword.Text))
            {
                DisplayAlert("警告", "您输入的密码不符合规范，请重新输入！", "确认");
            }
            else
            {
                if(thePassword.Text==theCPassword.Text)
                {
                    var Checks = DependencyService.Get<Interfaces.StaffInfo>();
                    bool theResult = Checks.UpdateStaffInfo(theUserId, thePassword.Text, theArea.Text, theName.Text, thePhone.Text);
                    if(theResult==true)
                    {
                        DisplayAlert("成功！", "更新密码成功！","确认");
                        St0.IsVisible = false;
                        St1.IsVisible = false;
                        
                    }
                    else
                    {
                        DisplayAlert("失败！", "更新密码失败", "确认");
                    }
                }
            }
        }

    }
}