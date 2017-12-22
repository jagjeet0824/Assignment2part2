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
    public class Table2Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: Table2
        public ActionResult Index()
        {
            var table2 = db.Table2.Include(t => t.Table1);
            return View(table2.ToList());
        }

        // GET: Table2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table2 table2 = db.Table2.Find(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            return View(table2);
        }

        // GET: Table2/Create
        public ActionResult Create()
        {
            ViewBag.Price = new SelectList(db.Table1, "Price", "Songs");
            return View();
        }

        // POST: Table2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Number,Gender,Awards,Price")] Table2 table2)
        {
            if (ModelState.IsValid)
            {
                db.Table2.Add(table2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Price = new SelectList(db.Table1, "Price", "Songs", table2.Price);
            return View(table2);
        }

        // GET: Table2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table2 table2 = db.Table2.Find(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Price = new SelectList(db.Table1, "Price", "Songs", table2.Price);
            return View(table2);
        }

        // POST: Table2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Number,Gender,Awards,Price")] Table2 table2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Price = new SelectList(db.Table1, "Price", "Songs", table2.Price);
            return View(table2);
        }

        // GET: Table2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table2 table2 = db.Table2.Find(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            return View(table2);
        }

        // POST: Table2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table2 table2 = db.Table2.Find(id);
            db.Table2.Remove(table2);
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
