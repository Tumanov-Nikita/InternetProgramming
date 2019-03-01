using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service.FileService
{
    public class NoticeFileService : AbstractClass
    {
        string Name = "Notice";
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Notice";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Notice));

        public NoticeFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

    }
}