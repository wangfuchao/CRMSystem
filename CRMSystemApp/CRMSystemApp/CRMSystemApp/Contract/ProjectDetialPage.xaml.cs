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
	public partial class ProjectDetialPage : ContentPage
	{
        string theName;
        string thePhone;
        string theDate;
        int theTimeLimit;
        float theMaterial;
        float theLabor;
        float theManage;
        float theDesign;
        float theOthers;
        float theTotal;
        int theId;

        string theState;
        string[] projectInfo;
        bool bDateLimit = false;
        public ProjectDetialPage (string name,string phone,string state)
		{
            Title = "工单详情";
			InitializeComponent ();
            addName.Text = name;
            addPhone.Text = phone;
            theName = name;
            thePhone = phone;
            int.TryParse(App.UserId, out theId);
            theState = state;

            //获取用户工单信息
            var Checks = DependencyService.Get<Interfaces.IProjectInfo>();
            projectInfo = Checks.SelectProjectInfos(thePhone);

            theName = projectInfo[0];
            thePhone = projectInfo[1];
            theDate = projectInfo[2];
            int.TryParse(projectInfo[3], out theTimeLimit);
            float.TryParse(projectInfo[4], out theMaterial);
            float.TryParse(projectInfo[5], out theLabor);
            float.TryParse(projectInfo[6], out theManage);
            float.TryParse(projectInfo[7], out theDesign);
            float.TryParse(projectInfo[8], out theOthers);
            float.TryParse(projectInfo[9], out theTotal);
            int.TryParse(projectInfo[10], out theId);

            addName.Text = theName;
            addPhone.Text = thePhone;


            DateTime newDate;
            DateTime.TryParse(theDate, out newDate); //日期
            addDate.Date = newDate;

            //addDate.Format = theDate.Substring(0, theDate.Length - 7); //日期
            addDateLimit.Text = theTimeLimit.ToString();
            addMaterial.Text = theMaterial.ToString();
            addLabor.Text = theLabor.ToString();
            addManage.Text = theManage.ToString();
            addDesign.Text = theDesign.ToString();
            addOthers.Text = theOthers.ToString();
            addTotal.Text = theTotal.ToString();

            btUpdate.IsVisible = false;
            btDelete.IsVisible = true;
            btUpdate.IsEnabled = true;
            btDelete.IsEnabled = true;
        }
        public void OnSelected(object sender,EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
        }
        public void DateLimitUnfocus(object sender, EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
            int newDateLimit;
            Regex regex = new Regex("^([1-9][0-9]*){1,3}$");//非零的正整数
            if (addDateLimit.Text != null)
            {
                if (regex.IsMatch(addDateLimit.Text.ToString()))
                {
                    int.TryParse(addDateLimit.Text, out newDateLimit);
                    if (newDateLimit >= 10 && newDateLimit <= 120)
                    {
                        theTimeLimit = newDateLimit;
                        bDateLimit = true;
                    }
                    else
                    {
                        DisplayAlert("警告", "工程工期填写不合理！", "确认");
                    }
                }
                else
                {
                    DisplayAlert("警告", "工程工期输入含有非法字符！", "确认");
                }
            }
            else
            {
                DisplayAlert("警告", "工程工期输入为空！", "确认");
            }
        }
        public void MaterialUnfocus(object sender, EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
            float newMaterial;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");//有1~3位小数的正实数
            if (addMaterial.Text != null)
            {
                if (regex.IsMatch(addMaterial.Text.ToString()))
                {
                    float.TryParse(addMaterial.Text, out newMaterial);
                    if (newMaterial >= 1000 && newMaterial <= 100000)
                    {
                        theMaterial = newMaterial;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "材料费用填写不合理！", "确认");
                        theMaterial = 0;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                }
                else
                {
                    DisplayAlert("警告", "材料费用输入含有非法字符！", "确认");
                    theMaterial = 0;
                    theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                    addTotal.Text = theTotal.ToString();
                }
            }
            else
            {
                DisplayAlert("警告", "材料费用输入为空！", "确认");
                theMaterial = 0;
                theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                addTotal.Text = theTotal.ToString();
            }
        }
        public void LaborUnfocus(object sender, EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
            float newLabor;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");//有1~3位小数的正实数
            if (addLabor.Text != null)
            {
                if (regex.IsMatch(addLabor.Text.ToString()))
                {
                    float.TryParse(addLabor.Text, out newLabor);
                    if (newLabor >= 1000 && newLabor <= 100000)
                    {
                        theLabor = newLabor;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "人工费用填写不合理！", "确认");
                        theLabor = 0;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                }
                else
                {
                    DisplayAlert("警告", "人工费用输入含有非法字符！", "确认");
                    theLabor = 0;
                    theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                    addTotal.Text = theTotal.ToString();
                }
            }
            else
            {
                DisplayAlert("警告", "人工费用输入为空！", "确认");
                theLabor = 0;
                theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                addTotal.Text = theTotal.ToString();
            }
        }
        public void ManageUnfocus(object sender, EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
            float newManage;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");//有1~3位小数的正实数
            if (addManage.Text != null)
            {
                if (regex.IsMatch(addManage.Text.ToString()))
                {
                    float.TryParse(addManage.Text, out newManage);
                    if (newManage >= 1000 && newManage <= 100000)
                    {
                        theManage = newManage;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "管理费用填写不合理！", "确认");
                        theManage = 0;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                }
                else
                {
                    DisplayAlert("警告", "管理费用输入含有非法字符！", "确认");
                    theManage = 0;
                    theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                    addTotal.Text = theTotal.ToString();
                }
            }
            else
            {
                DisplayAlert("警告", "管理费用输入为空！", "确认");
                theManage = 0;
                theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                addTotal.Text = theTotal.ToString();
            }
        }
        public void OthersUnfocus(object sender, EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
            float newOthers;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");//有1~3位小数的正实数
            if (addOthers.Text != null)
            {
                if (regex.IsMatch(addOthers.Text.ToString()))
                {
                    float.TryParse(addOthers.Text, out newOthers);
                    if (newOthers >= 1000 && newOthers <= 100000)
                    {
                        theOthers = newOthers;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "其他费用填写不合理！", "确认");
                        theOthers = 0;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                }
                else
                {
                    DisplayAlert("警告", "其他费用输入含有非法字符！", "确认");
                    theOthers = 0;
                    theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                    addTotal.Text = theTotal.ToString();
                }
            }
            else
            {
                DisplayAlert("警告", "其他费用输入为空！", "确认");
                theOthers = 0;
                theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                addTotal.Text = theTotal.ToString();
            }
        }
        public void DesignUnfocus(object sender, EventArgs e)
        {
            btUpdate.IsVisible = true;
            btDelete.IsEnabled = true;
            float newDesign;
            Regex regex = new Regex("^[0-9]+(.[0-9]{1,3})?$");//有1~3位小数的正实数
            if (addDesign.Text != null)
            {
                if (regex.IsMatch(addDesign.Text.ToString()))
                {
                    float.TryParse(addDesign.Text, out newDesign);
                    if (newDesign >= 1000 && newDesign <= 100000)
                    {
                        theDesign = newDesign;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                    else
                    {
                        DisplayAlert("警告", "设计费用填写不合理！", "确认");
                        theDesign = 0;
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                        addTotal.Text = theTotal.ToString();
                    }
                }
                else
                {
                    DisplayAlert("警告", "设计费用输入含有非法字符！", "确认");
                    theDesign = 0;
                    theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                    addTotal.Text = theTotal.ToString();
                }
            }
            else
            {
                DisplayAlert("警告", "设计费用输入为空！", "确认");
                theDesign = 0;
                theTotal = theMaterial + theManage + theDesign + theOthers + theLabor;
                addTotal.Text = theTotal.ToString();
            }
        }
        async public void OnSave(object sender, EventArgs e)
        {
            DateTime theDate = addDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            bool bDesign = false;
            if (theDesign >= 1000 && theDesign <= 100000)
            {
                bDesign = true;
            }
            bool bMaterial = false;
            if (theMaterial >= 1000 && theMaterial <= 100000)
            {
                bMaterial = true;
            }
            bool bManage = false;
            if (theManage >= 1000 && theManage <= 100000)
            {
                bManage = true;
            }
            bool bOthers = false;
            if (theOthers >= 1000 && theOthers <= 100000)
            {
                bOthers = true;
            }
            bool bLabor = false;
            if (theLabor >= 1000 && theLabor <= 100000)
            {
                bLabor = true;
            }
            if(theTimeLimit>=10 && theTimeLimit<=120)
            {
                bDateLimit = true;
            }
            if (bDesign && bMaterial && bManage && bOthers && bLabor && bDateLimit)
            {
                if (await DisplayAlert("请确认", "工程总款为" + theTotal.ToString() + "元", "确认", "取消"))
                {
                    var Checks = DependencyService.Get<Interfaces.IProjectInfo>();
                    bool theResult = Checks.UpdateProjectInfos(thePhone,addDate.Date,theTimeLimit, theMaterial, theLabor, theManage, theDesign, theOthers, theTotal);
                    if (theResult == true)
                    {
                        var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                        bool theResults = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "修改工程签单");
                        await DisplayAlert("更新成功", "此客户工程签单更新成功！", "确认");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("更新失败", "此客户工程签单更新失败！", "确认");
                        await Navigation.PopAsync();
                    }
                }
            }
            else
            {
                await DisplayAlert("抱歉", "请确认填写项目是否完整且符合规范", "确认");
            }

        }
        async public void OnDelete(object sender,EventArgs e)
        {
            DateTime theDate = addDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

            if (theState=="已签合同")
            {
                 await DisplayAlert("抱歉", "该客户为已签合同客户，不能删除工单", "确认");
            }
            else
            {
                if(await DisplayAlert("确认","确认删除该客户工程签单？","确认","取消"))
                {
                    var Checks = DependencyService.Get<Interfaces.IProjectInfo>();
                    bool theResult = Checks.DeleteProjectInfos(thePhone);
                    if (theResult == true)
                    {
                        var Results = DependencyService.Get<Interfaces.IAddClientInfo>();
                        bool Check = Results.UpdatePriorityState("高优先", "已签定单", thePhone);
                        if (Check == true)
                        {
                            var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                            bool theResults = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "删除工程签单");

                            await DisplayAlert("成功", "成功删除该客户工程签单！", "确认");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("失败", "删除该客户工程签单失败！", "确认");
                            await Navigation.PopAsync();
                        }
                    }
                    else
                        await DisplayAlert("失败！", "该客户工程签单删除失败！", "确认");
                }
            }
        }
    }
}