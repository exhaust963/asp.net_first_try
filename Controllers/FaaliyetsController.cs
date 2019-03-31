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
    public class FaaliyetsController : Controller
    {
        private loginEntities1 db = new loginEntities1();

        // GET: Faaliyets
        public ActionResult Index(string sorgu1,string sorgu2,string sorgu3,string sorgu4,string sorgu5,string sorgu6)
        {
            return View(db.Faaliyet.Where(fa=>fa.Faaliyet_atayan.Contains(sorgu1) && fa.Faaliyet_tür.Contains(sorgu2) && fa.Faaliyet_sahibi.Contains(sorgu3) && fa.Önem_derecesi.Contains(sorgu4) && fa.Konu.Contains(sorgu5) && fa.Proje.Contains(sorgu6)||sorgu1==null || sorgu2 == null || sorgu3 == null || sorgu4 == null).ToList());
        }

        // GET: Faaliyets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faaliyet faaliyet = db.Faaliyet.Find(id);
            if (faaliyet == null)
            {
                return HttpNotFound();
            }
            return View(faaliyet);
        }

        // GET: Faaliyets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faaliyets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Faaliyet_id,Faaliyet_tür,Konu,Faaliyet_sahibi,Faaliyet_atayan,Oluşturma_tarih,Proje,Önem_derecesi,Açıklama,Öngörülen_başlama,Öngörülen_bitiş,İlgili_kurum")] Faaliyet faaliyets)
        {
            if (ModelState.IsValid)
            {
                db.Faaliyet.Add(faaliyets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faaliyets);
        }

        // GET: Faaliyets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faaliyet faaliyet = db.Faaliyet.Find(id);
            if (faaliyet == null)
            {
                return HttpNotFound();
            }
            return View(faaliyet);
        }

        // POST: Faaliyets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Faaliyet_id,Faaliyet_tür,Konu,Faaliyet_sahibi,Faaliyet_atayan,Oluşturma_tarih,Proje,Önem_derecesi,Açıklama,Öngörülen_başlama,Öngörülen_bitiş,İlgili_kurum")] Faaliyet faaliyet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faaliyet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faaliyet);
        }

        // GET: Faaliyets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faaliyet faaliyet = db.Faaliyet.Find(id);
            if (faaliyet == null)
            {
                return HttpNotFound();
            }
            return View(faaliyet);
        }

        // POST: Faaliyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faaliyet faaliyet = db.Faaliyet.Find(id);
            db.Faaliyet.Remove(faaliyet);
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
