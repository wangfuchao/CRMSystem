using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CRMSystemWebService
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        DBManipulation dBManipulation = new DBManipulation();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "验证用户登录")]
        public bool UserLogin(int UserId, string Password)
        {
            return dBManipulation.UserLogin(UserId, Password);
        }
        [WebMethod(Description ="验证用户登录及用户等级")]
        public string[] UserCheck(int UserId,string Password)
        {
            return dBManipulation.CheckClass(UserId, Password).ToArray();
        }
        [WebMethod(Description ="添加客户信息")]
        public bool InsertCustomerInfo(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType, string cPriority, int uId, string cSate,string clientType)
        {
            return dBManipulation.InsertCustomerInfo(dateTime, cName, cPhone, cPlot, cHouseType, cPriority, uId, cSate,clientType);
        }
        [WebMethod(Description = "查询客户表中主键")]
        public bool CheckPhone(string cPhone)
        {
            return dBManipulation.CheckPhone(cPhone);
        }
        [WebMethod(Description ="查询客户部分信息")]
        public string[] SelectSthClientInfo(int uid)
        {
            return dBManipulation.SelectSthClientInfo(uid).ToArray();
        }
        [WebMethod(Description ="查询客户关键信息")]
        public string[] SelectClientInfo(int uid)
        {
            return dBManipulation.SelectClientInfo(uid).ToArray();
        }
        [WebMethod(Description ="删除某一客户信息")]
        public bool DeletePersonalInfo(string phone)
        {
            return dBManipulation.DeletePersonalInfo(phone);
        }
        [WebMethod(Description ="获取某个客户信息")]
        public string[] SelectPersonalInfo(string phone)
        {
            return dBManipulation.SelectPersonalInfo(phone).ToArray();
        }
        [WebMethod(Description ="更新客户信息优先级和线索状态")]
        public bool UpdatePriorityState(string priority, string state, string phone)
        {
            return dBManipulation.UpdatePriorityState(priority, state, phone);
        }
        [WebMethod(Description ="添加客户联系备忘")]
        public bool InsertTheLog(string theDate, string thePhone, string theDetail)
        {
            return dBManipulation.InsertTheLog(theDate, thePhone, theDetail);
        }
        [WebMethod(Description ="获取客户联系备忘")]
        public string[] GetTheLogs(string thePhone)
        {
            return dBManipulation.GetTheLogs(thePhone).ToArray();
        }
        [WebMethod(Description ="更新客户信息")]
        public bool UpdateClientInfos(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType, int uId,string cClientType)
        {
            return dBManipulation.UpdateClientInfos(dateTime, cName, cPhone, cPlot, cHouseType, uId,cClientType);
        }
        [WebMethod(Description ="二维码扫描接收客户")]
        public bool ScanReceiveClient(string phone,int id,DateTime dateTime)
        {
            return dBManipulation.ScanReceiveClient(phone, id,dateTime);
        }
        [WebMethod(Description ="核对签单表主键是否冲突")]
        public bool CheckContract(string phone)
        {
            return dBManipulation.CheckContractInfo(phone);
        }
        [WebMethod(Description ="新建客户签单信息")]
        public bool InsertContract(DateTime dateTime, string Name, string Phone, string Address, string houseType, float Area, float Budget, float Payment, int userId)
        {
            return dBManipulation.InsertContractInfo(dateTime, Name, Phone,Address, houseType, Area, Budget, Payment, userId);
        }
        [WebMethod(Description ="更新客户签单信息")]
        public bool UpdateContractInfo(DateTime dateTime, string Name, string Phone, string Address, string houseType, float Area, float Budget, float Payment, int userId)
        {
            return dBManipulation.UpdateContractInfo(dateTime, Name, Phone, Address, houseType, Area, Budget, Payment, userId);
        }
        [WebMethod(Description ="查询客户签单信息")]
        public string[] SelectContractInfo(string phone)
        {
            return dBManipulation.SelectContractInfo(phone).ToArray();
        }
        [WebMethod(Description ="删除客户签单信息")]
        public bool DeleteContractInfo(string phone)
        {
            return dBManipulation.DeleteContractInfo(phone);
        }

        [WebMethod(Description ="新增工程签单信息")]
        public bool InsertProjectInfo(string name, string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total, int userId)
        {
            return dBManipulation.InsertProjectInfo(name, phone, dateTime, timeLimit, material, labor, manage, design, others, total, userId);
        }
        [WebMethod(Description = "查询工程签单信息")]
        public string[] SelectProjectListInfo(string phone)
        {
            return dBManipulation.SelectProjectListInfo(phone).ToArray();
        }
        [WebMethod(Description ="更新工程签单信息")]
        public bool UpdateProjectListInfo(string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total)
        {
            return dBManipulation.UpdateProjectListInfo(phone, dateTime, timeLimit, material, labor, manage, design, others, total);
        }
        [WebMethod(Description = "删除工程签单信息")]
        public bool DeleteProjectListInfo(string phone)
        {
            return dBManipulation.DeleteProjectListInfo(phone);
        }
        [WebMethod(Description ="验证业务明细是否有记录，用于接收线索时使用")]
        public bool CheckBusiness(string phone)
        {
            return dBManipulation.CheckBusiness(phone);
        }
        [WebMethod(Description ="添加业务明细信息")]
        public bool InsertBusinessDetail(string date, string phone, string state)
        {
            return dBManipulation.InsertBusinessDetail(date, phone, state);
        }
        [WebMethod(Description ="获取业务明细信息")]
        public string[] SelectBusinessInfo(string phone)
        {
            return dBManipulation.SelectBusinessInfo(phone).ToArray();
        }
        [WebMethod(Description ="删除业务明细信息")]
        public bool DeleteBusinessInfo(string phone)
        {
            return dBManipulation.DeleteBusinessInfo(phone);
        }
        [WebMethod(Description ="接收要上传的图片")]
        public string UploadImg(byte[] fileBytes, string phone)
        {
            try
            {
                string filePath = Server.MapPath(".") + "\\EmpImage\\" + phone + ".jpg";//图片要保存的路径及文件名
                using (MemoryStream memoryStream = new MemoryStream(fileBytes))//定义并实例化一个内存流，以存放提交上来的字节数组
                {
                    using (FileStream fileUpload = new FileStream(filePath, FileMode.Create))//实际定义文件对象，保存上载的文件
                    {
                        memoryStream.WriteTo(fileUpload);//把内存流里的数据写入物理文件
                    }
                }
                //GetSqlExcuteNonQuery是我写好的一个执行command的ExcuteNonQuery()方法
                //GetSqlExcuteNonQuery(string.Format("insert into EmpImg values('{0}','{1}')", id, filePath)); //将该图片保存的文件路径写入数据库
                return dBManipulation.InsertImagePath(phone, filePath);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        [WebMethod(Description = ("传递要下载的图片"))]
        public byte[] LoadImg(string id)
        {
            try
            {
                string[] path = dBManipulation.GetImagePath(id).ToArray();//自己定义的方法
                string thePath = path[0];
                FileInfo imgfile = new FileInfo(thePath);
                byte[] imgbyte = new byte[imgfile.Length];//初始化用于存放图片的字节数组
                using (FileStream imgstream = imgfile.OpenRead())//初始化读取图片内容的文件流
                {
                    imgstream.Read(imgbyte, 0, Convert.ToInt32(imgfile.Length));//将图片内容通过文件流读取到字节数组
                    return imgbyte;
                }
            }
            catch
            {
                return null;
            }
        }

        /*********************************************************/
        //数据统计
        [WebMethod(Description ="统计线索")]
        public string[] GetClueInfo(int userId)
        {
            return dBManipulation.GetClueInfo(userId).ToArray();
        }
        [WebMethod(Description ="获取日期和状态")]
        public string[] GetDateState(int theId)
        {
            return dBManipulation.GetDateState(theId).ToArray();
        }
        /**************************************************************/
        /*************************************************************/
        //我的日程
        [WebMethod(Description ="添加日程")]
        public bool AddSchedule(int UserId, DateTime theDate, string theStartTime, string theEndTime, string theColor, string theSubject)
        {
            return dBManipulation.AddSchedule(UserId, theDate, theStartTime, theEndTime, theColor, theSubject);
        }
        [WebMethod(Description ="查看日程")]
        public string[]GetSchedule(int theId)
        {
            return dBManipulation.GetSchedule(theId).ToArray();
        }
        [WebMethod(Description ="删除日程")]
        public bool DeleteSchedule(int theId, DateTime theDate, string theStartTime, string theEndTime)
        {
            return dBManipulation.DeleteSchedule(theId, theDate, theStartTime, theEndTime);
        }
        [WebMethod(Description ="获取业绩指标")]
        public string[] GetPersonalgoal(string theMonth)
        {
            return dBManipulation.GetPersonalgoal(theMonth).ToArray();
        }

        /**************************************************************/
        //PC端
        [WebMethod(Description ="组织结构树")]
        public List<string> GetTreeInfo()
        {
            return dBManipulation.GetNameDistict();
        }
        [WebMethod(Description ="获取职员表中的关键信息")]
        public List<string> GetStaffInfo()
        {
            return dBManipulation.GetStaffInfo();
        }
        [WebMethod(Description ="新增职员信息")]
        public bool AddStaff(string thePassword, int theClass, string theDistinct, string theName, string thePhone)
        {
            return dBManipulation.AddStaff(thePassword, theClass, theDistinct, theName, thePhone);
        }
        [WebMethod(Description ="更新职员信息")]
        public bool UpdateStaff(int theId, string thePassword, string theArea, string theName, string thePhone)
        {
            return dBManipulation.UpdateStaff(theId, thePassword, theArea, theName, thePhone);
        }
        [WebMethod(Description ="删除职员信息")]
        public bool DeleteStaff(int theId)
        {
            return dBManipulation.DeleteStaff(theId);
        }
        [WebMethod(Description ="获取职员Id,Name")]
        public List<string> GetIdName(string distinct)
        {
            return dBManipulation.GetIdName(distinct);
        }
        [WebMethod(Description ="获取员工信息")]
        public string[] GetStaffInfos(int theId)
        {
            return dBManipulation.GetStaffInfos(theId).ToArray();
        }
        [WebMethod(Description ="获取客户信息")]
        public List<string> TheClientInfo(int theUserId)
        {
            return dBManipulation.TheClientInfo(theUserId);
        }
        [WebMethod(Description ="获取客户业务明细")]
        public List<string> TheClientBusinessInfo(string thePhone)
        {
            return dBManipulation.TheClientBusinessInfo(thePhone);
        }
        [WebMethod(Description ="添加消息通知")]
        public bool AddNewsInfo(int theId, string thePost, string theDate, string theTheme,string theHead, string theContent)
        {
            return dBManipulation.AddNewsInfo(theId, thePost, theDate, theTheme,theHead, theContent);
        }
        [WebMethod(Description ="获取消息通知")]
        public string[] TheNewsInfo()
        {
            return dBManipulation.TheNewsInfo().ToArray();
        }
        [WebMethod(Description ="更新消息通知")]
        public bool UpdateNewsInfo(int theId, string theDate, string theTheme,string theHead, string theDetail)
        {
            return dBManipulation.UpdateNewsInfo(theId, theDate, theTheme,theHead, theDetail);
        }
        [WebMethod(Description ="删除消息通知")]
        public bool DeleteNewsInfo(int theId, string theDate)
        {
            return dBManipulation.DeleteNewsInfo(theId, theDate);
        }
        [WebMethod(Description ="数据统计，统计本月所有客户状态信息")]
        public List<string> GetAllClientsStateInfo()
        {
            return dBManipulation.GetAllClientsStateInfo();
        }
        [WebMethod(Description ="数据统计,对职员表和员工表进行连接查询")]
        public List<string> JoinQuery()
        {
            return dBManipulation.JoinQuery();
        }
        [WebMethod(Description ="添加业绩指标")]
        public bool AddIndex(int theId, string theMonth, int theOrder, int theProject, int theContract)
        {
            return dBManipulation.AddIndex(theId, theMonth, theOrder, theProject, theContract);
        }
        [WebMethod(Description ="更新业绩指标")]
        public bool UpDateIndex(string theMonth, int theOrder, int theProject, int theContract)
        {
            return dBManipulation.UpDateIndex(theMonth, theOrder, theProject, theContract);
        }
        [WebMethod(Description ="更改管理员总经理密码")]
        public bool AlterTheRootPassword(int theId, string thePassword)
        {
            return dBManipulation.AlterTheRootPassword(theId, thePassword);
        }
        [WebMethod(Description ="查询职工是否有关联客户")]
        public bool StaffAssClient(int theId)
        {
            return dBManipulation.StaffAssClient(theId);
        }
        [WebMethod(Description ="删除合同图片路径")]
        public bool DeleteImagePath(string thePhone)
        {
            return dBManipulation.DeleteImagePath(thePhone);
        }


    }
}
