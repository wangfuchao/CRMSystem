using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp
{
    public interface ILogin
    {
        bool LoginCheck(int UserId, string Password);
        string[] CheckClass(int UserId, string Password);
    }
}
