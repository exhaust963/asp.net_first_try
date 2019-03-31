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
    public class Faaliyet_türüController : Controller
    {
        private loginEntities1 db = new loginEntities1();

        // GET: Faaliyet_türü
        public ActionResult Index(string sorgu1)
        {
            return View(db.Faaliyet_türü.Where(ku => ku.Faaliyet_tür.Contains(sorgu1) || sorgu1 == null).ToList());
        }

        // GET: Faaliyet_türü/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faaliyet_türü faaliyet_türü = db.Faaliyet_türü.Find(id);
            if (faaliyet_türü == null)
            {
                return HttpNotFound();
            }
            return View(faaliyet_türü);
        }

        // GET: Faaliyet_türü/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faaliyet_türü/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Faaliyet_id,Faaliyet_tür")] Faaliyet_türü faaliyet_türü)
        {
            if (ModelState.IsValid)
            {
                db.Faaliyet_türü.Add(faaliyet_türü);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faaliyet_türü);
        }

        // GET: Faaliyet_türü/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faaliyet_türü faaliyet_türü = db.Faaliyet_türü.Find(id);
            if (faaliyet_türü == null)
            {
                return HttpNotFound();
            }
            return View(faaliyet_türü);
        }

        // POST: Faaliyet_türü/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Faaliyet_id,Faaliyet_tür")] Faaliyet_türü faaliyet_türü)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faaliyet_türü).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faaliyet_türü);
        }

        // GET: Faaliyet_türü/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faaliyet_türü faaliyet_türü = db.Faaliyet_türü.Find(id);
            if (faaliyet_türü == null)
            {
                return HttpNotFound();
            }
            return View(faaliyet_türü);
        }

        // POST: Faaliyet_türü/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faaliyet_türü faaliyet_türü = db.Faaliyet_türü.Find(id);
            db.Faaliyet_türü.Remove(faaliyet_türü);
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
