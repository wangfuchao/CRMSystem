using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IContactLog
    {
        string[] GetTheLog(string thePhone);
        bool AddTheLog(string theDate, string thePhone, string theDetail);
    }
}
