using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class etpsController : Controller
    {
        private etpEntities db = new etpEntities();

        // GET: etps
        public ActionResult Index()
        {
            return View(db.etps.ToList());
        }

        // GET: etps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etp etp = db.etps.Find(id);
            if (etp == null)
            {
                return HttpNotFound();
            }
            return View(etp);
        }

        // GET: etps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: etps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "question,Name,Time,College,Done")] etp etp)
        {
            if (ModelState.IsValid)
            {
                db.etps.Add(etp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etp);
        }

        // GET: etps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etp etp = db.etps.Find(id);
            if (etp == null)
            {
                return HttpNotFound();
            }
            return View(etp);
        }

        // POST: etps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "question,Name,Time,College,Done")] etp etp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etp);
        }

        // GET: etps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etp etp = db.etps.Find(id);
            if (etp == null)
            {
                return HttpNotFound();
            }
            return View(etp);
        }

        // POST: etps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            etp etp = db.etps.Find(id);
            db.etps.Remove(etp);
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
