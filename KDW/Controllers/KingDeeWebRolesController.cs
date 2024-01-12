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
    public class KingDeeWebRolesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: KingDeeWebRoles
        public ActionResult Index()
        {
            var kingDeeWebRoles = db.KingDeeWebRoles.Include(k => k.WebRoles).Include(k => k.UsersKDW);
            return View(kingDeeWebRoles.ToList());
        }

        // GET: KingDeeWebRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KingDeeWebRoles kingDeeWebRoles = db.KingDeeWebRoles.Find(id);
            if (kingDeeWebRoles == null)
            {
                return HttpNotFound();
            }
            return View(kingDeeWebRoles);
        }

        // GET: KingDeeWebRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.WebRoles, "Id", "Name");
            //  ViewBag.UserId = new SelectList(db.t_Item.Where(x=>x.FItemClassID==3), "FItemID", "FName");
            ViewBag.UserId = new SelectList(db.UsersKDW, "Id", "Name");
            return View();
        }

        // POST: KingDeeWebRoles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleId,UserId")] KingDeeWebRoles kingDeeWebRoles)
        {
            if (ModelState.IsValid)
            {
                kingDeeWebRoles.DateNaznacheniya = DateTime.Now;
                db.KingDeeWebRoles.Add(kingDeeWebRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.WebRoles, "Id", "Id", kingDeeWebRoles.RoleId);
            ViewBag.UserId = new SelectList(db.t_Item, "FItemID", "FNumber", kingDeeWebRoles.UserId);
            return View(kingDeeWebRoles);
        }

        // GET: KingDeeWebRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KingDeeWebRoles kingDeeWebRoles = db.KingDeeWebRoles.Find(id);
            if (kingDeeWebRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.WebRoles, "Id", "Id", kingDeeWebRoles.RoleId);
            ViewBag.UserId = new SelectList(db.t_Item, "FItemID", "FNumber", kingDeeWebRoles.UserId);
            return View(kingDeeWebRoles);
        }

        // POST: KingDeeWebRoles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,UserId,DateNaznacheniya")] KingDeeWebRoles kingDeeWebRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kingDeeWebRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.WebRoles, "Id", "Id", kingDeeWebRoles.RoleId);
            ViewBag.UserId = new SelectList(db.t_Item, "FItemID", "FNumber", kingDeeWebRoles.UserId);
            return View(kingDeeWebRoles);
        }

        // GET: KingDeeWebRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KingDeeWebRoles kingDeeWebRoles = db.KingDeeWebRoles.Find(id);
            if (kingDeeWebRoles == null)
            {
                return HttpNotFound();
            }
            return View(kingDeeWebRoles);
        }

        // POST: KingDeeWebRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KingDeeWebRoles kingDeeWebRoles = db.KingDeeWebRoles.Find(id);
            db.KingDeeWebRoles.Remove(kingDeeWebRoles);
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
