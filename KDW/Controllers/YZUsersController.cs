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
    public class YZUsersController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: YZUsers
        public ActionResult Index()
        {
            return View(db.YZUsers.ToList());
        }

        // GET: YZUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUsers yZUsers = db.YZUsers.Find(id);
            if (yZUsers == null)
            {
                return HttpNotFound();
            }
            return View(yZUsers);
        }

        // GET: YZUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YZUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Active")] YZUsers yZUsers)
        {
            if (ModelState.IsValid)
            {
                yZUsers.QRString = "";
                 yZUsers.DateCreate = DateTime.Now;
                db.YZUsers.Add(yZUsers);
                db.SaveChanges();

                yZUsers.QRString = "YZ;USER;" + yZUsers.Id.ToString();
                db.Entry(yZUsers).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(yZUsers);
        }

        // GET: YZUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUsers yZUsers = db.YZUsers.Find(id);
            if (yZUsers == null)
            {
                return HttpNotFound();
            }
            return View(yZUsers);
        }

        // POST: YZUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Active")] YZUsers yZUsers)
        {
            YZUsers User = db.YZUsers.Where(x => x.Id == yZUsers.Id).First();
            User.Name = yZUsers.Name;
            User.Active = yZUsers.Active;

                db.Entry(User).State = EntityState.Modified;
                db.SaveChanges();
                
            return RedirectToAction("Index");

     
        }

        // GET: YZUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YZUsers yZUsers = db.YZUsers.Find(id);
            if (yZUsers == null)
            {
                return HttpNotFound();
            }
            return View(yZUsers);
        }

        // POST: YZUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YZUsers yZUsers = db.YZUsers.Find(id);
            yZUsers.Active = false;
            db.Entry(yZUsers).State = EntityState.Modified;
            //db.YZUsers.Remove(yZUsers);
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
