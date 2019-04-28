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

[assembly: Dependency(typeof(GetProjectInfo))]
namespace CRMSystemApp.Droid
{
    class GetProjectInfo:Interfaces.IProjectInfo
    {
        WebReference.WebService service = new WebReference.WebService();
        //添加工程清单信息
        public bool AddProjectInfo(string name, string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total, int userId)
        {
            return service.InsertProjectInfo(name, phone, dateTime, timeLimit, material, labor, manage, design, others, total, userId);
        }
        //查询工程清单信息
        public string[] SelectProjectInfos(string phone)
        {
            return service.SelectProjectListInfo(phone);
        }
        //更新工程清单信息
        public bool UpdateProjectInfos(string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total)
        {
            return service.UpdateProjectListInfo(phone, dateTime, timeLimit, material, labor, manage, design, others, total);
        }
        //删除工程清单信息
        public bool DeleteProjectInfos(string phone)
        {
            return service.DeleteProjectListInfo(phone);
        }
    }
}