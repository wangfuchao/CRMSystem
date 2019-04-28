using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Contract
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewContractPage : ContentPage
	{
        string theName;
        string thePhone;
        string theAddress;
        string theHouse;
        float theArea;
        float theBudget;
        float thePayment;
        int theId;
		public NewContractPage (string name,string phone)
		{
			InitializeComponent ();
            Title = "新建签单";
            addName.Text = name;
            theName = name;
            thePhone = phone;
            addPhone.Text = phone;
            int.TryParse(App.UserId, out theId);
		}
        public void AddressUnfocus(object sender,EventArgs e)
        {
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            if (addAddress.Text != null)
            {
                if (regex.IsMatch(addAddress.Text.ToString()))
                {
                    if (addAddress.Text.Length <= 20)
                    {
                        theAddress = addAddress.Text.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "地址长度超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "地址输入含有非法字符！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "地址填写为空！", "确认");
            }
        }
        public void HouseUnfocus(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            if (addHouseType.Text != null)
            {
                if (regex.IsMatch(addHouseType.Text.ToString()))
                {
                    if (addHouseType.Text.Length <= 20)
                    {
                        theHouse = addHouseType.Text.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "填写长度超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "填写含有非法字符！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "房屋填写为空！", "确认");
            }
        }
        public void AreaUnfocus(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");
            if (addArea.Text != null)
            {
                if (regex.IsMatch(addArea.Text.ToString()))
                {
                    if (addArea.Text.Length <= 10)
                    {
                        float newArea;
                        float.TryParse(addArea.Text.ToString(), out newArea);
                        if(newArea <= 20 || newArea >= 999)
                        {
                            DisplayAlert("警告", "输入的面积不合理", "确认");
                        }
                        else
                        {
                            float.TryParse(addArea.Text.ToString(), out theArea);
                        }
                    }
                    else
                    {
                        DisplayAlert("警告", "面积输入超过限定范围！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "面积只能输入有1~3位小数的正实数！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "面积填写为空！", "确认");
            }
        }
        public void BudgetUnfocus(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");
            if (addBudget.Text != null)
            {
                if (regex.IsMatch(addBudget.Text.ToString()))
                {
                    if (addBudget.Text.Length <= 10)
                    {
                        float newBudget;
                        float.TryParse(addBudget.Text.ToString(), out newBudget);
                        if (newBudget <= 10000 ||newBudget>=1000000)
                        {
                            DisplayAlert("警告", "输入的预算不合理", "确认");
                        }
                        else
                        {
                            float.TryParse(addBudget.Text.ToString(), out theBudget);
                        }
                    }
                    else
                    {
                        DisplayAlert("警告", "预算填写数额超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "预算只能输入有1~3位小数的正实数！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "预算填写为空！", "确认");
            }
        }
        public void PaymentUnfocus(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");//有1~3位小数的正实数
            if (addPayment.Text != null)
            {
                if (regex.IsMatch(addPayment.Text.ToString()))
                {
                    if (addPayment.Text.Length <= 10)
                    {
                        float newPayment;
                        float.TryParse(addPayment.Text.ToString(), out newPayment);
                        if (newPayment <= 1000 || newPayment >= 100000)
                        {
                            DisplayAlert("警告", "输入的定金不合理", "确认");
                        }
                        else
                        {
                            float.TryParse(addPayment.Text.ToString(), out thePayment);
                        }
                    }
                    else
                    {
                        DisplayAlert("警告", "定金填写数额超过限制！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "定金只能输入有1~3位小数的正实数！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "定金填写为空！", "确认");
            }
        }

        public void OnSaveContract(object sender,EventArgs e)
        {
            DateTime theDate = addDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            if (theAddress == null || theHouse == null | theArea == 0 || theBudget == 0 ||thePayment==0)
            {
                DisplayAlert("警告", "信息填写为空或有格式错误!请重新填写！", "确认");
            }
            else
            {
                var Checks = DependencyService.Get<Interfaces.IAddContractInfo>();
                bool results = Checks.AddContract(theDate, theName, thePhone, theAddress, theHouse, theArea, theBudget,thePayment,theId);
                if (results == true)
                {
                    DisplayAlert("添加成功", "此客户签单成功添加！", "确认");
                    var Results = DependencyService.Get<Interfaces.IAddClientInfo>();
                    bool Check = Results.UpdatePriorityState("高优先","已签定单", thePhone);
                    if (Check == true)
                    {
                        var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                        bool theResult = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "新建定金签单");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("失败", "更新线索失败！", "确认");
                        Navigation.PopAsync();
                    }
                }
                else
                {
                    DisplayAlert("添加失败", "此客户签单添加失败！", "确认");
                }
            }
        }
	}
}