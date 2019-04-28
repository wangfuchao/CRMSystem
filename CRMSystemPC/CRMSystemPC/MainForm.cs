using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRMSystemPC
{
    public partial class MainForm : MetroForm
    {
        ServiceReference1.WebServiceSoapClient myWebService = null; //连接服务
        //初始化职工变量
        List<Staff> staffList;
        PageInfo<Staff> pageStaffList;
        PageInfo<Client> pageClientList;
        string StaffClass;//职工级别,1级为管理员，2级为总经理
        int theMaxId = 0;//最大职工号，为新建职工做准备
        TreeNode t1 = new TreeNode("总经理");
        TreeNode t2 = new TreeNode("成都");
        string ClientPhone;//客户电话号码
        int UserId;

        public MainForm(string theClass,int theId)
        {
            InitializeComponent();
            StaffManageInit(theClass);
            UserId = theId;
        }

        //员工管理的界面初始化函数
        public int TheId()
        {
            return UserId;
        }
        public int TheMaxId()
        {
            return theMaxId;
        }
        public string TheClass()
        {
            return StaffClass;
        }
        public string TheClientPhone()
        {
            return ClientPhone;
        }
        //获取区域Combox的所有选项
        public string[] theCombox()
        {
            string[] theList=new string[0];
            List<string> theNewList = theList.ToList();
            for (int i=0;i<CBox_Distinct.Items.Count;i++)
            {
                if(CBox_Distinct.Items[i].ToString()!="成都")
                {
                    theNewList.Add(CBox_Distinct.GetItemText(CBox_Distinct.Items[i]));
                }
                
            }
            theList = theNewList.ToArray();
            return theList;
        }
        public void StaffManageInit(string theClass)
        {
            
            this.StaffClass = theClass;

            //CBox_Distinct.SelectedIndex = 3;//职工管理，地区默认为成都，即显示全部
            TabControl_Function.SelectedIndex = 0;//Tab页面默认为第一页
            if (StaffClass == "2")
            {
                //总经理的权限
                Label_MLoginUser.Text = "总经理";
                Button_DeleteStaff.Visible = false; //删除按钮不可见
                Button_AddNewStaff.Visible = false;//添加按钮不可见
                Button_DeleteStaff.Enabled = false;
                TextBox_AddZone.Visible = false;//添加区域输入框不可见
                Button_AddZone.Visible = false;//添加区域按钮不可见
                Button_2DeleteClient.Visible = false;//删除客户按钮不可见
                Button_4RootDelete.Visible = false;//删除日程按钮不可见
                Button_2DeleteClient.Visible = false;
            }
            else
            {
                Label_MLoginUser.Text = "管理员";
                Button_DeleteStaff.Enabled = false;
                Button_AddNewStaff.Enabled = false;
                Button_AlterStaff.Enabled = false;
                Button_2DeleteClient.Enabled = false;
                //管理员的权限
            }
            Button_2Book1.Enabled = false;
            Button_2Book2.Enabled = false;
            Button_2Image.Enabled = false;
        }

        //为二级子节点添加员工号
        public void AddTreeNode(string theStaffDistinct,string theStaffInfo)
        {

            TreeNode treeNode = FindNode(t2, theStaffDistinct);

            TreeNode newTree = new TreeNode(theStaffInfo);

            treeNode.Nodes.Add(newTree);
        }
        //为二级子节点删除节点
        public void AlterTreeNode(string theStaffDistinct, string theStaffInfo)
        {
            TreeNode treeNode = FindNode(t2, theStaffDistinct);

            TreeNode deleteNode = FindNode(treeNode, theStaffInfo);

            treeNode.Nodes.Remove(deleteNode);
        }

        //在Treeview中递归查找某一节点
        private TreeNode FindNode(TreeNode tnParent, string strValue)
        {
            if (tnParent == null) return null;

            if (tnParent.Text == strValue) return tnParent;

            TreeNode tnRet = null;

            foreach (TreeNode tn in tnParent.Nodes)
            {

                tnRet = FindNode(tn, strValue);

                if (tnRet != null) break;
            }
            return tnRet;
        }
        //员工管理的界面树图的数据获取
        public void StaffManageTreeData()
        {
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string[] theTreeInfo = myWebService.GetTreeInfo().ToArray(); //获取树信息

            string[] theAreaList = new string[0];
            List<string> theNewAreaList = theAreaList.ToList();
            for (int i = 1; i < theTreeInfo.Length;)
            {
                //获取地区名称
                theNewAreaList.Add(theTreeInfo[i]);
                i = i + 3;
            }
            theAreaList = theNewAreaList.ToArray();

            List<string> list = new List<string>();
            foreach (string item in theAreaList)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            string[] theFinalList = new string[0];
            theFinalList = list.ToArray();//获得地区名称

            //为CBox添加地区选项
            CBox_Distinct.Items.Clear();
            for(int i=0;i<theFinalList.Length;i++)
            {
                CBox_Distinct.Items.Add(theFinalList[i]);
            }

            List<string> TheDistinctList = new List<string>();
            for (int i=0;i<theFinalList.Length;i++)
            {
                if(theFinalList[i]!="成都")
                {
                    TheDistinctList.Add(theFinalList[i]);
                }
            }
            string[] distinctList = TheDistinctList.ToArray();

           


            //t2添加子节点

            for (int i=0;i<distinctList.Length;i++)
            {
                TreeNode t3 = new TreeNode(distinctList[i]);
                for (int j=0;j<theTreeInfo.Length;j++)
                {
                    if(theTreeInfo[j]==distinctList[i])
                    {
                        TreeNode newTree = new TreeNode(theTreeInfo[j - 1] + theTreeInfo[j + 1]);
                        t3.Nodes.Add(newTree);
                    }
                }
                
                t2.Nodes.Add(t3);
            }

            t1.Nodes.Add(t2);
            treeViewList.Nodes.Add(t1);
            treeViewList.ExpandAll();
        }
        //员工管理的ListView员工数据获取
        public void StaffManageStaffData()
        {
            if (CBox_Distinct.SelectedItem.ToString() == "成都")
            {
                ListView_Users.Items.Clear();
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] theStaffInfo = myWebService.GetStaffInfo().ToArray();
                staffList = new List<Staff>();
                int theId;
                //统计最大员工号码，为新建员工做准备
                int max = 0;
                int newNumber = 0;
                for (int i = 0; i < theStaffInfo.Length;)
                {
                    int.TryParse(theStaffInfo[i], out theId);
                    if (theId >= 100006)
                    {
                        staffList.Add(new Staff() { ID = theStaffInfo[i], Name = theStaffInfo[i + 2], Zone = theStaffInfo[i + 1], Phone = theStaffInfo[i + 3] });
                        int.TryParse(theStaffInfo[i], out newNumber);
                        if (newNumber > max)
                            max = newNumber;
                        i = i + 4;
                    }
                    else
                    {
                        i = i + 4;
                        continue;
                    }

                }
                theMaxId = max;
                pageStaffList = new PageInfo<Staff>(staffList, 10);
                Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoHome).ToArray();
                //string theName = StudentInfo[0].Name;

                for (int i = 0; i < StaffInfo.Length; i++)
                {
                    ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                    lit.SubItems.Add(StaffInfo[i].Name);
                    lit.SubItems.Add(StaffInfo[i].Zone);
                    lit.SubItems.Add(StaffInfo[i].Phone);
                }
            }
            else
            {
                ListView_Users.Items.Clear();

                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] theStaffInfo = myWebService.GetStaffInfo().ToArray();
                staffList = new List<Staff>();
                int theId;
                //统计最大员工号码，为新建员工做准备

                for (int i = 0; i < theStaffInfo.Length;)
                {
                    int.TryParse(theStaffInfo[i], out theId);
                    if (theId >= 100006)
                    {
                        if (theStaffInfo[i + 1] == CBox_Distinct.SelectedItem.ToString())
                        {
                            staffList.Add(new Staff() { ID = theStaffInfo[i], Name = theStaffInfo[i + 2], Zone = theStaffInfo[i + 1], Phone = theStaffInfo[i + 3] });

                            i = i + 4;
                        }
                        else
                        {
                            i = i + 4;
                            continue;
                        }

                    }
                    else
                    {
                        i = i + 4;
                        continue;
                    }

                }
                pageStaffList = new PageInfo<Staff>(staffList, 10);
                Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoHome).ToArray();
                //string theName = StudentInfo[0].Name;

                for (int i = 0; i < StaffInfo.Length; i++)
                {
                    ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                    lit.SubItems.Add(StaffInfo[i].Name);
                    lit.SubItems.Add(StaffInfo[i].Zone);
                    lit.SubItems.Add(StaffInfo[i].Phone);
                }
            }
        }
        //员工类
        public class Staff
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Zone { get; set; }
            public string Phone { get; set; }
        }

        /***********************************/
        //第二个Tab
        //为地区选择Combox添加地区
        public void Tab2AddDistinct()
        {
            string[] distinctList = new string[0];
            distinctList = theCombox();
            for(int i=0;i<distinctList.Length;i++)
            {
                ComboBox_2Distinct.Items.Add(distinctList[i]);
                ComboBox_4Distinct.Items.Add(distinctList[i]);
            }
        }
        //客户类
        public class Client
        {
            public string Date { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Plot { get; set; }
            public string HouseType { get; set; }
            public string Priority { get; set; }
            public string UserId { get; set; }
            public string State { get; set; }
            public string ClientType { get; set; }
        }
        /*************************************************/
        private void MainForm_Load(object sender, EventArgs e)
        {
            //左边的树视图
            StaffManageTreeData();
            //通过选中默认的成都，显示listview员工数据
            CBox_Distinct.SelectedIndex = 0;

            //第二个Tab，添加地区选择列表
            Tab2AddDistinct();
            //第三个Tab,数据统计
            /*************************************************/
            //GetAllClientStateNumber();
            //ComboBox_3ChartView.SelectedIndex = 0;
            ////数据统计
            //GetDistinctIndex();
            //BarChart();


            //第四个Tab，消息通知列表
            UpdateNewsInfoList();

        }

        //TreeView不同级节点设不同右键菜单
        /*************树视图************************/
        private void treeViewList_MouseClick(object sender, MouseEventArgs e)
        {
            treeViewList.ContextMenuStrip = null;
            TreeNode selectNode = treeViewList.GetNodeAt(e.X, e.Y);
            if(selectNode.Level==0)
            {
                //treeViewList.ContextMenuStrip = contextMenuStrip1;
                treeViewList.SelectedNode = selectNode;
            }
            else if(selectNode.Level==1)
            {
                //treeViewList.ContextMenuStrip = contextMenuStrip1;
                treeViewList.SelectedNode = selectNode;
            }
            else if(selectNode.Level==2)
            {
                //treeViewList.ContextMenuStrip = contextMenuStrip1;
                treeViewList.SelectedNode = selectNode;
            }
            else if(selectNode.Level==3)
            {
                treeViewList.ContextMenuStrip = contextMenuStrip1;
                treeViewList.SelectedNode = selectNode;
            }
        }

        

       

        //首页点击事件
        private void metroLink1_Click(object sender, EventArgs e)
        {
            ListView_Users.Items.Clear();
            Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoHome).ToArray();
            //string theName = StudentInfo[0].Name;

            for (int i = 0; i < StaffInfo.Length; i++)
            {
                ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                lit.SubItems.Add(StaffInfo[i].Name);
                lit.SubItems.Add(StaffInfo[i].Zone);
                lit.SubItems.Add(StaffInfo[i].Phone);
            }
        }
        //上一页点击事件
        private void metroLink2_Click(object sender, EventArgs e)
        {
            ListView_Users.Items.Clear();
            Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoPrePrevious).ToArray();
            //string theName = StudentInfo[0].Name;

            for (int i = 0; i < StaffInfo.Length; i++)
            {
                ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                lit.SubItems.Add(StaffInfo[i].Name);
                lit.SubItems.Add(StaffInfo[i].Zone);
                lit.SubItems.Add(StaffInfo[i].Phone);
            }
        }
        //下一页点击事件
        private void metroLink3_Click(object sender, EventArgs e)
        {
            ListView_Users.Items.Clear();
            Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoNext).ToArray();
            //string theName = StudentInfo[0].Name;

            for (int i = 0; i < StaffInfo.Length; i++)
            {
                ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                lit.SubItems.Add(StaffInfo[i].Name);
                lit.SubItems.Add(StaffInfo[i].Zone);
                lit.SubItems.Add(StaffInfo[i].Phone);
            }
        }
        //尾页点击事件
        private void metroLink4_Click(object sender, EventArgs e)
        {
            ListView_Users.Items.Clear();
            Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoEnd).ToArray();
            //string theName = StudentInfo[0].Name;

            for (int i = 0; i < StaffInfo.Length; i++)
            {
                ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                lit.SubItems.Add(StaffInfo[i].Name);
                lit.SubItems.Add(StaffInfo[i].Zone);
                lit.SubItems.Add(StaffInfo[i].Phone);
            }
        }

        //第一个Tab,新增区域事件
        private void Button_AddZone_Click(object sender, EventArgs e)
        {
            Regex P_regex = new Regex("[\u4e00-\u9fa5]");//表示任意一个汉字
            if (P_regex.IsMatch(TextBox_AddZone.Text))
            {
                if(TextBox_AddZone.Text.Length<5||TextBox_AddZone.Text!="成都")
                {
                    TreeNode t5 = new TreeNode(TextBox_AddZone.Text);
                    t2.Nodes.Add(t5);
                    CBox_Distinct.Items.Add(TextBox_AddZone.Text);
                    MessageBox.Show("添加成功！");
                    TextBox_AddZone.Text = " ";
                    
                }
                else
                {
                    MessageBox.Show("输入文字含有非法字符或过长，无法添加");
                }
            }
            else
            {
                MessageBox.Show("输入文字含有非法字符，无法添加！");
            }
        }

        //第一个Tab,Combox区域选择事件。
        private void CBox_Distinct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_DeleteStaff.Enabled = false;
            Button_AddNewStaff.Enabled = false;
            Button_AlterStaff.Enabled = false;
            if (CBox_Distinct.SelectedItem.ToString()=="成都")
            {
                ListView_Users.Items.Clear();
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] theStaffInfo = myWebService.GetStaffInfo().ToArray();
                staffList = new List<Staff>();
                int theId;
                //统计最大员工号码，为新建员工做准备
                int max = 0;
                int newNumber = 0;
                for (int i = 0; i < theStaffInfo.Length;)
                {
                    int.TryParse(theStaffInfo[i], out theId);
                    if (theId >= 100006)
                    {
                        staffList.Add(new Staff() { ID = theStaffInfo[i], Name = theStaffInfo[i + 2], Zone = theStaffInfo[i + 1], Phone = theStaffInfo[i + 3] });
                        int.TryParse(theStaffInfo[i], out newNumber);
                        if (newNumber > max)
                            max = newNumber;
                        i = i + 4;
                    }
                    else
                    {
                        i = i + 4;
                        continue;
                    }

                }
                theMaxId = max;
                pageStaffList = new PageInfo<Staff>(staffList, 10);
                Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoHome).ToArray();
                //string theName = StudentInfo[0].Name;

                for (int i = 0; i < StaffInfo.Length; i++)
                {
                    ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                    lit.SubItems.Add(StaffInfo[i].Name);
                    lit.SubItems.Add(StaffInfo[i].Zone);
                    lit.SubItems.Add(StaffInfo[i].Phone);
                }
            }
            else
            {
                ListView_Users.Items.Clear();

                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] theStaffInfo = myWebService.GetStaffInfo().ToArray();
                staffList = new List<Staff>();
                int theId;
                //统计最大员工号码，为新建员工做准备
                
                for (int i = 0; i < theStaffInfo.Length;)
                {
                    int.TryParse(theStaffInfo[i], out theId);
                    if (theId >= 100006)
                    {
                        if (theStaffInfo[i + 1] == CBox_Distinct.SelectedItem.ToString())
                        {
                            staffList.Add(new Staff() { ID = theStaffInfo[i], Name = theStaffInfo[i + 2], Zone = theStaffInfo[i + 1], Phone = theStaffInfo[i + 3] });
                           
                            i = i + 4;
                        }
                        else
                        {
                            i = i + 4;
                            continue;
                        }

                    }
                    else
                    {
                        i = i + 4;
                        continue;
                    }

                }
                pageStaffList = new PageInfo<Staff>(staffList, 10);
                Staff[] StaffInfo = pageStaffList.GetPageData(JumpOperation.GoHome).ToArray();
                //string theName = StudentInfo[0].Name;

                for (int i = 0; i < StaffInfo.Length; i++)
                {
                    ListViewItem lit = ListView_Users.Items.Add(StaffInfo[i].ID);
                    lit.SubItems.Add(StaffInfo[i].Name);
                    lit.SubItems.Add(StaffInfo[i].Zone);
                    lit.SubItems.Add(StaffInfo[i].Phone);
                }
            }
           
        }
        string[] theStaffId=new string[4];
        public string[] GetStaffInfo()
        {
            return theStaffId;
        }
        //第一个Tab，ListView选中数据项事件
        int theDeleteId;
        string theDeleteArea;
        string theDeleteName;
        private void ListView_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView_Users.SelectedIndices != null && ListView_Users.SelectedIndices.Count > 0)
            {
               Label_Id.Text= ListView_Users.SelectedItems[0].SubItems[0].Text;//职工ID
                theStaffId[0] = Label_Id.Text;
                int.TryParse(Label_Id.Text, out theDeleteId);
               Label_Name.Text= ListView_Users.SelectedItems[0].SubItems[1].Text;//姓名
                theStaffId[1] = Label_Name.Text;
                theDeleteName= Label_Name.Text;
                Label_Phone.Text= ListView_Users.SelectedItems[0].SubItems[3].Text;//电话号码
                theStaffId[2] = Label_Phone.Text;
               Label_Area.Text= ListView_Users.SelectedItems[0].SubItems[2].Text;//地区
                theStaffId[3] = Label_Area.Text;
                theDeleteArea= Label_Area.Text;
            }
            Button_DeleteStaff.Enabled = true;
            Button_AddNewStaff.Enabled = true;
            Button_AlterStaff.Enabled = true;
        }

        //管理员添加新职工
        private void Button_AddNewStaff_Click(object sender, EventArgs e)
        {
            NewStaff newForm = new NewStaff(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }

        //修改职工信息
        private void Button_AlterStaff_Click(object sender, EventArgs e)
        {
            Form newForm = new AlterStaff(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }
        //删除职工信息
        private void Button_DeleteStaff_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认删除该职工？","删除职工",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theCheck = myWebService.StaffAssClient(theDeleteId);
                if(theCheck==true)
                {
                    MessageBox.Show("抱歉，该职工有关联客户，无法删除该职工！");
                }
                else
                {
                    bool theResult = myWebService.DeleteStaff(theDeleteId);
                    if (theResult == true)
                    {
                        MessageBox.Show("成功删除该职工！");
                        AlterTreeNode(theDeleteArea, theDeleteId.ToString() + theDeleteName);
                        StaffManageStaffData();
                    }
                    else
                    {
                        MessageBox.Show("删除该职工失败！");

                    }
                }
            }  
        }




        /******************************第二个Tab,业务管理*********************************/
        private void ComboBox_2Distinct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //连接数据库
            string theDistict = ComboBox_2Distinct.SelectedItem.ToString();
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string[] staffList = myWebService.GetIdName(theDistict).ToArray();
            if(ComboBox_2Staff.Items.Count>=1)
            {
                ComboBox_2Staff.Items.Clear();
            }
            for(int i=0;i<staffList.Length;)
            {
                ComboBox_2Staff.Items.Add(staffList[i] + staffList[i + 1]);
                i = i + 2;
            }
        }
        //通过员工选择显示对应的客户列表
        private void ComboBox_2Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_2DeleteClient.Enabled = false;
            Button_2Book1.Enabled = false;
            Button_2Book2.Enabled = false;
            Button_2Image.Enabled = false;
            if (ListView_2Detail.Items.Count>=1)
            {
                ListView_2Detail.Items.Clear();
            }
            if (ListView_2State.Items.Count>=1)
            {
                ListView_2State.Items.Clear();
            }
            List<Client> clientList=new List<Client>();
            
            int theStaffId;
            string theStringId = ComboBox_2Staff.SelectedItem.ToString();
            theStaffId=Convert.ToInt32(theStringId.Substring(0, 6));

            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string[] clientInfo = myWebService.TheClientInfo(theStaffId).ToArray();

            for(int i=0;i<clientInfo.Length;)
            {
                clientList.Add(new Client() { Date = clientInfo[i], Name = clientInfo[i + 1], Phone = clientInfo[i + 2],Plot=clientInfo[i+3],HouseType=clientInfo[i+4],Priority=clientInfo[i+5],UserId=clientInfo[i+6],State=clientInfo[i+7],ClientType=clientInfo[i+8] });
                i = i + 9;
            }
            pageClientList = new PageInfo<Client>(clientList, 4);

            Client[] theClientInfo = pageClientList.GetPageData(JumpOperation.GoHome).ToArray();
 
            for (int i = 0; i < theClientInfo.Length; i++)
            {
                string theDate=theClientInfo[i].Date;
                theDate = theDate.Substring(0,theDate.Length - 8);
                ListViewItem lit = ListView_2State.Items.Add(theDate);
                lit.SubItems.Add(theClientInfo[i].Name);
                lit.SubItems.Add(theClientInfo[i].Phone);
                lit.SubItems.Add(theClientInfo[i].Plot);
                lit.SubItems.Add(theClientInfo[i].HouseType);
                lit.SubItems.Add(theClientInfo[i].Priority);
                lit.SubItems.Add(theClientInfo[i].UserId);
                lit.SubItems.Add(theClientInfo[i].State);
                lit.SubItems.Add(theClientInfo[i].ClientType);
            }

        }

        private void metroLink8_Click(object sender, EventArgs e)
        {
            ListView_2State.Items.Clear();
            Client[] theClientInfo = pageClientList.GetPageData(JumpOperation.GoHome).ToArray();

            for (int i = 0; i < theClientInfo.Length; i++)
            {
                string theDate = theClientInfo[i].Date;
                theDate = theDate.Substring(0, theDate.Length - 8);
                ListViewItem lit = ListView_2State.Items.Add(theDate);
                lit.SubItems.Add(theClientInfo[i].Name);
                lit.SubItems.Add(theClientInfo[i].Phone);
                lit.SubItems.Add(theClientInfo[i].Plot);
                lit.SubItems.Add(theClientInfo[i].HouseType);
                lit.SubItems.Add(theClientInfo[i].Priority);
                lit.SubItems.Add(theClientInfo[i].UserId);
                lit.SubItems.Add(theClientInfo[i].State);
                lit.SubItems.Add(theClientInfo[i].ClientType);
            }
        }

        private void metroLink7_Click(object sender, EventArgs e)
        {
            ListView_2State.Items.Clear();
            Client[] theClientInfo = pageClientList.GetPageData(JumpOperation.GoPrePrevious).ToArray();

            for (int i = 0; i < theClientInfo.Length; i++)
            {
                string theDate = theClientInfo[i].Date;
                theDate = theDate.Substring(0, theDate.Length - 8);
                ListViewItem lit = ListView_2State.Items.Add(theDate);
                lit.SubItems.Add(theClientInfo[i].Name);
                lit.SubItems.Add(theClientInfo[i].Phone);
                lit.SubItems.Add(theClientInfo[i].Plot);
                lit.SubItems.Add(theClientInfo[i].HouseType);
                lit.SubItems.Add(theClientInfo[i].Priority);
                lit.SubItems.Add(theClientInfo[i].UserId);
                lit.SubItems.Add(theClientInfo[i].State);
                lit.SubItems.Add(theClientInfo[i].ClientType);
            }
        }

        private void metroLink6_Click(object sender, EventArgs e)
        {
            ListView_2State.Items.Clear();
            Client[] theClientInfo = pageClientList.GetPageData(JumpOperation.GoNext).ToArray();

            for (int i = 0; i < theClientInfo.Length; i++)
            {
                string theDate = theClientInfo[i].Date;
                theDate = theDate.Substring(0, theDate.Length - 8);
                ListViewItem lit = ListView_2State.Items.Add(theDate);
                lit.SubItems.Add(theClientInfo[i].Name);
                lit.SubItems.Add(theClientInfo[i].Phone);
                lit.SubItems.Add(theClientInfo[i].Plot);
                lit.SubItems.Add(theClientInfo[i].HouseType);
                lit.SubItems.Add(theClientInfo[i].Priority);
                lit.SubItems.Add(theClientInfo[i].UserId);
                lit.SubItems.Add(theClientInfo[i].State);
                lit.SubItems.Add(theClientInfo[i].ClientType);
            }
        }

        private void metroLink5_Click(object sender, EventArgs e)
        {
            ListView_2State.Items.Clear();
            Client[] theClientInfo = pageClientList.GetPageData(JumpOperation.GoEnd).ToArray();

            for (int i = 0; i < theClientInfo.Length; i++)
            {
                string theDate = theClientInfo[i].Date;
                theDate = theDate.Substring(0, theDate.Length - 8);
                ListViewItem lit = ListView_2State.Items.Add(theDate);
                lit.SubItems.Add(theClientInfo[i].Name);
                lit.SubItems.Add(theClientInfo[i].Phone);
                lit.SubItems.Add(theClientInfo[i].Plot);
                lit.SubItems.Add(theClientInfo[i].HouseType);
                lit.SubItems.Add(theClientInfo[i].Priority);
                lit.SubItems.Add(theClientInfo[i].UserId);
                lit.SubItems.Add(theClientInfo[i].State);
                lit.SubItems.Add(theClientInfo[i].ClientType);
            }
        }
        //选中某一行客户信息，显示其业务明细
        public string GetClientName()
        {
            return theName;
        }
        string theName;
        private void ListView_2State_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_2DeleteClient.Enabled = true;
            string thePhone;
            if (ListView_2State.SelectedIndices != null && ListView_2State.SelectedIndices.Count > 0)
            {
                thePhone = ListView_2State.SelectedItems[0].SubItems[2].Text;//获取客户电话号码
                ClientPhone = thePhone;
                theName= ListView_2State.SelectedItems[0].SubItems[1].Text;//获取客户姓名
                //连接数据库
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] theBusinessInfo = myWebService.TheClientBusinessInfo(thePhone).ToArray();
                if(ListView_2Detail.Items.Count>=1)
                {
                    ListView_2Detail.Items.Clear();
                }
                for(int i=0;i<theBusinessInfo.Length;)
                {
                    ListViewItem lit = ListView_2Detail.Items.Add(theBusinessInfo[i]);
                    lit.SubItems.Add(theBusinessInfo[i + 1]);
                    i = i + 2;
                }
            }
           
        }
        //选中客户业务明细，右边按键相应
        public string GetUploadTime()
        {
            return theTime;
        }
        string theTime;
        private void ListView_2Detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView_2Detail.SelectedIndices != null && ListView_2Detail.SelectedIndices.Count > 0)
            {
                if (ListView_2Detail.SelectedItems[0].SubItems[1].Text == "新建定金签单" || ListView_2Detail.SelectedItems[0].SubItems[1].Text == "修改定金签单")
                {
                    Button_2Book1.Enabled = true;
                }
                else
                {
                    Button_2Book1.Enabled = false;
                }
                if (ListView_2Detail.SelectedItems[0].SubItems[1].Text == "新建工程签单" || ListView_2Detail.SelectedItems[0].SubItems[1].Text == "修改工程签单")
                {
                    Button_2Book2.Enabled = true;
                }
                else
                {
                    Button_2Book2.Enabled = false;
                }
                if (ListView_2Detail.SelectedItems[0].SubItems[1].Text == "正式签订合同")
                {
                    theTime = ListView_2Detail.SelectedItems[0].SubItems[0].Text;
                    Button_2Image.Enabled = true;
                }
                else
                {
                    Button_2Image.Enabled = false;
                }
            }  
        }
        //点击查看定金签单
        private void Button_2Book1_Click(object sender, EventArgs e)
        {
            Payment newForm = new Payment(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }
        //点击查看工程签单
        private void Button_2Book2_Click(object sender, EventArgs e)
        {
            Project newForm = new Project(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }
        //点击查看合同照片
        private void Button_2Image_Click(object sender, EventArgs e)
        {
            //跳转到查看合同照片窗口
            ViewContract newForm = new ViewContract(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }

        private void ComboBox_4Distinct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //连接数据库
            string theDistict = ComboBox_4Distinct.SelectedItem.ToString();
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string[] staffList = myWebService.GetIdName(theDistict).ToArray();
            if (ComboBox_4Staff.Items.Count >= 1)
            {
                ComboBox_4Staff.Items.Clear();
            }
            for (int i = 0; i < staffList.Length;)
            {
                ComboBox_4Staff.Items.Add(staffList[i] + staffList[i + 1]);
                i = i + 2;
            }
        }

        public void UpdateSchedule()
        {
            if (ComboBox_4Staff.Items.Count > 0)
            {
                //连接数据库
                //选择时间
                if (ListView_4Schedule.Items.Count > 0)
                {
                    ListView_4Schedule.Items.Clear();
                }

                int theStaffId;
                string theStringId = ComboBox_4Staff.SelectedItem.ToString();
                theStaffId = Convert.ToInt32(theStringId.Substring(0, 6));

                DateTime theDate = DateTime.Now.Date;

                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] scheduleList = myWebService.GetSchedule(theStaffId).ToArray();
                for (int i = 0; i < scheduleList.Length;)
                {
                    DateTime scheduleDate;
                    DateTime.TryParse(scheduleList[i], out scheduleDate);
                    if (theDate.Date == scheduleDate.Date)
                    {

                        ListViewItem lit = ListView_4Schedule.Items.Add(scheduleList[i].Substring(0, scheduleList[i].Length - 7));//日期
                        lit.SubItems.Add(scheduleList[i + 1]);//开始时间
                        lit.SubItems.Add(scheduleList[i + 2]);//结束时间
                        lit.SubItems.Add(scheduleList[i + 4]);//主题

                    }
                    i = i + 5;

                }

                /********************************/
            }
        }
        private void ComboBox_4Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSchedule();
        }

        private void DateTime_4Datetime_ValueChanged(object sender, EventArgs e)
        {
            if (ComboBox_4Staff.Items.Count > 0)
            {
                if(ListView_4Schedule.Items.Count>0)
                {
                    ListView_4Schedule.Items.Clear();
                }
                int theStaffId;
                string theStringId = ComboBox_4Staff.SelectedItem.ToString();
                theStaffId = Convert.ToInt32(theStringId.Substring(0, 6));

                DateTime theDate = DateTime_4Datetime.Value.Date;

                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                string[] scheduleList = myWebService.GetSchedule(theStaffId).ToArray();
                for (int i = 0; i < scheduleList.Length;)
                {
                    DateTime scheduleDate;
                    DateTime.TryParse(scheduleList[i], out scheduleDate);
                    if (theDate.Date == scheduleDate.Date)
                    {

                        ListViewItem lit = ListView_4Schedule.Items.Add(scheduleList[i].Substring(0, scheduleList[i].Length - 7));//日期
                        lit.SubItems.Add(scheduleList[i + 1]);//开始时间
                        lit.SubItems.Add(scheduleList[i + 2]);//结束时间
                        lit.SubItems.Add(scheduleList[i + 4]);//主题

                    }
                    i = i + 5;

                }
            }
        }
        //获取消息通知，更新至消息通知列表
        public void UpdateNewsInfoList()
        {
            if(ListView_4NewsInfo.Items.Count>0)
            {
                ListView_4NewsInfo.Items.Clear();
            }
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string[] theInfoList = myWebService.TheNewsInfo().ToArray();
            for(int i=0;i<theInfoList.Length;)
            {
                ListViewItem lit = ListView_4NewsInfo.Items.Add(theInfoList[i]);//id
                lit.SubItems.Add(theInfoList[i + 1]);
                lit.SubItems.Add(theInfoList[i + 2]);
                lit.SubItems.Add(theInfoList[i + 3]);
                lit.SubItems.Add(theInfoList[i + 4]);
                lit.SubItems.Add(theInfoList[i + 5]);
                i = i + 6;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AddNews newForm = new AddNews(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }
        string[] theNewsInfos = null;
        public string[] GetNewsInfo(string theId,string theDate,string theTheme,string theHead,string theContent)
        {
            string[] theNewInfo=new string[5];
            theNewInfo[0] = theId;
            theNewInfo[1] = theDate;
            theNewInfo[2] = theTheme;
            theNewInfo[3] = theHead;
            theNewInfo[4] = theContent;
            return theNewInfo;
        }

        public string[] SendNewsInfo()
        {
            return theNewsInfos;
        }

        private void ListView_4NewsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView_4NewsInfo.SelectedIndices != null && ListView_4NewsInfo.SelectedIndices.Count > 0)
            {
                string theId = ListView_4NewsInfo.SelectedItems[0].SubItems[0].Text;
                string theDate= ListView_4NewsInfo.SelectedItems[0].SubItems[2].Text;
                string theTheme = ListView_4NewsInfo.SelectedItems[0].SubItems[3].Text;
                string theHead = ListView_4NewsInfo.SelectedItems[0].SubItems[4].Text;
                string theContent = ListView_4NewsInfo.SelectedItems[0].SubItems[5].Text;
                theNewsInfos = GetNewsInfo(theId, theDate, theTheme,theHead,theContent);
            }

            metroButton2.Enabled = true;
            metroButton5.Enabled = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AlterNews newForm = new AlterNews(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }

        //删除消息通知
        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (ListView_4NewsInfo.SelectedIndices != null && ListView_4NewsInfo.SelectedIndices.Count > 0)
            {
                string theId = ListView_4NewsInfo.SelectedItems[0].SubItems[0].Text;
                int Userid=0;
                int.TryParse(theId, out Userid);
                string theDate = ListView_4NewsInfo.SelectedItems[0].SubItems[2].Text;
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.DeleteNewsInfo(Userid, theDate);
                if(theResult==true)
                {
                    MessageBox.Show("删除成功！");
                    UpdateNewsInfoList();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void ListView_4Schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_4RootDelete.Enabled = true;
            
        }

        private void Button_4RootDelete_Click(object sender, EventArgs e)
        {
            if (ListView_4Schedule.SelectedIndices != null && ListView_4Schedule.SelectedIndices.Count > 0)
            {
                int theStaffId;
                string theStringId = ComboBox_4Staff.SelectedItem.ToString();
                theStaffId = Convert.ToInt32(theStringId.Substring(0, 6)); //职工Id
                DateTime Date;
                string theDate = ListView_4Schedule.SelectedItems[0].SubItems[0].Text;
                DateTime.TryParse(theDate, out Date);

                string theStartTime = ListView_4Schedule.SelectedItems[0].SubItems[1].Text;
                string theEndTime = ListView_4Schedule.SelectedItems[0].SubItems[2].Text;
                myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                bool theResult = myWebService.DeleteSchedule(theStaffId, Date, theStartTime, theEndTime);
                if (theResult == true)
                {
                    MessageBox.Show("删除成功！");
                    //更新日程列表
                    UpdateSchedule();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }
        //Tab3,数据统计
        /**********************************************/
        public void BarChart()
        {
            string[] theDistinctList = theCombox();//获取地区列表

            List<string> dataList = new List<string>();
            for (int j = 0; j < theDistinctList.Length; j++)//列表循环
            {
                int theFellows = 0;
                int theOrders = 0;
                int theProjects = 0;
                int theLosts = 0;
                int theContracts = 0;
                for (int i = 0; i < theDistinctInfo.Length;)
                {
                    DateTime theDate;
                    DateTime.TryParse(theDistinctInfo[i], out theDate);
                    if (theDate.Date.Month == DateTime.Now.Month)
                    {
                        if (theDistinctInfo[i + 2] == theDistinctList[j])//地区对应
                        {
                            if(theDistinctInfo[i+1]=="正在跟踪" || theDistinctInfo[i+1]=="稳步推进")
                            {
                                theFellows++;
                            }
                            if (theDistinctInfo[i + 1] == "客户丢失")
                            {
                                theLosts++;
                            }
                            if (theDistinctInfo[i + 1] == "已签定单")
                            {
                                theOrders++;
                            }
                            if (theDistinctInfo[i + 1] == "已签工单")
                            {
                                theProjects++;
                            }
                            if (theDistinctInfo[i + 1] == "上传合同")
                            {
                                theContracts++;
                            }
                        }

                    }
                    i = i + 3;
                }
                dataList.Add(theDistinctList[j]);
                dataList.Add(theFellows.ToString());
                dataList.Add(theLosts.ToString());
                dataList.Add(theOrders.ToString());
                dataList.Add(theProjects.ToString());
                dataList.Add(theContracts.ToString());
            }

            string[] theFinalData = dataList.ToArray();//获取最终各地区数据

           


            //画图柱形图的条数决定是由数据源也就Series决定。Series是对象，动态创建即可。
            Series s1 = new Series("工单");
            Series s2 = new Series("定单");
            Series s3 = new Series("合同");

            //添加工单
            for (int i = 0; i < theFinalData.Length;)
            {
                int thePnumber = 0;
                int.TryParse(theFinalData[i + 4], out thePnumber);
                s1.Points.AddXY(theFinalData[i], thePnumber);
                i = i + 6;
            }

            //添加定单
            for(int i=0;i<theFinalData.Length;)
            {
                int theOnumber = 0;
                int.TryParse(theFinalData[i + 3], out theOnumber);
                s2.Points.AddXY(theFinalData[i], theOnumber);
                i = i + 6;
            }
            //添加合同
            for (int i = 0; i < theFinalData.Length;)
            {
                int theCnumber = 0;
                int.TryParse(theFinalData[i + 5], out theCnumber);
                s3.Points.AddXY(theFinalData[i], theCnumber);
                i = i + 6;
            }

            ////随机
            //s1.Points.AddXY("双流",16);
            //s1.Points.AddXY("龙泉", 9);
            //s1.Points.AddXY("武侯", 12);

            //s2.Points.AddXY("双流", 10);
            //s2.Points.AddXY("龙泉", 11);
            //s2.Points.AddXY("武侯", 17);


            //s3.Points.AddXY("双流", 8);
            //s3.Points.AddXY("龙泉", 12);
            //s3.Points.AddXY("武侯", 5);
            //指定柱形条的颜色
            s1.Color = Color.LightBlue;
            s2.Color = Color.Pink;
            s3.Color = Color.LightGreen;
            //加入到chart1中
            chart_Month.Series.Add(s2);
            chart_Month.Series.Add(s1);
            chart_Month.Series.Add(s3);


            //Pie图
            Series s4 = new Series("客户丢失");
            //添加客户丢失
            for (int i = 0; i < theFinalData.Length;)
            {
                int theLnumber = 0;
                int.TryParse(theFinalData[i + 2], out theLnumber);
                s4.Points.AddXY(theFinalData[i], theLnumber);
                i = i + 6;
            }
            s4.Color = Color.LightBlue;
            chart_Lost.Series.Add(s4);

            //定单统计
            Series s5 = new Series("定单统计");
            //添加定单统计
            for(int i=0;i<theFinalData.Length;)
            {
                int theOnumber = 0;
                int.TryParse(theFinalData[i + 3], out theOnumber);
                s5.Points.AddXY(theFinalData[i], theOnumber);
                i = i + 6;
            }
            s5.Color = Color.LightGreen;
            chart_Orders.Series.Add(s5);

            //工单统计
            Series s6 = new Series("工单统计");
            //添加工单统计
            for (int i = 0; i < theFinalData.Length;)
            {
                int thePnumber = 0;
                int.TryParse(theFinalData[i + 4], out thePnumber);
                s6.Points.AddXY(theFinalData[i], thePnumber);
                i = i + 6;
            }
            s6.Color = Color.LightGray;
            chart_Projects.Series.Add(s6);

            //合同统计
            Series s7 = new Series("合同统计");
            //添加合同统计
            for (int i = 0; i < theFinalData.Length;)
            {
                int theCnumber = 0;
                int.TryParse(theFinalData[i + 5], out theCnumber);
                s7.Points.AddXY(theFinalData[i], theCnumber);
                i = i + 6;
            }
            s7.Color = Color.LightSkyBlue;
            chart_Contracts.Series.Add(s7);

            //List<string> xData = new List<string>();
            //List<int> yData = new List<int>();

            //for (int i = 0; i < theFinalData.Length;)
            //{
            //    xData.Add(theFinalData[i]);
            //    int theLosts;
            //    int.TryParse(theFinalData[i + 2], out theLosts);
            //    yData.Add(theLosts);
            //    i = i + 6;
            //}

            //chart_Lost.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            //chart_Lost.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            //chart_Lost.Series[0].Points.DataBindXY(xData, yData);
        }
        public void PieLost()
        {
            
            //chart_PieDistinct.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            //chart_PieDistinct.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            //chart_PieDistinct.Series[0].Points.DataBindXY(xData, yData);
        }
        public void PieKind()
        {
            List<string> xData = new List<string>() { "中国", "日本", "韩国", "朝鲜" };
            List<int> yData = new List<int>() { 10, 20, 30, 40 };
            //chart_PieKind.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            //chart_PieKind.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            //chart_PieKind.Series[0].Points.DataBindXY(xData, yData);
        }
        //获取所有客户状态数量
        public void GetAllClientStateNumber()
        {
            int theClueNumber=0;
            int theLostNumber = 0;
            int theOrderNumber = 0;
            int theProjectNumber = 0;
            int theContractNumber = 0;
            int theFollowUpNumber = 0;
            DateTime theDate;
            string newDate;
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            string[] theClienStateInfo = myWebService.GetAllClientsStateInfo().ToArray();
            for(int i=0;i<theClienStateInfo.Length;)
            {
                newDate = theClienStateInfo[i];
                DateTime.TryParse(newDate, out theDate);
                if(theDate.Month==DateTime.Now.Month)//月份为本月
                {
                    if (theClienStateInfo[i + 1] == "正在跟踪"|| theClienStateInfo[i + 1]=="稳步推进")
                    {
                        theFollowUpNumber++;
                    }
                    if (theClienStateInfo[i+1]=="客户丢失")
                    {
                        theLostNumber++;
                    }
                    if(theClienStateInfo[i+1]=="已签定单")
                    {
                        theOrderNumber++;
                    }
                    if (theClienStateInfo[i + 1] == "已签工单")
                    {
                        theProjectNumber++;
                    }
                    if (theClienStateInfo[i + 1] == "上传合同")
                    {
                        theContractNumber++;
                    }
                }

                i = i + 2;
            }
            theClueNumber = theFollowUpNumber + theLostNumber + theOrderNumber + theProjectNumber + theContractNumber;

            Label_3CluesNumber.Text = theClueNumber.ToString();
            Label_3LostNumber.Text = theLostNumber.ToString();
            Label_3NewOrderNumber.Text = theOrderNumber.ToString();
            Label_3ProjectNumber.Text = theProjectNumber.ToString();
            Label_3ContractNumber.Text = theContractNumber.ToString();
        }
        /*************************************************************/
        private void 查看信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl_Function.SelectTab(0);
        }
        private void 查看业务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            TabControl_Function.SelectTab(1);

        }

        private void 查看日程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl_Function.SelectTab(3);
        }

        private void 查看数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl_Function.SelectTab(2);
        }

        //获取地区的各种数据指标
        string[] theDistinctInfo;
        public void GetDistinctIndex()
        {
            //连接数据库
            myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
            theDistinctInfo = myWebService.JoinQuery().ToArray();

        }
        //tab3的图表查看
        private void ComboBox_3ChartView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBox_3ChartView.SelectedItem.ToString()== "本月各区域业绩统计")
            {
                //连接数据库获得数据显示在图表上
                chart_Month.Visible = true;
                chart_Lost.Visible = false;
                chart_Orders.Visible = false;
                chart_Projects.Visible = false;
                chart_Contracts.Visible = false;
            }
            else if(ComboBox_3ChartView.SelectedItem.ToString() == "本月各区域客户丢失")
            {
                //连接数据库获得数据显示在图表上
                chart_Month.Visible = false;
                chart_Lost.Visible = true;
                chart_Orders.Visible = false;
                chart_Projects.Visible = false;
                chart_Contracts.Visible = false;
            }
            else if (ComboBox_3ChartView.SelectedItem.ToString() == "本月各区域定单统计")
            {
                chart_Month.Visible = false;
                chart_Lost.Visible = false;
                chart_Orders.Visible = true;
                chart_Projects.Visible = false;
                chart_Contracts.Visible = false;
            }
            else if (ComboBox_3ChartView.SelectedItem.ToString() == "本月各区域工单统计")
            {
                chart_Month.Visible = false;
                chart_Lost.Visible = false;
                chart_Orders.Visible = false;
                chart_Projects.Visible = true;
                chart_Contracts.Visible = false;
            }
            else if (ComboBox_3ChartView.SelectedItem.ToString() == "本月各区域合同统计")
            {
                chart_Month.Visible = false;
                chart_Lost.Visible = false;
                chart_Orders.Visible = false;
                chart_Projects.Visible = false;
                chart_Contracts.Visible = true;
            }

        }

        //设定业务指标
        private void Button_AddKPI_Click(object sender, EventArgs e)
        {
            AddIndex newForm = new AddIndex(this);
            newForm.ShowDialog();
            newForm.TopMost = true;
        }
        //查看业务指标
        private void Button_ViewKPI_Click(object sender, EventArgs e)
        {
            ShowIndex newForm = new ShowIndex();
            newForm.ShowDialog();
            newForm.TopMost = true;
        }
        //修改业务指标
        private void Button_SetKPI_Click(object sender, EventArgs e)
        {
            UpdateIndex newForm = new UpdateIndex();
            newForm.ShowDialog();
            newForm.TopMost = true;
        }

        private void Button_2DeleteClient_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除该客户？", "删除客户", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string thePhone;
                if (ListView_2State.SelectedIndices != null && ListView_2State.SelectedIndices.Count > 0)
                {
                    thePhone = ListView_2State.SelectedItems[0].SubItems[2].Text;//获取客户电话号码
                    ClientPhone = thePhone;
                    string theClientState= ListView_2State.SelectedItems[0].SubItems[7].Text; //获取客户状态
                    theName = ListView_2State.SelectedItems[0].SubItems[1].Text;//获取客户姓名
                                                                                //连接数据库
                    myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                    bool theResult = myWebService.DeletePersonalInfo(thePhone);

                    if (theResult == true)
                    {
                        if(theClientState=="正在跟踪" || theClientState=="稳步推进" || theClientState=="客户丢失")
                        {
                            //删除业务明细中的信息
                            myWebService.DeleteBusinessInfo(thePhone);
                        }
                        if(theClientState=="已签定单")
                        {
                            //删除定单表中的信息
                            myWebService.DeleteContractInfo(thePhone);
                            //删除业务明细中的信息
                            myWebService.DeleteBusinessInfo(thePhone);
                        }
                        if(theClientState=="已签工单")
                        {
                            //删除工单表中的信息
                            myWebService.DeleteProjectListInfo(thePhone);
                            //删除定单表中的信息
                            myWebService.DeleteContractInfo(thePhone);
                            //删除业务明细中的信息
                            myWebService.DeleteBusinessInfo(thePhone);
                        }
                        if(theClientState=="上传合同")
                        {
                            //删除合同表中的信息
                            myWebService.DeleteImagePath(thePhone);
                            //删除工单表中的信息
                            myWebService.DeleteProjectListInfo(thePhone);
                            //删除定单表中的信息
                            myWebService.DeleteContractInfo(thePhone);
                            //删除业务明细中的信息
                            myWebService.DeleteBusinessInfo(thePhone);
                        }

                        MessageBox.Show("删除成功！");
                        //更新表
                        /*********************************************/
                        if (ListView_2State.Items.Count >= 1)
                        {
                            ListView_2State.Items.Clear();
                        }
                        List<Client> clientList = new List<Client>();

                        int theStaffId;
                        string theStringId = ComboBox_2Staff.SelectedItem.ToString();
                        theStaffId = Convert.ToInt32(theStringId.Substring(0, 6));

                        myWebService = new ServiceReference1.WebServiceSoapClient("WebServiceSoap");
                        string[] clientInfo = myWebService.TheClientInfo(theStaffId).ToArray();

                        for (int i = 0; i < clientInfo.Length;)
                        {
                            clientList.Add(new Client() { Date = clientInfo[i], Name = clientInfo[i + 1], Phone = clientInfo[i + 2], Plot = clientInfo[i + 3], HouseType = clientInfo[i + 4], Priority = clientInfo[i + 5], UserId = clientInfo[i + 6], State = clientInfo[i + 7],ClientType=clientInfo[i+8] });
                            i = i + 9;
                        }
                        pageClientList = new PageInfo<Client>(clientList, 4);

                        Client[] theClientInfo = pageClientList.GetPageData(JumpOperation.GoHome).ToArray();

                        for (int i = 0; i < theClientInfo.Length; i++)
                        {
                            string theDate = theClientInfo[i].Date;
                            theDate = theDate.Substring(0, theDate.Length - 8);
                            ListViewItem lit = ListView_2State.Items.Add(theDate);
                            lit.SubItems.Add(theClientInfo[i].Name);
                            lit.SubItems.Add(theClientInfo[i].Phone);
                            lit.SubItems.Add(theClientInfo[i].Plot);
                            lit.SubItems.Add(theClientInfo[i].HouseType);
                            lit.SubItems.Add(theClientInfo[i].Priority);
                            lit.SubItems.Add(theClientInfo[i].UserId);
                            lit.SubItems.Add(theClientInfo[i].State);
                            lit.SubItems.Add(theClientInfo[i].ClientType);
                        }
                        if (ListView_2Detail.Items.Count >= 1)
                        {
                            ListView_2Detail.Items.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
            Button_2Book1.Enabled = false;
            Button_2Book2.Enabled = false;
            Button_2Image.Enabled = false;
        }

        private void Button_MQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Button_MAlterPassword_Click(object sender, EventArgs e)
        {
            AlterPassword alterPassword = new AlterPassword(this);
            alterPassword.ShowDialog();
            alterPassword.TopMost = true;
        }

        //加载Tab数据统计数据
        private void TabControl_Function_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TabControl_Function.SelectedIndex==2)
            {
                if(chart_Lost.Series.Count>0)
                {
                    chart_Lost.Series.Clear();
                }
                if(chart_Month.Series.Count>0)
                {
                    chart_Month.Series.Clear();
                }
                if(chart_Orders.Series.Count>0)
                {
                    chart_Orders.Series.Clear();
                }
                if(chart_Projects.Series.Count>0)
                {
                    chart_Projects.Series.Clear();
                }
                if(chart_Contracts.Series.Count>0)
                {
                    chart_Contracts.Series.Clear();
                }
                //第三个Tab,数据统计
                /*************************************************/
                GetAllClientStateNumber();
                ComboBox_3ChartView.SelectedIndex = 0;
                //数据统计
                GetDistinctIndex();
                BarChart();
            }
           
        }
    }
}
