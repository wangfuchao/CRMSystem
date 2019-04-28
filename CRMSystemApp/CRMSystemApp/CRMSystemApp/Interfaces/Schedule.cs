using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface Schedule
    {
        //添加日程
        bool AddTheSchedule(int UserId, DateTime theDate, TimeSpan theStartTime, TimeSpan theEndTime, string theColor, string theSubject);
        //查看日程
        string[] ViewSchedule(int UserId);
    }
}
