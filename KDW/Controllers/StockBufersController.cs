using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Models;

namespace KDW.Controllers
{
    public class StockBufersController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: StockBufers
        public ActionResult Index()
        {
            var stockBufer = db.StockBufer.Include(s => s.t_Stock);
            return View(stockBufer.ToList());
        }

        // GET: StockBufers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBufer stockBufer = db.StockBufer.Find(id);
            if (stockBufer == null)
            {
                return HttpNotFound();
            }
            return View(stockBufer);
        }

        // GET: StockBufers/Create
        public ActionResult Create()
        {
            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName");
            return View();
        }

        // POST: StockBufers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockId,Yacheika")] StockBufer stockBufer)
        {
            if (ModelState.IsValid)
            {
                db.StockBufer.Add(stockBufer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName", stockBufer.StockId);
            return View(stockBufer);
        }

        // GET: StockBufers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBufer stockBufer = db.StockBufer.Find(id);
            if (stockBufer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName", stockBufer.StockId);
            return View(stockBufer);
        }

        // POST: StockBufers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockId,Yacheika")] StockBufer stockBufer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockBufer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName", stockBufer.StockId);
            return View(stockBufer);
        }

        // GET: StockBufers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockBufer stockBufer = db.StockBufer.Find(id);
            if (stockBufer == null)
            {
                return HttpNotFound();
            }
            return View(stockBufer);
        }

        // POST: StockBufers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockBufer stockBufer = db.StockBufer.Find(id);
            db.StockBufer.Remove(stockBufer);
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
