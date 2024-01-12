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
    public class WebRolesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: WebRoles
        public ActionResult Index()
        {
            return View(db.WebRoles.ToList());
        }

        // GET: WebRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebRoles webRoles = db.WebRoles.Find(id);
            if (webRoles == null)
            {
                return HttpNotFound();
            }
            return View(webRoles);
        }

        // GET: WebRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebRoles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WebRoles webRoles)
        {
            if (ModelState.IsValid)
            {
                db.WebRoles.Add(webRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webRoles);
        }

        // GET: WebRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebRoles webRoles = db.WebRoles.Find(id);
            if (webRoles == null)
            {
                return HttpNotFound();
            }
            return View(webRoles);
        }

        // POST: WebRoles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WebRoles webRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webRoles);
        }

        // GET: WebRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebRoles webRoles = db.WebRoles.Find(id);
            if (webRoles == null)
            {
                return HttpNotFound();
            }
            return View(webRoles);
        }

        // POST: WebRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebRoles webRoles = db.WebRoles.Find(id);
            db.WebRoles.Remove(webRoles);
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
