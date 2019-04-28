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
	public partial class ContractDetailPage : ContentPage
	{
        string[] contractInfo;
        string theDate;
        string theName;
        string thePhone;
        string theAddress;
        string theHouse;
        string theState;
        float theArea;
        float theBudget;
        float thePayment;
        int theId;
        public ContractDetailPage (string name,string phone,string state)
		{
			InitializeComponent ();
            theState = state;
            Title = "签单详情";
            addName.Text = name;
            theName = name;
            thePhone = phone;
            addPhone.Text = phone;
            int.TryParse(App.UserId, out theId);

            //获取该客户的签单信息
            //获取详细信息
            var Checks = DependencyService.Get<Interfaces.IAddContractInfo>();
            contractInfo = Checks.SelectContract(phone);
            
            theDate = contractInfo[0];
            //addDate.Format = theDate.Substring(0, theDate.Length - 7); //日期

            DateTime newDate;
            DateTime.TryParse(theDate, out newDate); //日期
            addDate.Date = newDate;


            addName.Text = contractInfo[1];
            addPhone.Text = contractInfo[2];
            addAddress.Text = contractInfo[3];
            addHouseType.Text = contractInfo[4];
            addArea.Text = contractInfo[5];
            addBudget.Text = contractInfo[6];
            addPayment.Text = contractInfo[7];

            theName = name;
            thePhone = phone;
            theAddress = addAddress.Text;
            theHouse = addHouseType.Text;
            float.TryParse(addArea.Text, out theArea);
            float.TryParse(addBudget.Text, out theBudget);
            float.TryParse(addPayment.Text, out thePayment);

            btSave.IsVisible = false;
            btDelete.IsVisible = true;
            btSave.IsEnabled = true;
            btSave.IsEnabled = true;

        }
        public void OnDateSelect(object sender,EventArgs e)
        {
            btSave.IsVisible = true;
            btSave.IsEnabled = true;
        }
        public void AddressUnfocus(object sender, EventArgs e)
        {
            btSave.IsVisible = true;
            btSave.IsEnabled = true;
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
            btSave.IsVisible = true;
            btSave.IsEnabled = true;
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
            btSave.IsVisible = true;
            btSave.IsEnabled = true;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");
            if (addArea.Text != null)
            {
                if (regex.IsMatch(addArea.Text.ToString()))
                {
                    if (addArea.Text.Length <= 10)
                    {
                        float newArea;
                        float.TryParse(addArea.Text.ToString(), out newArea);
                        if (newArea <= 20 || newArea >= 999)
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
            btSave.IsVisible = true;
            btSave.IsEnabled = true;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");
            if (addBudget.Text != null)
            {
                if (regex.IsMatch(addBudget.Text.ToString()))
                {
                    if (addBudget.Text.Length <= 10)
                    {
                        float newBudget;
                        float.TryParse(addBudget.Text.ToString(), out newBudget);
                        if (newBudget <= 10000 || newBudget >= 1000000)
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
            btSave.IsVisible = true;
            btSave.IsEnabled = true;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");
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
        //保存签单修改
        public void OnSaveContract(object sender, EventArgs e)
        {
            DateTime theDate = addDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            if (theAddress == null || theHouse == null | theArea == 0 || theBudget == 0 || thePayment == 0)
            {
                DisplayAlert("警告", "信息填写为空或有格式错误!请重新填写！", "确认");
            }
            else
            {
                var Checks = DependencyService.Get<Interfaces.IAddContractInfo>();
                bool results = Checks.UpdateContract(theDate, theName, thePhone, theAddress, theHouse, theArea, theBudget, thePayment, theId);
                //添加业务明细
                if (results == true)
                {
                    var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                    bool theResults = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "修改定金签单");
                    DisplayAlert("修改成功", "此客户定金签单修改成功！", "确认");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("更新失败", "此客户定金签单更新失败！", "确认");
                    Navigation.PopAsync();
                }
            }
        }
        //删除签单
        async public void OnDeleteContract(object sender, EventArgs e)
        {
            DateTime theDate = addDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            if (theState=="已签合同")
            {
                await DisplayAlert("抱歉", "已签合同的客户，不能删除其签单", "确认");
                await Navigation.PopAsync();
            }
            else
            {
                if (await DisplayAlert("确认", "确认删除该客户定金签单？", "确认", "取消"))
                {
                    var Checks = DependencyService.Get<Interfaces.IAddContractInfo>();
                    bool results = Checks.DeleteContract(thePhone);
                    if (results == true)
                    {
                        //删除业务明细
                        var Results = DependencyService.Get<Interfaces.IAddClientInfo>();
                        bool Check = Results.UpdatePriorityState("中优先", "正在跟踪", thePhone);
                        if (Check == true)
                        {
                            var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                            bool theResults = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "删除定金签单");

                            await DisplayAlert("成功！", "成功删除该客户定金签单", "确认");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("失败", "删除该客户定金签单失败！", "确认");
                            await Navigation.PopAsync();
                        }
                    }
                    else
                    {
                        await DisplayAlert("删除失败", "删除该客户定金签单失败！", "确认");
                        await Navigation.PopAsync();
                    }
                }
            }
            //跟踪状态为签订合同的客户，不能删除其签单信息。
            //没有签订合同的客户，可以删除其签单信息，并且修改其优先级和跟踪状态。
        }

    }
}