using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IBusinessDetail
    {
        bool CheckBusinessInfo(string phone);
        bool AddBusinessInfo(string date, string phone, string state);
        bool DeleteBusinessInfos(string phone);
        string[] SelectBusiness(string phone);
    }
}
