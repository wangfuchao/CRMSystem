using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IAddContractInfo
    {
        bool AddContract(DateTime dateTime, string Name, string Phone,string Address, string houseType, float Area, float Budget, float Payment, int userId);
        bool CheckContract(string phone);//不用核对电话号码。
        //更新签单信息
        bool UpdateContract(DateTime dateTime, string Name, string phone, string Address, string houseType, float Area, float Budget, float Payment, int userId);
        //删除签单
        bool DeleteContract(string phone);
        //查询客户签单信息
        string [] SelectContract(string phone);
    }
}
