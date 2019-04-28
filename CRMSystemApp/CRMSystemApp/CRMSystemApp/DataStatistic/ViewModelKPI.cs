using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMSystemApp.DataStatistic
{
    
    public class ViewModelKPI
    {
        public List<KPI> Data { get; set; }
        public List<KPI> Data1 { get; set; }
        int theId;
        string[] theDateState;
        string theMonth;
        int theOrders;
        int theProjects;
        int theContracts;
        public ViewModelKPI()
        {
            int.TryParse(App.UserId, out theId);
            //连接数据库
            var Checks = DependencyService.Get<Interfaces.IDataStatistic>();
            theDateState = Checks.GetDateState(theId);

            theMonth = DateTime.Now.Date.Month.ToString();
            DateTime theMonthDate;
            string theDate;
            string theState;
            int theClue = 0;
            int theBook = 0;
            int theProject = 0;
            int theContract = 0;
            for (int i = 0; i < theDateState.Length;)
            {
                theDate = theDateState[i];
                DateTime.TryParse(theDate, out theMonthDate);
                if (theMonthDate.Month == 1 && theMonth == "1")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 2 && theMonth == "2")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 3 && theMonth == "3")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 4 && theMonth == "4")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 5 && theMonth == "5")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 6 && theMonth == "6")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 7 && theMonth == "7")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 8 && theMonth == "8")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 9 && theMonth == "9")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                if (theMonthDate.Month == 10 && theMonth == "10")
                {
                    theState = theDateState[i + 1];
                    if (theState == "正在跟踪")
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
                }
                i = i + 2;
            }
            theOrders = theBook;
            theProjects = theProject;
            theContracts = theContract;

            Data = new List<KPI>()
            {
                new KPI { KPIName = "新建定单", KPINumber = theOrders },
                new KPI { KPIName = "新建工单", KPINumber = theProject },
                new KPI { KPIName = "新建合同", KPINumber = theContracts },
            };

            //连接数据库

            string theMonths = DateTime.Now.Date.Month.ToString();
            var theChecks = DependencyService.Get<Interfaces.IPersonalGoal>();
            string[] theGoals = theChecks.GetPersonalGoal(theMonths);
            string Orders=null;
            string Projects=null;
            string Contracts=null;
            for (int i = 0; i < theGoals.Length;)
            {
                Orders = theGoals[i];
                Projects = theGoals[i + 1];
                Contracts = theGoals[i + 2];
                i = i + 3;
            }
            int OrderNumbers;
            int ProjectNumbers;
            int ContractNumbers;
            int.TryParse(Orders, out OrderNumbers);
            int.TryParse(Projects, out ProjectNumbers);
            int.TryParse(Contracts, out ContractNumbers);

            Data1 = new List<KPI>()
            {
                new KPI { KPIName = "新建订单", KPINumber = OrderNumbers },
                new KPI { KPIName = "新建工单", KPINumber = ProjectNumbers },
                new KPI { KPIName = "新建合同", KPINumber = ContractNumbers},
            };
        }
    }
}
