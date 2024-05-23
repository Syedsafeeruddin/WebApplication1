using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class Sales_PersonController : Controller
    {
        private DBMSProjectIMSEntities db = new DBMSProjectIMSEntities();

        // GET: Sales_Person
        public ActionResult Index()
        {
            return View(db.Sales_Person.ToList());
        }

        // GET: Sales_Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = db.Sales_Person.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // GET: Sales_Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales_Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sales_Person_ID,Sales_Person_Name,Order_ID,Date")] Sales_Person sales_Person)
        {
            if (ModelState.IsValid)
            {
                db.Sales_Person.Add(sales_Person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sales_Person);
        }

        // GET: Sales_Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = db.Sales_Person.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // POST: Sales_Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sales_Person_ID,Sales_Person_Name,Order_ID,Date")] Sales_Person sales_Person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_Person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales_Person);
        }

        // GET: Sales_Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = db.Sales_Person.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // POST: Sales_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales_Person sales_Person = db.Sales_Person.Find(id);
            db.Sales_Person.Remove(sales_Person);
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
