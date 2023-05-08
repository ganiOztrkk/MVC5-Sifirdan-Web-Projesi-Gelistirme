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
            return RedirectToAction("Index");
        }

        public ActionResult DersSil(int id)
        {
            var ders = db.TBLDERSLERs.Find(id);
            db.TBLDERSLERs.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DersGuncelle(int id)
        {
            var ders = db.TBLDERSLERs.Find(id);
            return View("DersGuncelle", ders);
        }

        [HttpPost]
        public ActionResult DersGuncelle(TBLDERSLER tbldersler)
        {
            var ders = db.TBLDERSLERs.Find(tbldersler.DERSID);
            ders.DERSAD = tbldersler.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}