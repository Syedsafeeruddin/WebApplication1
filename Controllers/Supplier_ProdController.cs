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
    public class Supplier_ProdController : Controller
    {
        private DBMSProjectIMSEntities db = new DBMSProjectIMSEntities();

        // GET: Supplier_Prod
        public ActionResult Index()
        {
            var supplier_Prod = db.Supplier_Prod.Include(s => s.Product).Include(s => s.Supplier);
            return View(supplier_Prod.ToList());
        }

        // GET: Supplier_Prod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_Prod supplier_Prod = db.Supplier_Prod.Find(id);
            if (supplier_Prod == null)
            {
                return HttpNotFound();
            }
            return View(supplier_Prod);
        }

        // GET: Supplier_Prod/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Prod_Name");
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name");
            return View();
        }

        // POST: Supplier_Prod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supplier_Prod_ID,Supplier_ID,Product_ID,Sup_Name,Sup_Price,Supplier_Quantity,Date")] Supplier_Prod supplier_Prod)
        {
            if (ModelState.IsValid)
            {
                db.Supplier_Prod.Add(supplier_Prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", supplier_Prod.Product_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name", supplier_Prod.Supplier_ID);
            return View(supplier_Prod);
        }

        // GET: Supplier_Prod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_Prod supplier_Prod = db.Supplier_Prod.Find(id);
            if (supplier_Prod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", supplier_Prod.Product_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name", supplier_Prod.Supplier_ID);
            return View(supplier_Prod);
        }

        // POST: Supplier_Prod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supplier_Prod_ID,Supplier_ID,Product_ID,Sup_Name,Sup_Price,Supplier_Quantity,Date")] Supplier_Prod supplier_Prod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier_Prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", supplier_Prod.Product_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name", supplier_Prod.Supplier_ID);
            return View(supplier_Prod);
        }

        // GET: Supplier_Prod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_Prod supplier_Prod = db.Supplier_Prod.Find(id);
            if (supplier_Prod == null)
            {
                return HttpNotFound();
            }
            return View(supplier_Prod);
        }

        // POST: Supplier_Prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_Prod supplier_Prod = db.Supplier_Prod.Find(id);
            db.Supplier_Prod.Remove(supplier_Prod);
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
