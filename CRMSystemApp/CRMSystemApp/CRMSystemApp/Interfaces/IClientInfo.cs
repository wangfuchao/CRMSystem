using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IClientInfo
    {
        string[] SelectClientInfos(int uid);
        string[] SelectDetailInfo(string phone);
        bool HandOverClient(string phone, int uid,DateTime dateTime);
    }
}
