using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using staj2.data;

namespace staj2.Controllers
{
    public class logsController : Controller
    {
        private loginEntities1 db = new loginEntities1();

        // GET: logs
        public ActionResult Index(string sorgu1, string sorgu2, string sorgu3)
        {

            return View(db.log.Where(ku => ku.Ad.Contains(sorgu3) && ku.Tc.Contains(sorgu1) && ku.Kultip.Contains(sorgu2) || sorgu1 == null || sorgu2 == null || sorgu3 == null).ToList());
        }

        // GET: logs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.log.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // GET: logs/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tc,Ad,Soyad,Kuladi,Sifre,Mail,Telefon,Aciltel,Cinsiyet,Doğum,Medeni,Kultip,Kulil,Kulilçe,Adres,İban,Başlama,Ayrılma,Okul,Bölüm,Resim")] log kullanici)
        {         
                if (ModelState.IsValid)
                {
                    db.log.Add(kullanici);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(kullanici);           
}
       

        // GET: logs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.log.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tc,Ad,Soyad,Kuladi,Sifre,Mail,Telefon,Aciltel,Cinsiyet,Doğum,Medeni,Kultip,Kulil,Kulilçe,Adres,İban,Başlama,Ayrılma,Okul,Bölüm,Resim")] log log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(log);
        }
        // GET: logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.log.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }
        // POST: logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            log log = db.log.Find(id);
            db.log.Remove(log);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
