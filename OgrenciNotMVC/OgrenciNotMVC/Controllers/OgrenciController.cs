using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.Entity;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcSchoolEntities db = new DbMvcSchoolEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var values = db.TBLOGRENCILERs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> kulup = (from i in db.TBLKULUPLERs.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.kulupler = kulup;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(TBLOGRENCILER tblogrenciler)
        {
            var kulup = db.TBLKULUPLERs.FirstOrDefault(x => x.KULUPID == tblogrenciler.TBLKULUPLER.KULUPID);
            tblogrenciler.TBLKULUPLER = kulup;
            db.TBLOGRENCILERs.Add(tblogrenciler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}