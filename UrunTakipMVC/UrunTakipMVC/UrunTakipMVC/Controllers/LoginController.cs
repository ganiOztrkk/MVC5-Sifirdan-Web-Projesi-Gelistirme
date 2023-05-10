using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UrunTakipMVC.Models.Entity;

namespace UrunTakipMVC.Controllers
{
    public class LoginController : Controller
    {
        DbStokMVCEntities db = new DbStokMVCEntities();
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Adminler adminler)
        {
            var bilgiler = db.Adminlers.FirstOrDefault(x=> x.Kullanici == adminler.Kullanici && x.Sifre == adminler.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici,false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
        }
    }
}