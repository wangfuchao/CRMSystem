using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMSystemApp.Business.Models
{
    public class News
    {
        public News()
        {

        }
        public string Post { get; set; }//职位
        public string Date { get; set; }//日期
        public string Theme { get; set; }//主题
        public string Head { get; set; }//标题
        public ImageSource Photo { get; set; }//图片
        public string Content { get; set; }//内容
    }
    

}
