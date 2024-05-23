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
    public class StocksController : Controller
    {
        private DBMSProjectIMSEntities db = new DBMSProjectIMSEntities();

        // GET: Stocks
        public ActionResult Index()
        {
            var stocks = db.Stocks.Include(s => s.Customer).Include(s => s.Order).Include(s => s.Order_Line).Include(s => s.Product).Include(s => s.Supplier);
            return View(stocks.ToList());
        }

        // GET: Stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.Cus_ID = new SelectList(db.Customers, "Cus_ID", "Cus_Name");
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name");
            ViewBag.Order_Line_ID = new SelectList(db.Order_Line, "Order_Line_ID", "Order_Line_ID");
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name");
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stock_ID,Prod_ID,Prod_Name,Cus_ID,Supplier_ID,Sup_Name,Quantity,Stock_In,Stock_Out,Order_ID,Order_Line_ID,Date")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cus_ID = new SelectList(db.Customers, "Cus_ID", "Cus_Name", stock.Cus_ID);
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name", stock.Order_ID);
            ViewBag.Order_Line_ID = new SelectList(db.Order_Line, "Order_Line_ID", "Order_Line_ID", stock.Order_Line_ID);
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", stock.Prod_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name", stock.Supplier_ID);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cus_ID = new SelectList(db.Customers, "Cus_ID", "Cus_Name", stock.Cus_ID);
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name", stock.Order_ID);
            ViewBag.Order_Line_ID = new SelectList(db.Order_Line, "Order_Line_ID", "Order_Line_ID", stock.Order_Line_ID);
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", stock.Prod_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name", stock.Supplier_ID);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stock_ID,Prod_ID,Prod_Name,Cus_ID,Supplier_ID,Sup_Name,Quantity,Stock_In,Stock_Out,Order_ID,Order_Line_ID,Date")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cus_ID = new SelectList(db.Customers, "Cus_ID", "Cus_Name", stock.Cus_ID);
            ViewBag.Order_ID = new SelectList(db.Orders, "Order_ID", "Prod_Name", stock.Order_ID);
            ViewBag.Order_Line_ID = new SelectList(db.Order_Line, "Order_Line_ID", "Order_Line_ID", stock.Order_Line_ID);
            ViewBag.Prod_ID = new SelectList(db.Products, "Product_ID", "Prod_Name", stock.Prod_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "Supplier_ID", "Sup_Name", stock.Supplier_ID);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stocks.Find(id);
            db.Stocks.Remove(stock);
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
