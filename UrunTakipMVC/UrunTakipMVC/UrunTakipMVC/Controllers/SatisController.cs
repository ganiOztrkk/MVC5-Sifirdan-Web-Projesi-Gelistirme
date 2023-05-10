using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using UrunTakipMVC.Models.Entity;

namespace UrunTakipMVC.Controllers
{
    public class SatisController : Controller
    {
        DbStokMVCEntities db = new DbStokMVCEntities();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var siparisler = db.Satislars.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 5);
            return View(siparisler);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            //ürünler dropdownlist
            List<SelectListItem> urunler = (from x in db.Urunlers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Ad,
                                                Value = x.ID.ToString()
                                            }).ToList();
            ViewBag.urun = urunler;

            //personeller dropdownlist
            List<SelectListItem> personeller = (from x in db.Personellers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Ad +" "+ x.Soyad,
                                                    Value = x.ID.ToString()

                                                }).ToList();
            ViewBag.personel = personeller;

            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(Satislar satislar)
        {
            satislar.Durum = true;
            var urun = db.Urunlers.FirstOrDefault(x => x.ID == satislar.Urunler.ID);
            var personel = db.Personellers.FirstOrDefault(x => x.ID == satislar.Personeller.ID);
            satislar.Urunler = urun;
            satislar.Personeller = personel;
            satislar.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Satislars.Add(satislar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}