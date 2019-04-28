using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystemApp.Interfaces
{
    public interface IUploadImages
    {
        string UpLoadImage(byte[] fileBytes, string phone);
    }
}
