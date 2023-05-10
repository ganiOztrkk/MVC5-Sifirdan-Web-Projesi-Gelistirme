using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipMVC.Models.Entity;

namespace UrunTakipMVC.Controllers
{
    public class AdminController : Controller
    {
        DbStokMVCEntities db = new DbStokMVCEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Adminler adminler)
        {
            db.Adminlers.Add(adminler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}