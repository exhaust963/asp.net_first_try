using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using staj2.Models.Giris;

namespace staj2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult GIRIS()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GIRIS(string isim, string sifre)
        {
            if (new Account().Basarili(isim, sifre))
            {
                Session["Kullanici"] = isim;
                return RedirectToAction("Anasayfa", "Main");
            }
            else
                return RedirectToAction("GIRIS", "Home");
        }
    }
}