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
    public class MonitorToLinesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: MonitorToLines
        public ActionResult Index()
        {
            var monitorToLine = db.MonitorToLine.Include(m => m.ComputerNames);
            return View(monitorToLine.ToList());
        }

        // GET: MonitorToLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorToLine monitorToLine = db.MonitorToLine.Find(id);
            if (monitorToLine == null)
            {
                return HttpNotFound();
            }
            return View(monitorToLine);
        }

        // GET: MonitorToLines/Create
        public ActionResult Create()
        {
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name");
            return View();
        }

        // POST: MonitorToLines/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MonitorIPAdress,PlanshetId")] MonitorToLine monitorToLine)
        {
            if (ModelState.IsValid)
            {
                db.MonitorToLine.Add(monitorToLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name", monitorToLine.PlanshetId);
            return View(monitorToLine);
        }

        // GET: MonitorToLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorToLine monitorToLine = db.MonitorToLine.Find(id);
            if (monitorToLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name", monitorToLine.PlanshetId);
            return View(monitorToLine);
        }

        // POST: MonitorToLines/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MonitorIPAdress,PlanshetId")] MonitorToLine monitorToLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitorToLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlanshetId = new SelectList(db.ComputerNames, "Id", "Name", monitorToLine.PlanshetId);
            return View(monitorToLine);
        }

        // GET: MonitorToLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorToLine monitorToLine = db.MonitorToLine.Find(id);
            if (monitorToLine == null)
            {
                return HttpNotFound();
            }
            return View(monitorToLine);
        }

        // POST: MonitorToLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonitorToLine monitorToLine = db.MonitorToLine.Find(id);
            db.MonitorToLine.Remove(monitorToLine);
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
