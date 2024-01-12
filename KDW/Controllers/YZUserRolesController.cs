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
    public class YZUserRolesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: YZUserRoles
        public ActionResult Index()
        {
            var yZUserRoles = db.YZUserRoles.Include(y => y.YZRoles).Include(y => y.YZUsers);
            return View(yZUserRoles.ToList());
        }

        // GET: YZUserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUserRoles yZUserRoles = db.YZUserRoles.Find(id);
            if (yZUserRoles == null)
            {
                return HttpNotFound();
            }
            return View(yZUserRoles);
        }

        // GET: YZUserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name");
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name");
            return View();
        }

        // POST: YZUserRoles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,RoleId")] YZUserRoles yZUserRoles)
        {
            if (ModelState.IsValid)
            {
                db.YZUserRoles.Add(yZUserRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name", yZUserRoles.RoleId);
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name", yZUserRoles.UserId);
            return View(yZUserRoles);
        }

        // GET: YZUserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUserRoles yZUserRoles = db.YZUserRoles.Find(id);
            if (yZUserRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name", yZUserRoles.RoleId);
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name", yZUserRoles.UserId);
            return View(yZUserRoles);
        }

        // POST: YZUserRoles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,RoleId")] YZUserRoles yZUserRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yZUserRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name", yZUserRoles.RoleId);
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name", yZUserRoles.UserId);
            return View(yZUserRoles);
        }

        // GET: YZUserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUserRoles yZUserRoles = db.YZUserRoles.Find(id);
            if (yZUserRoles == null)
            {
                return HttpNotFound();
            }
            return View(yZUserRoles);
        }

        // POST: YZUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YZUserRoles yZUserRoles = db.YZUserRoles.Find(id);
            db.YZUserRoles.Remove(yZUserRoles);
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
