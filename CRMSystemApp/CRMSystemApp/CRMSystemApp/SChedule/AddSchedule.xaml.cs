using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.SChedule
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddSchedule : ContentPage
	{
        string theSubject=null;
        DateTime theDate;
        TimeSpan theStartTime;
        TimeSpan theEndTime;
        string theColor=null;
        int theId;
		public AddSchedule ()
		{
			InitializeComponent ();
            int.TryParse(App.UserId, out theId);
		}
        public void OnCheckTimeEnd(object sender,EventArgs e)
        {
            if(addTimeEnd.Time<addTimeStart.Time)
            {
                CheckTimeEnd.Text = "时间选择不合理！";
            }
            else
            {
                CheckTimeEnd.Text = "";
                theEndTime = addTimeEnd.Time;
            }
        }
        public void OnSelectColor(object sender,EventArgs e)
        {
            theColor=addColor.SelectedItem.ToString();
        }
        public void TheSubjectUnfocus(object sender,EventArgs e)
        {
            if(addSubject.Text!=null)
            {
                Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
                if (regex.IsMatch(addSubject.Text.ToString()))
                {
                    if (addSubject.Text.Length <= 10)
                    {
                        theSubject = addSubject.Text.ToString();
                    }
                    else
                    {
                        Result.Text = "日程填写为空！";
                    }
                }
                else
                {
                    Result.Text = "日程填写为空！";
                }
            }
            else
            {
                Result.Text = "日程填写为空！";
            }
        }
        public void OnSave(object sender,EventArgs e)
        {
            theDate = addDate.Date;//日期
            theStartTime = addTimeStart.Time;//开始时间
            if(theEndTime==null||theColor==null||theSubject==null)
            {
                Result.Text = "填写不完整！";
            }
            else
            {
                var theChecks = DependencyService.Get<Interfaces.Schedule>();
                bool theResult = theChecks.AddTheSchedule(theId, theDate, theStartTime, theEndTime, theColor, theSubject);
                if (theResult == true)
                {
                    Result.Text = "添加成功！";
                    addSubject.Text = null;
                }
                else
                {
                    Result.Text = "添加失败！";
                }
            } 
        }
        public void OnView(object sender,EventArgs e)
        {
            ScheduleHolder.Navigation.PushAsync(new SChedule.SchedulePage());
        }
	}
}