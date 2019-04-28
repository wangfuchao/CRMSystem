using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IAddClientInfo
    {
        //添加客户信息
        bool AddClientInfos(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType,string cPriority, int uId,string cState,string cClientType);
        //核对主键是否冲突
        bool CheckPhone(string cPhone);
        //更新优先级和线索状态
        bool UpdatePriorityState(string thePriority, string theState,string thePhone);
        bool UpdateClientInfo(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType, int uId,string cClientType);
        bool DeleteClientInfo(string phone);
    }
}
