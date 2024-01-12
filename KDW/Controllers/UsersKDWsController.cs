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
    public class UsersKDWsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: UsersKDWs
        public ActionResult Index()
        {
            var usersKDW = db.UsersKDW.Include(u => u.t_Base_User);
            return View(usersKDW.ToList());
        }

        // GET: UsersKDWs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersKDW usersKDW = db.UsersKDW.Find(id);
            if (usersKDW == null)
            {
                return HttpNotFound();
            }
            return View(usersKDW);
        }

        // GET: UsersKDWs/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.t_Base_User, "FUserID", "FName");
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x=>x.FItemClassID==3), "FItemId", "FName");
            return View();
        }

        // POST: UsersKDWs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Password,Name,UserID,MOLID")] UsersKDW usersKDW)
        {
            if (ModelState.IsValid)
            {
                db.UsersKDW.Add(usersKDW);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.t_Base_User, "FUserID", "FName", usersKDW.UserID);
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemId", "FName", usersKDW.MOLId);
            return View(usersKDW);
        }

        // GET: UsersKDWs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersKDW usersKDW = db.UsersKDW.Find(id);
            if (usersKDW == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.t_Base_User, "FUserID", "FName", usersKDW.UserID);
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemId", "FName", usersKDW.MOLId);
            return View(usersKDW);
        }

        // POST: UsersKDWs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Password,Name,UserID,MOLId")] UsersKDW usersKDW)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersKDW).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.t_Base_User, "FUserID", "FName", usersKDW.UserID);
            ViewBag.MOLID = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemId", "FName", usersKDW.MOLId);
            return View(usersKDW);
        }

        // GET: UsersKDWs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersKDW usersKDW = db.UsersKDW.Find(id);
            if (usersKDW == null)
            {
                return HttpNotFound();
            }
            return View(usersKDW);
        }

        // POST: UsersKDWs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersKDW usersKDW = db.UsersKDW.Find(id);
            db.UsersKDW.Remove(usersKDW);
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
