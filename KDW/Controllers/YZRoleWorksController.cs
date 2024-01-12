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
    public class YZRoleWorksController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: YZRoleWorks
        public ActionResult Index()
        {
            var yZRoleWorks = db.YZRoleWorks.Include(y => y.YZRoles).Include(y => y.YZWorks).Include(x=>x.YZWorks.t_Department).Include(x=>x.YZRoles.YZUserRoles);

       /*     foreach (var w in yZRoleWorks)
            {
                foreach( var ww in w.YZRoles.YZUserRoles)
                {
                    ww.YZUsers = db.
                }
            }
       */
            return View(yZRoleWorks.ToList());
        }

        // GET: YZRoleWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZRoleWorks yZRoleWorks = db.YZRoleWorks.Find(id);
            if (yZRoleWorks == null)
            {
                return HttpNotFound();
            }
            return View(yZRoleWorks);
        }

        // GET: YZRoleWorks/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name");
            ViewBag.WorkId = new SelectList(db.YZWorks, "Id", "Name");
            return View();
        }

        // POST: YZRoleWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,WorkId")] YZRoleWorks yZRoleWorks)
        {
            if (ModelState.IsValid)
            {
                db.YZRoleWorks.Add(yZRoleWorks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name", yZRoleWorks.RoleId);
            ViewBag.WorkId = new SelectList(db.YZWorks, "Id", "Name", yZRoleWorks.WorkId);
            return View(yZRoleWorks);
        }

        // GET: YZRoleWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZRoleWorks yZRoleWorks = db.YZRoleWorks.Find(id);
            if (yZRoleWorks == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name", yZRoleWorks.RoleId);
            ViewBag.WorkId = new SelectList(db.YZWorks, "Id", "Name", yZRoleWorks.WorkId);
            return View(yZRoleWorks);
        }

        // POST: YZRoleWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,WorkId")] YZRoleWorks yZRoleWorks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yZRoleWorks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.YZRoles, "Id", "Name", yZRoleWorks.RoleId);
            ViewBag.WorkId = new SelectList(db.YZWorks, "Id", "Name", yZRoleWorks.WorkId);
            return View(yZRoleWorks);
        }

        // GET: YZRoleWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZRoleWorks yZRoleWorks = db.YZRoleWorks.Find(id);
            if (yZRoleWorks == null)
            {
                return HttpNotFound();
            }
            return View(yZRoleWorks);
        }

        // POST: YZRoleWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YZRoleWorks yZRoleWorks = db.YZRoleWorks.Find(id);
            db.YZRoleWorks.Remove(yZRoleWorks);
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
