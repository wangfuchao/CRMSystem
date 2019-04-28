using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMSystemApp.Business.Models
{
    public class Clients
    {
        public Clients()
        {

        }
        public string Name { get; set; }//姓名
        public string Phone { get; set; }//电话
        public string HouseType { get; set; }//房屋类型
        public string Priority { get; set; }//优先级
        public ImageSource Photo { get; set; }//图片
        public string State { get; set; }//线索状态
        
    }
}
