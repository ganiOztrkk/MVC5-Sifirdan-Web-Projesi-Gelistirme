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
            return RedirectToAction("Index");
        }
        public ActionResult KulupSil(int id)
        {
            var kulup = db.TBLKULUPLERs.Find(id);
            db.TBLKULUPLERs.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KulupGuncelle(int id)
        {
            var kulup = db.TBLKULUPLERs.Find(id);
            return View("KulupGuncelle", kulup);
        }
        [HttpPost]
        public ActionResult KulupGuncelle(TBLKULUPLER tblkulupler)
        {
            var kulup = db.TBLKULUPLERs.Find(tblkulupler.KULUPID);
            kulup.KULUPAD = tblkulupler.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}