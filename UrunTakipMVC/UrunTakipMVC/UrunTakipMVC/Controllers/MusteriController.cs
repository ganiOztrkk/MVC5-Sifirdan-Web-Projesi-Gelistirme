using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using UrunTakipMVC.Models.Entity;

namespace UrunTakipMVC.Controllers
{
    public class MusteriController : Controller
    {
        DbStokMVCEntities db = new DbStokMVCEntities();
        [Authorize]
        public ActionResult Index(int sayfa =1)
        {
            var musteriler = db.Musterilers.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 3);
            return View(musteriler);
        }

        public ActionResult MusteriSil(Musteriler musteriler)
        {
            var musteri = db.Musterilers.Find(musteriler.ID);
            musteri.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(Musteriler musteriler)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            musteriler.Durum = true;
            db.Musterilers.Add(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.Musterilers.Find(id);
            return View(musteri);
        }

        [HttpPost]
        public ActionResult MusteriGuncelle(Musteriler musteriler)
        {
            var musteri = db.Musterilers.Find(musteriler.ID);
            musteri.Ad = musteriler.Ad;
            musteri.Soyad = musteriler.Soyad;
            musteri.Sehir = musteriler.Sehir;
            musteri.Bakiye = musteriler.Bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}