using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models;
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

        [HttpPost]
        public ActionResult NotGuncelle(TBLNOTLAR tblnotlar, Hesap hesap, int sinav1=0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
        {
            if (hesap.Islem == "HESAPLA")
            {
                int ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }

            if (hesap.Islem == "GUNCELLE")
            {
                var sinav = db.TBLNOTLARs.Find(tblnotlar.NOTID);
                sinav.SINAV1 = tblnotlar.SINAV1;
                sinav.SINAV2 = tblnotlar.SINAV2;
                sinav.SINAV3 = tblnotlar.SINAV3;
                sinav.ORTALAMA = tblnotlar.ORTALAMA;
                sinav.PROJE = tblnotlar.PROJE;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}