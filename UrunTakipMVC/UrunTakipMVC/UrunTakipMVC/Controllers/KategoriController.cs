using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipMVC.Models.Entity;

namespace UrunTakipMVC.Controllers
{
    public class KategoriController : Controller
    {
        private DbStokMVCEntities db = new DbStokMVCEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var values = db.Kategorilers.Where(x => x.Durum == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler kategoriler)
        {
            kategoriler.Durum = true;
            db.Kategorilers.Add(kategoriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(Kategoriler kategoriler)
        {
            var kategori = db.Kategorilers.Find(kategoriler.ID);
            kategori.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.Kategorilers.Find(id);
            return View("KategoriGuncelle", kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategoriler kategoriler)
        {
            var kategori = db.Kategorilers.Find(kategoriler.ID);
            kategori.Ad = kategoriler.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}