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
     [Authorize]
    public class Table1Controller : Controller
    {
        // db connection moved to Models/EFTable1Repository.cs
        //private Model1 db = new Model1();
        private Table1Repository db;

        // if no mock specified then use db

            public Table1Controller()
        {
            this.db = new EFTable1Repository();
        }

        // if we tell the recorder that we are testing then use the mock interface
        public Table1Controller(Table1Repository db)
        {
            this.db = db;
        }

         //GET: Table1
        public ViewResult Index()
        {
            return View(db.Table1.ToList());
        }
        [AllowAnonymous]

        // GET: Table1/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Table1 table1 = db.Table1.FirstOrDefault(a => a.Price == id);
            if (table1 == null)
            {
                return View("Error");
            }
            return View(table1);
        }

        //// GET: Table1/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Table1/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Price,Songs,Album,Movie")] Table1 table1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Table1.Add(table1);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(table1);
        //}


        //// GET: Table1/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Table1 table1 = db.Table1.Find(id);
        //    if (table1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(table1);
        //}

        // POST: Table1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Price,Songs,Album,Movie")] Table1 table1)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(table1).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(table1);
        //    }

        //    // GET: Table1/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Table1 table1 = db.Table1.Find(id);
        //        if (table1 == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(table1);
        //    }

        // POST: Table1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ViewResult DeleteConfirmed(int? id)
        {
            if
            (id == null)
            {
                return View("Error");
            }
            Table1 table1 = db.Table1.FirstOrDefault(a => a.Price == id);
            if (table1 == null)
            {
                return View("Error");
            }
            db.Delete(table1);
            return View("Index");
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
