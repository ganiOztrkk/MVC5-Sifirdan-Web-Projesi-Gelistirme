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
        [HttpGet]
        public ActionResult YeniNot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniNot(TBLNOTLAR tblnotlar)
        {
            db.TBLNOTLARs.Add(tblnotlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NotGuncelle(int id)
        {
            var not = db.TBLNOTLARs.Find(id);
            return View("NotGuncelle",not);
        }
    }
}