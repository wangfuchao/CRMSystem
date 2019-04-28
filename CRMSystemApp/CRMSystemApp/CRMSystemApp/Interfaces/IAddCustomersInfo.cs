using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IAddCustomersInfo
    {
        bool AddCustomersInfos(DateTime dateTime, string cName, string cPhone, float cArea, string cStituation, int uId);
        bool CheckPhone(string phoneNumber);
    }
}
