using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipMVC.Models.Entity;

namespace UrunTakipMVC.Controllers
{
    public class UrunController : Controller
    {
        DbStokMVCEntities db = new DbStokMVCEntities();
        public ActionResult Index()
        {
            var urunler = db.Urunlers.Where(x=>x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> linqkategori = (from x in db.Kategorilers.ToList()
                select new SelectListItem
                {
                    Text = x.Ad,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.vKategori = linqkategori;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler urunler)
        {
            urunler.Durum = true;
            var kategori = db.Kategorilers.FirstOrDefault(x => x.ID == urunler.Kategoriler.ID);
            urunler.Kategoriler = kategori;
            db.Urunlers.Add(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> linqktgr = (from x in db.Kategorilers.ToList()
                select new SelectListItem
                {
                    Text = x.Ad,
                    Value = x.ID.ToString()
                }).ToList();
            var urun = db.Urunlers.Find(id);
            ViewBag.kategoriler = linqktgr;
            return View("UrunGuncelle", urun);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urunler urunler)
        {
            var urun = db.Urunlers.Find(urunler.ID);
            urun.Ad = urunler.Ad;
            urun.Marka = urunler.Marka;
            urun.Stok = urunler.Stok;
            urun.AlisFiyat = urunler.AlisFiyat;
            urun.SatisFiyat = urunler.SatisFiyat;
            var ktg = db.Kategorilers.FirstOrDefault(x => x.ID == urunler.Kategoriler.ID);
            urun.Kategori = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(Urunler urunler)
        {
            var urun = db.Urunlers.Find(urunler.ID);
            urun.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}