using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IDataStatistic
    {
        string[] GetClueInfos(int userId);
        string[] GetDateState(int userId);
    }
}
