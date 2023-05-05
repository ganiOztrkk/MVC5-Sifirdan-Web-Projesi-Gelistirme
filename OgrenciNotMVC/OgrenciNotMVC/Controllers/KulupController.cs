using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.Entity;

namespace OgrenciNotMVC.Controllers
{
    public class KulupController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Kulup
        public ActionResult Index()
        {
            var values = db.TBLKULUPLERs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KulupEkle(TBLKULUPLER tblkulupler)
        {
            db.TBLKULUPLERs.Add(tblkulupler);
            db.SaveChanges();
            return View();
        }
    }
}