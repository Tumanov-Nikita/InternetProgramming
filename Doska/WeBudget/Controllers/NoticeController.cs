using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;
using WeBudget.Service.Abstract;
using WeBudget.Service.FileService;

namespace WeBudget.Controllers
{
    public class NoticeController : Controller
    {
        String store = ConfigurationManager.AppSettings.Get("Store");
        IDoska noticeservice;


        public NoticeController()
        {
            if (store == "db")
            {
                noticeservice = new NoticeService();
            }

            if (store == "file")
            {
                noticeservice = new NoticeFileService();
            }
        }
      

        [HttpGet]
        public ActionResult EditNotice(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (noticeservice.findById(id) != null)
            {
                return View(noticeservice.findById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditNotice(Notice notice)

        {
            noticeservice.Edit(notice);
            return RedirectToAction("Notices");
        }

        [HttpGet]
        public ActionResult CreateNotice()

        {
            return View();
        }

        [HttpGet]
        public ActionResult Notice(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            if (noticeservice.findById(id) != null)
            {
                return View(noticeservice.findById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult CreateNotice(Notice notice, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var pic = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Files"), pic);
                file.SaveAs(path);
                notice.picFileName = "Files/"+pic;
                ViewBag.pic = file.FileName;
            }
            noticeservice.Create(notice);
            return RedirectToAction("Notices");
        }


        public ActionResult DeleteNotice(int id)
        {
            noticeservice.Delete(id);
            return RedirectToAction("Notices");
        }


        public ActionResult Notices()
        {          
             return View(noticeservice.getList());
        }
    }
}