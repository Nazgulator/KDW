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
    public class DepartmentsToUsersController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: DepartmentsToUsers
        public ActionResult Index()
        {
            var departmentsToUsers = db.DepartmentsToUsers.Include(d => d.Department).Include(d => d.UsersKDW).Include(x=>x.UsersKDW.t_Base_User);
            return View(departmentsToUsers.ToList());
        }

        // GET: DepartmentsToUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentsToUsers departmentsToUsers = db.DepartmentsToUsers.Find(id);
            if (departmentsToUsers == null)
            {
                return HttpNotFound();
            }
            return View(departmentsToUsers);
        }

        // GET: DepartmentsToUsers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x=>x.FItemClassID == 2), "FItemID", "FName");
            ViewBag.UserId = new SelectList(db.UsersKDW, "Id", "Name");
            return View();
        }

        // POST: DepartmentsToUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,UserId")] DepartmentsToUsers departmentsToUsers)
        {
            if (ModelState.IsValid)
            {
                departmentsToUsers.DateNaznacheniya = DateTime.Now;
                db.DepartmentsToUsers.Add(departmentsToUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.t_Item, "FItemID", "FNumber", departmentsToUsers.DepartmentId);
            ViewBag.UserId = new SelectList(db.t_Item, "FItemID", "FNumber", departmentsToUsers.UserId);
            return View(departmentsToUsers);
        }

        // GET: DepartmentsToUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentsToUsers departmentsToUsers = db.DepartmentsToUsers.Find(id);
            if (departmentsToUsers == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.t_Item, "FItemID", "FNumber", departmentsToUsers.DepartmentId);
            ViewBag.UserId = new SelectList(db.t_Item, "FItemID", "FNumber", departmentsToUsers.UserId);
            return View(departmentsToUsers);
        }

        // POST: DepartmentsToUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentId,UserId,DateNaznacheniya")] DepartmentsToUsers departmentsToUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentsToUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.t_Item, "FItemID", "FNumber", departmentsToUsers.DepartmentId);
            ViewBag.UserId = new SelectList(db.t_Item, "FItemID", "FNumber", departmentsToUsers.UserId);
            return View(departmentsToUsers);
        }

        // GET: DepartmentsToUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentsToUsers departmentsToUsers = db.DepartmentsToUsers.Find(id);
            if (departmentsToUsers == null)
            {
                return HttpNotFound();
            }
            return View(departmentsToUsers);
        }

        // POST: DepartmentsToUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentsToUsers departmentsToUsers = db.DepartmentsToUsers.Find(id);
            db.DepartmentsToUsers.Remove(departmentsToUsers);
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
