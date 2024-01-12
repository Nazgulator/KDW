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
    public class YZUserDepartmentsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: YZUserDepartments
        public ActionResult Index()
        {
            var yZUserDepartments = db.YZUserDepartments.Include(y => y.t_Department).Include(y => y.YZUsers);
            return View(yZUserDepartments.ToList());
        }

        // GET: YZUserDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUserDepartments yZUserDepartments = db.YZUserDepartments.Find(id);
            if (yZUserDepartments == null)
            {
                return HttpNotFound();
            }
            return View(yZUserDepartments);
        }

        // GET: YZUserDepartments/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName");
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name");
            return View();
        }

        // POST: YZUserDepartments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,DepartmentId")] YZUserDepartments yZUserDepartments)
        {
            if (ModelState.IsValid)
            {
                db.YZUserDepartments.Add(yZUserDepartments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", yZUserDepartments.DepartmentId);
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name", yZUserDepartments.UserId);
            return View(yZUserDepartments);
        }

        // GET: YZUserDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUserDepartments yZUserDepartments = db.YZUserDepartments.Find(id);
            if (yZUserDepartments == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", yZUserDepartments.DepartmentId);
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name", yZUserDepartments.UserId);
            return View(yZUserDepartments);
        }

        // POST: YZUserDepartments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,DepartmentId")] YZUserDepartments yZUserDepartments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yZUserDepartments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.t_Department, "FItemID", "FName", yZUserDepartments.DepartmentId);
            ViewBag.UserId = new SelectList(db.YZUsers, "Id", "Name", yZUserDepartments.UserId);
            return View(yZUserDepartments);
        }

        // GET: YZUserDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUserDepartments yZUserDepartments = db.YZUserDepartments.Find(id);
            if (yZUserDepartments == null)
            {
                return HttpNotFound();
            }
            return View(yZUserDepartments);
        }

        // POST: YZUserDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YZUserDepartments yZUserDepartments = db.YZUserDepartments.Find(id);
            db.YZUserDepartments.Remove(yZUserDepartments);
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
