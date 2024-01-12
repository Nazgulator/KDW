using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Filters;
using KDW.Models;

namespace KDW.Controllers
{
    public class DepartmentToStocksController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: DepartmentToStocks
        [Culture]
        public ActionResult Index()
        {
            var departmentToStocks = db.DepartmentToStocks.Include(d => d.Department).Include(d => d.Stock).Include(d => d.MOL).Include(d => d.ComputerNames);
            return View(departmentToStocks.ToList());
        }

        // GET: DepartmentToStocks/Details/5
        [Culture]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentToStocks departmentToStocks = db.DepartmentToStocks.Find(id);
            if (departmentToStocks == null)
            {
                return HttpNotFound();
            }
            return View(departmentToStocks);
        }

        // GET: DepartmentToStocks/Create
        [Culture]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName");
            ViewBag.StockId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 5), "FItemID", "FName");
            ViewBag.MolId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName");
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name");
            return View();
        }

        // POST: DepartmentToStocks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Culture]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,PlanshetId,StockId,MolId, Main")] DepartmentToStocks departmentToStocks)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentToStocks.Add(departmentToStocks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName", departmentToStocks.DepartmentId);
            ViewBag.StockId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 5), "FItemID", "FName", departmentToStocks.StockId);
            ViewBag.MolId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName", departmentToStocks.MolId);
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name", departmentToStocks.PlanshetId);
            return View(departmentToStocks);
        }

        // GET: DepartmentToStocks/Edit/5
        [Culture]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentToStocks departmentToStocks = db.DepartmentToStocks.Find(id);
            if (departmentToStocks == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName", departmentToStocks.DepartmentId);
            ViewBag.StockId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 5), "FItemID", "FName", departmentToStocks.StockId);
            ViewBag.MolId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName", departmentToStocks.MolId);
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name", departmentToStocks.PlanshetId);
            return View(departmentToStocks);
        }

        // POST: DepartmentToStocks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Culture]
        public ActionResult Edit([Bind(Include = "Id,DepartmentId,PlanshetId,StockId,MolId, Main")] DepartmentToStocks departmentToStocks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentToStocks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName", departmentToStocks.DepartmentId);
            ViewBag.StockId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 5), "FItemID", "FName", departmentToStocks.StockId);
            ViewBag.MolId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName", departmentToStocks.MolId);
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name", departmentToStocks.PlanshetId);
            return View(departmentToStocks);
        }

        // GET: DepartmentToStocks/Delete/5
        [Culture]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentToStocks departmentToStocks = db.DepartmentToStocks.Find(id);
            if (departmentToStocks == null)
            {
                return HttpNotFound();
            }
            return View(departmentToStocks);
        }

        // POST: DepartmentToStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Culture]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentToStocks departmentToStocks = db.DepartmentToStocks.Find(id);
            db.DepartmentToStocks.Remove(departmentToStocks);
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
