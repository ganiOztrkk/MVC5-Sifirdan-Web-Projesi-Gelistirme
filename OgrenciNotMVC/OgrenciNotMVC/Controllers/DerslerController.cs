using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.Entity;

namespace OgrenciNotMVC.Controllers
{
    public class DerslerController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Dersler
        public ActionResult Index()
        {
            var values = db.TBLDERSLERs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER tbldersler)
        {
            db.TBLDERSLERs.Add(tbldersler);
            db.SaveChanges();
            return View();
        }
    }
}