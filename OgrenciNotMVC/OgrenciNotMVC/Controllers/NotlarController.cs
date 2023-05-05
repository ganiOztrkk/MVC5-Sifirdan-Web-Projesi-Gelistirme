using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.Entity;

namespace OgrenciNotMVC.Controllers
{
    public class NotlarController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Notlar
        public ActionResult Index()
        {
            var values = db.TBLNOTLARs.ToList();
            return View(values);
        }

        public ActionResult YeniNot()
        {
            return View();
        }


    }
}