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
    public class YZWorksController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: YZWorks
        public ActionResult Index()
        {
            var yZWorks = db.YZWorks.Where(x=>x.Deleted==false).Include(y => y.t_Department);
            return View(yZWorks.ToList());
        }

        // GET: YZWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZWorks yZWorks = db.YZWorks.Find(id);
            if (yZWorks == null)
            {
                return HttpNotFound();
            }
            return View(yZWorks);
        }

        // GET: YZWorks/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName");
            return View();
        }

        // POST: YZWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DepartmentId,Deleted")] YZWorks yZWorks)
        {
            if (ModelState.IsValid)
            {
                db.YZWorks.Add(yZWorks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", yZWorks.DepartmentId);
            return View(yZWorks);
        }

        // GET: YZWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZWorks yZWorks = db.YZWorks.Find(id);
            if (yZWorks == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", yZWorks.DepartmentId);
            return View(yZWorks);
        }

        // POST: YZWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DepartmentId,Deleted")] YZWorks yZWorks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yZWorks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", yZWorks.DepartmentId);
            return View(yZWorks);
        }

        // GET: YZWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZWorks yZWorks = db.YZWorks.Find(id);
            if (yZWorks == null)
            {
                return HttpNotFound();
            }
            return View(yZWorks);
        }

        // POST: YZWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YZWorks yZWorks = db.YZWorks.Find(id);
            yZWorks.Deleted = true;
            db.Entry(yZWorks).State = EntityState.Modified;
            // db.YZWorks.Remove(yZWorks);
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
