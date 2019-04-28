using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRMSystemApp.SChedule
{
    
    public class ViewModel : ContentPage
    {
        public ScheduleAppointmentCollection AppointmentCollection { get; set; }
        int theId;
        public ICommand ScheduleCellLongPressed { get; set; }
        public ViewModel()
        {
            AppointmentCollection = new ScheduleAppointmentCollection();
            int.TryParse(App.UserId, out theId);
            var theChecks = DependencyService.Get<Interfaces.Schedule>();
            string[] theScheduele = theChecks.ViewSchedule(theId);//获取日程信息
            string theDate;
            string theStartTime;
            string theEndTime;
            string theColor;
            for(int i=0;i<theScheduele.Length;)
            {
                var clientMeeting = new Syncfusion.SfSchedule.XForms.ScheduleAppointment();

                theDate = theScheduele[i];
                DateTime currentDate;
                DateTime.TryParse(theDate.Substring(0, theDate.Length - 7), out currentDate);

                theStartTime = theScheduele[i + 1];
                TimeSpan StartTime;
                TimeSpan.TryParse(theStartTime, out StartTime);

                theEndTime = theScheduele[i + 2];
                TimeSpan EndTime;
                TimeSpan.TryParse(theEndTime, out EndTime);

                DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day,StartTime.Hours,StartTime.Minutes,StartTime.Seconds);
                DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day,EndTime.Hours,EndTime.Minutes,EndTime.Seconds);

                clientMeeting.StartTime = startTime;
                clientMeeting.EndTime = endTime;

                theColor = theScheduele[i + 3];
                if(theColor=="红色")
                {
                    clientMeeting.Color = Color.Red;
                }
                else if(theColor=="绿色")
                {
                    clientMeeting.Color = Color.Green;
                }
                else if (theColor == "黄色")
                {
                    clientMeeting.Color = Color.Yellow;
                }
                else if (theColor == "蓝色")
                {
                    clientMeeting.Color = Color.Blue;
                }

                clientMeeting.Subject = theScheduele[i+4];
                AppointmentCollection.Add(clientMeeting);
                i = i + 5;
            }
            ScheduleCellLongPressed = new Command<CellTappedEventArgs>(LongPressed);
        }
        private void LongPressed(CellTappedEventArgs args)
        {
            //长按，获取时间，通过Id和时间来删除数据库，
            //再通过，加载数据库数据来进行显示。
            var selectedTime = args.Datetime;
            args.Appointments.RemoveAt(args.Appointments.Count-1);
            //遍历List<object>中的各种元素。

            //AppointmentCollection.Remove(args.Appointments.IndexOf());
           // AppointmentCollection.IndexOf(args.Appointments);

            //int theNumber = AppointmentCollection.Count;//数量
            //AppointmentCollection.GetEnumerator();
            //AppointmentCollection.Equals(args);
            //for(int i=0;i<theNumber;i++)
            //{
            //    if()
            //    args.Appointments.Equals(AppointmentCollection.);
            //}
            

            //int Number=AppointmentCollection.Count;

            //args.Appointments.Clear();
            //var selectedDateTime = args.Datetime;
            //int theNumber = args.Appointments.Count;
            //for(int i=0;i<theNumber;i++)
            //{
            //    args.Appointments.
            //}
            ////string theContent = args.Appointments.FindLast().ToString();
            //DisplayAlert("确认", "删除此项？"+selectedDateTime.ToString(),"确认");

            //Navigation.PushAsync(new SChedule.Page1());
        }

    }
}
