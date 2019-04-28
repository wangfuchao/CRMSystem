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
	public partial class NewProjectPage : ContentPage
	{
        string theName;
        string thePhone;
        DateTime theDate;
        int theDateLimit;
        float theMaterial=0;
        float theLabor=0;
        float theManage=0;
        float theDesign=0;
        float theOthers=0;
        float theTotal=0;
        bool bDateLimit = false;
        int theId;
        public NewProjectPage (string name,string phone)
		{
            Title = "新建工单";
			InitializeComponent ();
            theName = name;
            thePhone = phone;
            addName.Text = name;
            addPhone.Text = phone;
            int.TryParse(App.UserId, out theId);
            theDate = addDate.Date;
        }
        public void DateLimitUnfocus(object sender, EventArgs e)
        {
            int newDateLimit;
            Regex regex = new Regex("^([1-9][0-9]*){1,3}$");//非零的正整数
            if (addDateLimit.Text != null)
            {
                if (regex.IsMatch(addDateLimit.Text.ToString()))
                {
                    int.TryParse(addDateLimit.Text, out newDateLimit);
                    if (newDateLimit >= 10 && newDateLimit <= 120)
                    {
                        theDateLimit = newDateLimit;
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
                        theTotal = theMaterial + theManage + theDesign + theOthers + theLabor ;
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
        async public void OnSave(object sender,EventArgs e)
        {
            DateTime theDate = addDate.Date;
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            theDate = new DateTime(addDate.Date.Year, addDate.Date.Month, addDate.Date.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            bool bDesign = false;
            if(theDesign>=1000 && theDesign<=100000)
            {
                bDesign = true;
            }
            bool bMaterial = false;
            if(theMaterial>=1000 && theMaterial<=100000)
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
            if(bDesign && bMaterial && bManage && bOthers && bLabor && bDateLimit)
            {
                if(await DisplayAlert("请确认","工程总款为"+theTotal.ToString()+"元","确认","取消"))
                {
                    var Checks = DependencyService.Get<Interfaces.IProjectInfo>();
                    bool theResult=Checks.AddProjectInfo(theName, thePhone, theDate, theDateLimit, theMaterial, theLabor, theManage, theDesign, theOthers, theTotal, theId);
                    if (theResult == true)
                    {
                        await DisplayAlert("添加成功", "此客户工程清单成功添加！", "确认");
                        var Results = DependencyService.Get<Interfaces.IAddClientInfo>();
                        bool Check = Results.UpdatePriorityState("高优先", "已签工单", thePhone);
                        if (Check == true)
                        {
                            var theChecks = DependencyService.Get<Interfaces.IBusinessDetail>();
                            bool theResults = theChecks.AddBusinessInfo(theDate.ToString(), thePhone, "新建工程签单");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("失败", "更新线索失败！", "确认");
                            await Navigation.PopAsync();
                        }
                    }
                    else
                    {
                        await DisplayAlert("添加失败", "此客户工单添加失败！", "确认");
                        await Navigation.PopAsync();
                    }
                    //调用接口，添加信息。
                    //调用接口，更新跟踪状态。
                    //跳转至上一页面
                }
            }
            else
            {
                await DisplayAlert("抱歉", "请确认填写项目是否完整且符合规范", "确认");
            }

        }
    }
}