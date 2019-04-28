using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Business
{
    public interface IDialer
    {
        bool Dial(string number);
    }
}
