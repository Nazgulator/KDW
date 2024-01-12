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
    public class StocksSelectsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: StocksSelects
        public ActionResult Index()
        {
            var stocksSelect = db.StocksSelect.Include(s => s.t_Stock);
            return View(stocksSelect.ToList());
        }

        // GET: StocksSelects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StocksSelect stocksSelect = db.StocksSelect.Find(id);
            if (stocksSelect == null)
            {
                return HttpNotFound();
            }
            return View(stocksSelect);
        }

        // GET: StocksSelects/Create
        public ActionResult Create()
        {
            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName");
            return View();
        }

        // POST: StocksSelects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockId,StockNameZH,StockNameRU,Active,SkladPriemki,SkladBraka,SkladUchastka,SkladBrakaUchastka,SkladVozvrataNZP,SkladBuferZone,SkladPeremesheniyaBuferZone")] StocksSelect stocksSelect)
        {
            if (ModelState.IsValid)
            {
                db.StocksSelect.Add(stocksSelect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName", stocksSelect.StockId);
            return View(stocksSelect);
        }

        // GET: StocksSelects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StocksSelect stocksSelect = db.StocksSelect.Find(id);
            if (stocksSelect == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName", stocksSelect.StockId);
            return View(stocksSelect);
        }

        // POST: StocksSelects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockId,StockNameZH,StockNameRU,Active,SkladPriemki,SkladBraka,SkladUchastka,SkladBrakaUchastka,SkladVozvrataNZP,SkladBuferZone,SkladPeremesheniyaBuferZone")] StocksSelect stocksSelect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stocksSelect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockId = new SelectList(db.t_Stock, "FItemID", "FName", stocksSelect.StockId);
            return View(stocksSelect);
        }

        // GET: StocksSelects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StocksSelect stocksSelect = db.StocksSelect.Find(id);
            if (stocksSelect == null)
            {
                return HttpNotFound();
            }
            return View(stocksSelect);
        }

        // POST: StocksSelects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StocksSelect stocksSelect = db.StocksSelect.Find(id);
            db.StocksSelect.Remove(stocksSelect);
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
