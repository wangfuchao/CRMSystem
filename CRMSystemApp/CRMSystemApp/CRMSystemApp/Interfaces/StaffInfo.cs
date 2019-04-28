using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface StaffInfo
    {
        string[] GetTheStaffInfo(int theId);
        bool UpdateStaffInfo(int theId, string thePassword, string theArea, string theName, string thePhone);
    }
}
