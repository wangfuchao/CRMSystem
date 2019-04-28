using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IProjectInfo
    {
        //新增工程签单信息
        bool AddProjectInfo(string name, string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total, int userId);
        //查询工程签单信息
        string[] SelectProjectInfos(string phone);
        //更新工程签单信息
        bool UpdateProjectInfos(string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total);
        //删除工程签单信息
        bool DeleteProjectInfos(string phone);
    }
}
