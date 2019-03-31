using staj2.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace staj2.Controllers
{
    public class KullaniciController : Controller
    {
        private loginEntities1 db = new loginEntities1();
        // GET: Kullanici
        public ActionResult KullaniciList()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();
        }
        public ActionResult EklemeHata()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tc,Ad,Soyad,Kuladi,Sifre,Mail,Telefon,Aciltel,Cinsiyet,Doğum,Medeni,Kultip,Kulil,Kulilçe,Adres,İban,Başlama,Ayrılma,Okul,Bölüm,Resim")] log kullanici_Listesi)
        {
            if (ModelState.IsValid)
            {
                db.log.Add(kullanici_Listesi);
                db.SaveChanges();
                return RedirectToAction("Create","logs");
            }

            return View(kullanici_Listesi);
        }


    }
}