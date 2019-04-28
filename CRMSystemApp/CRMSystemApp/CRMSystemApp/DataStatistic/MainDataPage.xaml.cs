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
	public partial class MainDataPage : ContentPage
	{
        string theMonth=null;
        int theId;
        string[] theDateState;
        int theOrders;
        int theProjects;
        int theContracts;
		public MainDataPage ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out theId);
            //连接数据库
            var Checks = DependencyService.Get<Interfaces.IDataStatistic>();
            theDateState = Checks.GetDateState(theId);
           
            addMonth.SelectedIndex=DateTime.Now.Month-1;
        }
        public void PickMonth(object sender, EventArgs e)
        {
            theMonth = addMonth.SelectedItem.ToString();//选择月份
            DateTime theMonthDate;
            string theDate;
            string theState;
            int theClue = 0;
            int theBook = 0;
            int theProject = 0;
            int theContract = 0;
            int theLost = 0;
            for (int i = 0; i < theDateState.Length;)
            {
                theDate = theDateState[i];
                DateTime.TryParse(theDate, out theMonthDate);
                if (theMonthDate.Month == 1 && theMonth == "一月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState=="稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if(theState=="客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 2 && theMonth == "二月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 3 && theMonth == "三月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 4 && theMonth == "四月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 5 && theMonth == "五月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 6 && theMonth == "六月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 7 && theMonth == "七月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 8 && theMonth == "八月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 9 && theMonth == "九月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                if (theMonthDate.Month == 10 && theMonth == "十月")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪" || theState == "稳步推进")
                    {
                        theClue++;
                    }
                    if (theState == "已签定单")
                    {
                        theBook++;
                    }
                    if (theState == "已签工单")
                    {
                        theProject++;
                    }
                    if (theState == "上传合同")
                    {
                        theContract++;
                    }
                    if (theState == "客户丢失")
                    {
                        theLost++;
                    }
                }
                i = i + 2;
            }
            int theTotalClue = 0;
            theTotalClue = theClue + theBook + theProject + theContract + theLost;
            ClueNumber.Text = theTotalClue.ToString();
            BookNumber.Text = theBook.ToString();
            theOrders = theBook;
            ProjectNumber.Text = theProject.ToString();
            theProjects = theProject;
            ContractNumber.Text = theContract.ToString();
            theContracts = theContract;
        }
        async void ClueInfo_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.FromHex("#E8E8E8");
            StackLayout1.BackgroundColor = Color.White;
            await ContentHolder.Navigation.PushAsync(new DataStatistic.CluePage());
            StackLayout0.BackgroundColor = Color.White;
        }
        async void ContractInfo_Tapped(object sender, EventArgs e)
        {
            StackLayout0.BackgroundColor = Color.White;
            StackLayout1.BackgroundColor = Color.FromHex("#E8E8E8");
            await ContentHolder.Navigation.PushAsync(new DataStatistic.KPIPage(theOrders,theProjects,theContracts));
            StackLayout1.BackgroundColor = Color.White;
        }

    }
}