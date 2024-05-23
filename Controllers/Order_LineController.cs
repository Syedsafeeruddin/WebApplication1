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
    public class Order_LineController : Controller
    {
        private DBMSProjectIMSEntities db = new DBMSProjectIMSEntities();

        // GET: Order_Line
        public ActionResult Index()
        {
            var order_Line = db.Order_Line.Include(o => o.Order).Include(o => o.Product);
            return View(order_Line.ToList());
        }

        // GET: Order_Line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // GET: Order_Line/Create
        public ActionResult Create()
        {
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name");
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name");
            return View();
        }

        // POST: Order_Line/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Line_ID,Order_ID,Prod_ID,Quantity,Price,Date")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Order_Line.Add(order_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name", order_Line.Order_ID);
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", order_Line.Prod_ID);
            return View(order_Line);
        }

        // GET: Order_Line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name", order_Line.Order_ID);
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", order_Line.Prod_ID);
            return View(order_Line);
        }

        // POST: Order_Line/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Line_ID,Order_ID,Prod_ID,Quantity,Price,Date")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name", order_Line.Order_ID);
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", order_Line.Prod_ID);
            return View(order_Line);
        }

        // GET: Order_Line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // POST: Order_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Line order_Line = db.Order_Line.Find(id);
            db.Order_Line.Remove(order_Line);
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
