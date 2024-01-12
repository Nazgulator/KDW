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
    public class YZRolesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: YZRoles
        public ActionResult Index()
        {
            return View(db.YZRoles.ToList());
        }

        // GET: YZRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZRoles yZRoles = db.YZRoles.Find(id);
            if (yZRoles == null)
            {
                return HttpNotFound();
            }
            return View(yZRoles);
        }

        // GET: YZRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YZRoles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] YZRoles yZRoles)
        {
            if (ModelState.IsValid)
            {
                db.YZRoles.Add(yZRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yZRoles);
        }

        // GET: YZRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZRoles yZRoles = db.YZRoles.Find(id);
            if (yZRoles == null)
            {
                return HttpNotFound();
            }
            return View(yZRoles);
        }

        // POST: YZRoles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] YZRoles yZRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yZRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yZRoles);
        }

        // GET: YZRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZRoles yZRoles = db.YZRoles.Find(id);
            if (yZRoles == null)
            {
                return HttpNotFound();
            }
            return View(yZRoles);
        }

        // POST: YZRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YZRoles yZRoles = db.YZRoles.Find(id);
            db.YZRoles.Remove(yZRoles);
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
