using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVC.Controllers
{
    public class HesapController : Controller
    {
        public ActionResult Index(decimal sayi1 = 0, decimal sayi2 = 0)
        {
            decimal toplam = sayi1 + sayi2;
            ViewBag.sonucToplam = toplam;

            return View();
        }
    }
}