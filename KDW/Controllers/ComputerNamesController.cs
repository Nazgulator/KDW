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
    public class ComputerNamesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: ComputerNames
        public ActionResult Index()
        {
            var computerNames = db.ComputerNames.Include(c => c.t_Department);
            return View(computerNames.ToList());
        }

        // GET: ComputerNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerNames computerNames = db.ComputerNames.Find(id);
            if (computerNames == null)
            {
                return HttpNotFound();
            }
            return View(computerNames);
        }

        // GET: ComputerNames/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName");
            return View();
        }

        // POST: ComputerNames/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ComputerId,DepartmentId")] ComputerNames computerNames)
        {
            if (ModelState.IsValid)
            {
                db.ComputerNames.Add(computerNames);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FBrNO", computerNames.DepartmentId);
            return View(computerNames);
        }

        // GET: ComputerNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerNames computerNames = db.ComputerNames.Find(id);
            if (computerNames == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", computerNames.DepartmentId);
            return View(computerNames);
        }

        // POST: ComputerNames/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ComputerId,DepartmentId")] ComputerNames computerNames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computerNames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", computerNames.DepartmentId);
            return View(computerNames);
        }

        // GET: ComputerNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerNames computerNames = db.ComputerNames.Find(id);
            if (computerNames == null)
            {
                return HttpNotFound();
            }
            return View(computerNames);
        }

        // POST: ComputerNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComputerNames computerNames = db.ComputerNames.Find(id);
            db.ComputerNames.Remove(computerNames);
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
