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
    public class StockPriemsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: StockPriems
        public ActionResult Index()
        {
            var stockPriem = db.StockPriem.Include(s => s.Stock).Include(x=>x.Stock.StockMol);
            return View(stockPriem.ToList());
        }

        // GET: StockPriems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPriem stockPriem = db.StockPriem.Find(id);
            if (stockPriem == null)
            {
                return HttpNotFound();
            }
            return View(stockPriem);
        }

        // GET: StockPriems/Create
        public ActionResult Create()
        {
           // var StockId = db.StocksMOL.ToList();//db.t_Item.Where(x => x.FItemClassID == 5).Include(x => x.StockMol).Select(x=>x.StockMol.;
            
            ViewBag.StockId = new SelectList(db.StocksMOL, "FInterID", "RU");
            return View();
        }

        // POST: StockPriems/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockId,Yacheika")] StockPriem stockPriem)
        {
            if (ModelState.IsValid)
            {
                db.StockPriem.Add(stockPriem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockId = new SelectList(db.StocksMOL, "FInterID", "RU", stockPriem.StockId);
            return View(stockPriem);
        }

        // GET: StockPriems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPriem stockPriem = db.StockPriem.Find(id);
            if (stockPriem == null)
            {
                return HttpNotFound();
            }
         
            ViewBag.StockId = new SelectList(db.StocksMOL, "FInterID", "RU", stockPriem.StockId);
            return View(stockPriem);
        }

        // POST: StockPriems/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockId,Yacheika")] StockPriem stockPriem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockPriem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockId = new SelectList(db.t_Item, "FItemID", "FNumber", stockPriem.StockId);
            return View(stockPriem);
        }

        // GET: StockPriems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPriem stockPriem = db.StockPriem.Find(id);
            if (stockPriem == null)
            {
                return HttpNotFound();
            }
            return View(stockPriem);
        }

        // POST: StockPriems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockPriem stockPriem = db.StockPriem.Find(id);
            db.StockPriem.Remove(stockPriem);
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
