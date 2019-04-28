using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMSystemWebService
{
    //一个数据库操作的类，所有对数据库的操作在此类中
    public class DBManipulation : IDisposable
    {
        public static SqlConnection sqlCon;//用于连接数据库
        private String ConServerStr = @"Data Source=ZEOF-PC;Initial Catalog=CRMSystem;Persist Security Info=True;User ID=sa;Password=123456";//数据库连接字符串


        //默认构造函数
        public DBManipulation()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = ConServerStr;
                sqlCon.Open();
            }
        }
        //关闭销毁函数，相当于Close()
        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
                sqlCon = null;
            }
        }

        //验证用户登录
        public bool UserLogin(int UserId, string Password)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select * from Table_Users where UserId='" + UserId + "'and Password='" + Password + "'";
                cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                
            }
        }
        //验证用户登录以及用户分级
        public List<string> CheckClass(int UserId,string Password)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Class from Table_Users where UserId='" + UserId + "' and Password='"+Password+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //添加客户信息
        public bool InsertCustomerInfo(DateTime dateTime,string cName,string cPhone,string cPlot,string cHouseType,string cPriority,int uId,string cSate,string ClientType)
        {
            try
            {
                string sql = "insert into Table_ClientInfo values ('" + dateTime + "','" + cName + "','"+cPhone+"','"+cPlot+"','"+cHouseType+"','"+cPriority+"','"+uId+"','"+cSate+"','"+ClientType+"')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //更新客户信息
        public bool UpdateClientInfos(DateTime dateTime, string cName, string cPhone, string cPlot, string cHouseType, int uId,string cClientType)
        {
            try
            {
                string sql = "update Table_ClientInfo set Date='" + dateTime + "',CName='"+cName+"',CPlot='"+cPlot+"',HouseType='"+cHouseType+"', UserId ='" + uId + "',ClientType='"+cClientType+"' where  CPhone='" + cPhone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //查询客户表中主键是否重复
        public bool CheckPhone(string cPhone)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select * from Table_ClientInfo where cPhone='" + cPhone + "'";
                cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();

            }
        }
        //获取所有客户信息:姓名、电话号码、优先级、线索状态
        public List<string> SelectSthClientInfo(int uid)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select CName,CPhone,HouseType,Priority,State from Table_ClientInfo where UserId='"+uid+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //获取所有客户信息：建立日期、姓名、电话号码、小区、房屋类型
        public List<string> SelectClientInfo(int uid)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,CName,CPhone,CPlot,HouseType from Table_ClientInfo where UserId='"+uid+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());

                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //删除某一客户信息
        public bool DeletePersonalInfo(string phone)
        {
            try
            {
                string sql = "delete from Table_ClientInfo where CPhone='"+phone+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //获取某一客户所有信息
        public List<string> SelectPersonalInfo(string phone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from Table_ClientInfo where CPhone='"+phone+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                    list.Add(reader[6].ToString());
                    list.Add(reader[7].ToString());
                    list.Add(reader[8].ToString());

                }

                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //更新客户优先级和线索状态
        public bool UpdatePriorityState(string priority,string state,string phone)
        {
            try
            {
                string sql = "update Table_ClientInfo set Priority ='" + priority + "',State='"+state+"' where  CPhone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //添加客户联系备忘
        public bool InsertTheLog(string theDate,string thePhone,string theDetail)
        {
            try
            {
                string sql = "insert into Table_ContactLog values ('" + theDate + "','" + thePhone + "','" + theDetail + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //获取客户联系备忘
        public List<string> GetTheLogs(string thePhone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,Detail from Table_ContactLog where Phone='" + thePhone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //二维码扫描接收客户
        public bool ScanReceiveClient(string phone,int id,DateTime dateTime)
        {
            try
            {
                string sql = "update Table_ClientInfo set Date='"+dateTime+"',Priority='低优先', UserId ='"+id+"',State='正在跟踪' where  CPhone='"+phone+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //查询签订表中主键是否冲突
        public bool CheckContractInfo(string phone)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select * from Table_ContractInfo where Phone='" + phone + "'";
                cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();

            }
        }
        //新建客户签单信息
        public bool InsertContractInfo(DateTime dateTime, string Name, string Phone,string Address, string houseType, float Area, float Budget, float Payment, int userId)
        {
            try
            {
                string sql = "insert into Table_ContractInfo values ('" + dateTime + "','" + Name + "','" + Phone + "','"+Address+"','" + houseType + "','" + Area + "','" + Budget + "','" + Payment + "','" + userId + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //更新客户签单信息
        public bool UpdateContractInfo(DateTime dateTime, string Name, string Phone, string Address, string houseType, float Area, float Budget, float Payment, int userId)
        {
            try
            {
                string sql = "update Table_ContractInfo set Date ='" + dateTime + "',Name='" + Name + "',Address='"+Address+ "',HouseType='"+houseType+ "',Area='"+Area+"',Budget='"+Budget+"',Payment='"+Payment+"' where  Phone='" + Phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //查询客户签单所有信息
        public List<string> SelectContractInfo(string phone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from Table_ContractInfo where Phone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                    list.Add(reader[6].ToString());
                    list.Add(reader[7].ToString());
                    list.Add(reader[8].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //删除某一客户签单信息
        public bool DeleteContractInfo(string phone)
        {
            try
            {
                string sql = "delete from Table_ContractInfo where Phone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //新建客户工程签单信息
        public bool InsertProjectInfo(string name,string phone,DateTime dateTime,int timeLimit,float material,float labor,float manage,float design,float others,float total,int userId)
        {
            try
            {
                string sql = "insert into Table_ProjectList values ('" + name + "','" + phone + "','" + dateTime + "','" + timeLimit + "','" + material + "','" + labor + "','" + manage + "','" + design + "','" + others + "','"+total+"','"+userId+"')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //查询客户工程签单信息
        public List<string> SelectProjectListInfo(string phone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from Table_ProjectList where Phone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                    list.Add(reader[6].ToString());
                    list.Add(reader[7].ToString());
                    list.Add(reader[8].ToString());
                    list.Add(reader[9].ToString());
                    list.Add(reader[10].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //更新客户工程签单信息
        public bool UpdateProjectListInfo(string phone, DateTime dateTime, int timeLimit, float material, float labor, float manage, float design, float others, float total)
        {
            try
            {
                string sql = "update Table_ProjectList set Date ='" + dateTime + "',TimeLimit='" + timeLimit + "',Material='" + material + "',Labor='" + labor + "',Manage='" + manage + "',Design='" + design + "',Others='"+others+"',Total='"+total+"' where  Phone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //删除客户工程签单信息
        public bool DeleteProjectListInfo(string phone)
        {
            try
            {
                string sql = "delete from Table_ProjectList where Phone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //添加上传图片路径信息
        public string InsertImagePath(string phone,string path)
        {
            try
            {
                string sql = "insert into Table_UploadImage values ('" + phone + "','"+path+"')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return "OK";
            }
            catch (Exception)
            {
                return "Fail";
            }
        }
        //获取要查看照片的路径信息
        public List<string> GetImagePath(string theId)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Path from Table_UploadImage where Id='" + theId + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //验证客户业务明细是否有记录,主要是用于接收客户线索时使用。
        public bool CheckBusiness(string phone)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select * from Table_BusinessDetail where Phone='"+phone+"'";
                cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();

            }
        }
        //添加客户业务明细
        public bool InsertBusinessDetail(string date,string phone,string state)
        {
            try
            {
                string sql = "insert into Table_BusinessDetail values ('" + date + "','" + phone + "','"+state+"')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //获取业务明细
        public List<string> SelectBusinessInfo(string phone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from Table_BusinessDetail where Phone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //删除业务明细
        public bool DeleteBusinessInfo(string phone)
        {

            try
            {
                string sql = "delete from Table_BusinessDetail where Phone='"+phone+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /******************************************************/
        //数据统计
        public List<string> GetClueInfo(int userId)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select State from Table_ClientInfo where UserId='" + userId + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //获取客户表的时间和状态
        public List<string>GetDateState(int theId)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,State from Table_ClientInfo where UserId='" + theId + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }


        /**********************************************************/
        //我的日程
        //新建日程
        public bool AddSchedule(int UserId,DateTime theDate,string theStartTime,string theEndTime,string theColor,string theSubject)
        {
            try
            {
                string sql = "insert into Table_Schedule values ('" + UserId + "','" + theDate + "','" + theStartTime + "','"+theEndTime+"','"+theColor+"','"+theSubject+"')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //读取日程
        public List<string>GetSchedule(int theId)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,StartTime,EndTime,Color,Subject from Table_Schedule where UserId='"+theId+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        //删除日程
        public bool DeleteSchedule(int theId,DateTime theDate,string theStartTime,string theEndTime)
        {
            try
            {
                string sql = "delete from Table_Schedule where UserId='" + theId + "' and Date='"+theDate+"' and StartTime='"+theStartTime+"' and EndTime='"+theEndTime+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //获取业绩指标
        public List<string> GetPersonalgoal(string theMonth)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select OrderNumber,ProjectNumber,ContractNumber from Table_PersonalGoal where Month='"+theMonth+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }


        /********************************************************/
        //PC端
        //统计员工情况,组织结构树
        public List<string> GetNameDistict()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select UserID,Distincts,Name from Table_Users";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        public List<string> GetStaffInfos(int theId)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select UserID,Distincts,Name,Phone from Table_Users where UserID='"+theId+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //获取职员表的关键信息,Id,地区、姓名、电话号码
        public List<string> GetStaffInfo()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select UserID,Distincts,Name,Phone from Table_Users";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //新增职员,添加职员信息
        public bool AddStaff(string thePassword,int theClass,string theDistinct,string theName,string thePhone)
        {
            try
            {
                string sql = "insert into Table_Users (Password,Class,Distincts,Name,Phone) values  ('" + thePassword + "','" + theClass + "','"+theDistinct+"','"+theName+"','"+thePhone+"')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //修改职员,更新职员信息
        public bool UpdateStaff(int theId,string thePassword,string theArea,string theName,string thePhone)
        {
            try
            {
                string sql = "update Table_Users set Password ='" + thePassword + "',Distincts='" + theArea + "',Name='" + theName + "',Phone='" + thePhone + "' where UserID='"+theId+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //删除职员
        public bool DeleteStaff(int theId)
        {
            try
            {
                string sql = "delete from Table_Users where UserID='" + theId + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Tab2,通过combox，显示该地区的所有的员工号
        public List<string> GetIdName(string distinct)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select UserID,Name from Table_Users where Distincts='"+distinct+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //Tab2，通过选择职工号，获取该职工建立的所有客户信息及其状态
        public List<string> TheClientInfo(int theUserId)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from Table_ClientInfo where UserId='" + theUserId + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                    list.Add(reader[6].ToString());
                    list.Add(reader[7].ToString());
                    list.Add(reader[8].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //Tab2,通过选择客户行，获取客户电话号码，获取建立该客户的业务明细
        public List<string>TheClientBusinessInfo(string thePhone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,State from Table_BusinessDetail where Phone='" + thePhone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //Tab4 日程消息

        //添加消息通知
        public bool AddNewsInfo(int theId, string thePost, string theDate, string theTheme,string theHead, string theContent)
        {
            try
            {
                string sql = "insert into Table_NewsInfo values ('" + theId + "','" + thePost + "','" + theDate + "','" + theTheme + "','"+theHead+"','" + theContent + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //获取消息通知
        public List<string> TheNewsInfo()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from Table_NewsInfo";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        
        //修改消息通知
        public bool UpdateNewsInfo(int theId,string theDate,string theTheme,string theHead,string theDetail)
        {
            try
            {
                string sql = "update Table_NewsInfo set Theme ='" + theTheme + "',Headline='"+theHead+"',Detail='" + theDetail + "' where  UserId='" + theId + "' and Date='"+theDate+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //删除消息通知
        public bool DeleteNewsInfo(int theId,string theDate)
        {
            try
            {
                string sql = "delete from Table_NewsInfo where  UserId='" + theId + "' and Date='" + theDate + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Tab3,数据统计
        //获取本月所有客户状态信息
        public List<string> GetAllClientsStateInfo()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,State from Table_ClientInfo";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }

        //Tab3 对职员表和客户表进行连接查询
        public List<string> JoinQuery()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Date,State,Distincts from Table_ClientInfo c,Table_Users u where c.UserId=u.UserID";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

            }
            return list;
        }
        //Tab3 添加业务指标
        public bool AddIndex(int theId,string theMonth,int theOrder,int theProject,int theContract)
        {
            try
            {
                string sql = "insert into Table_PersonalGoal values ('" + theId + "','" + theMonth + "','" + theOrder + "','" + theProject + "','" + theContract + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Tab3 更新业务指标
        public bool UpDateIndex(string theMonth,int theOrder,int theProject,int theContract)
        {
            try
            {
                string sql = "update Table_PersonalGoal set OrderNumber ='" + theOrder + "',ProjectNumber='" + theProject + "',ContractNumber='"+theContract+"'  where  Month='"+theMonth+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //更改管理员或总经理密码
        public bool AlterTheRootPassword(int theId,string thePassword)
        {
            try
            {
                string sql = "update Table_Users set Password ='" + thePassword + "' where UserID='"+theId+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //查询某位职工是否有关联客户
        public bool StaffAssClient(int theId)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select * from Table_ClientInfo where UserId='" + theId + "'";
                cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();

            }
        }
        //删除合同图片路径
        public bool DeleteImagePath(string thePhone)
        {
            try
            {
                string sql = "delete from Table_UploadImage where Id='" + thePhone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}