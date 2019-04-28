using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CRMSystemApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetContractInfo))]
namespace CRMSystemApp.Droid
{
    class GetContractInfo:Interfaces.IAddContractInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        public bool AddContract(DateTime dateTime, string Name, string Phone, string Address, string houseType, float Area, float Budget, float Payment, int userId)
        {
            return service.InsertContract(dateTime, Name, Phone,Address, houseType, Area, Budget, Payment, userId);
        }
        public bool CheckContract(string phone)
        {
            return service.CheckContract(phone);
        }
        //更新客户签单信息
        public bool UpdateContract(DateTime dateTime, string Name, string phone, string Address, string houseType, float Area, float Budget, float Payment, int userId)
        {
            return service.UpdateContractInfo(dateTime, Name, phone, Address, houseType, Area, Budget, Payment, userId);
        }
        //查询客户签单信息
        public string[] SelectContract(string phone)
        {
            return service.SelectContractInfo(phone);
        }
        //删除客户签单信息
        public bool DeleteContract(string phone)
        {
            return service.DeleteContractInfo(phone);
        }
    }
}