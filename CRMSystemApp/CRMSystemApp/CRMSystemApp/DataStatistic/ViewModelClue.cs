using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMSystemApp.DataStatistic
{
    public class ViewModelClue
    {
        public List<Clues> Data { get; set; }
        public ViewModelClue()
        {
            int theuId;
            int.TryParse(App.UserId, out theuId);
            var Checks = DependencyService.Get<Interfaces.IDataStatistic>();
            string[] clientInfo;
            clientInfo = Checks.GetClueInfos(theuId);
            int infoLength = clientInfo.Length;
            int theLostNumber = 0;
            int theOnTraceNumber = 0;
            for(int i=0;i<infoLength;i++)
            {
                if(clientInfo[i]=="正在跟踪" ||clientInfo[i]=="稳步推进")
                {
                    theOnTraceNumber++;
                }
                if(clientInfo[i]=="客户丢失")
                {
                    theLostNumber++;
                }
            }


            Data = new List<Clues>()
            {
                new Clues { StateName = "正在跟踪", StateNumber = theOnTraceNumber },
                new Clues { StateName = "客户丢失", StateNumber = theLostNumber },
            };
        }
    }
}
