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
    public class StocksMOLsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: StocksMOLs
        public ActionResult Index()
        {
            var stocksMOL = db.StocksMOL.Include(s => s.t_Stock).Include(s => s.t_Item).Include(s => s.t_Item1);
            return View(stocksMOL.ToList());
        }

        // GET: StocksMOLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StocksMOL stocksMOL = db.StocksMOL.Find(id);
            if (stocksMOL == null)
            {
                return HttpNotFound();
            }
            return View(stocksMOL);
        }

        // GET: StocksMOLs/Create
        public ActionResult Create()
        {
            ViewBag.FInterID = new SelectList(db.t_Stock, "FItemID", "FName");
            ViewBag.FInterID = new SelectList(db.t_Item.Where(x=>x.FItemClassID==5), "FItemID", "FName");
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName");
            return View();
        }

        // POST: StocksMOLs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RU,ZH,Id,FInterID,MOLID, Actual, YacheikaPriem, YacheikaBufer, SkladUchastka, SkladBraka")] StocksMOL stocksMOL)
        {
            stocksMOL.CEH = 1;
            stocksMOL.FNumber = "01";
            stocksMOL.MOL = "NoName";
            if (ModelState.IsValid)
            {
                db.StocksMOL.Add(stocksMOL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(stocksMOL);
        }

        // GET: StocksMOLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StocksMOL stocksMOL = db.StocksMOL.Find(id);
            if (stocksMOL == null)
            {
                return HttpNotFound();
            }
            ViewBag.FInterID = new SelectList(db.t_Stock, "FItemID", "FName", stocksMOL.FInterID);
            ViewBag.FInterID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 5), "FItemID", "FName", stocksMOL.FInterID);
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName", stocksMOL.MOLID);
            return View(stocksMOL);
        }

        // POST: StocksMOLs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CEH,RU,ZH,MOL,Id,FInterID,MOLID,FNumber, Actual, YacheikaPriem, YacheikaBufer, SkladUchastka, SkladBraka")] StocksMOL stocksMOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stocksMOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FInterID = new SelectList(db.t_Stock, "FItemID", "FName", stocksMOL.FInterID);
            ViewBag.FInterID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 5), "FItemID", "FName", stocksMOL.FInterID);
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName", stocksMOL.MOLID);
            return View(stocksMOL);
        }

        // GET: StocksMOLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StocksMOL stocksMOL = db.StocksMOL.Find(id);
            if (stocksMOL == null)
            {
                return HttpNotFound();
            }
            return View(stocksMOL);
        }

        // POST: StocksMOLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StocksMOL stocksMOL = db.StocksMOL.Find(id);
            db.StocksMOL.Remove(stocksMOL);
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
