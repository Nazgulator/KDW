using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Models;
using MessagingToolkit.QRCode.Codec;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using KDW.Filters;
using System.Runtime;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;



namespace KDW.Controllers
{
    public class PeremeshenieWorksController : Controller
    {
        private KingDeeDB db = new KingDeeDB();
        [Culture]
        // GET: PeremeshenieWorks
        public ActionResult Index()
        {
            var peremeshenieWorks = db.PeremeshenieWorks.Include(p => p.t_Item);
            return View(peremeshenieWorks.ToList());
        }

        // GET: PeremeshenieWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeremeshenieWorks peremeshenieWorks = db.PeremeshenieWorks.Find(id);
            if (peremeshenieWorks == null)
            {
                return HttpNotFound();
            }
            return View(peremeshenieWorks);
        }

        // GET: PeremeshenieWorks/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x=>x.FItemClassID==2), "FItemID", "FName");
            return View();
        }

        // POST: PeremeshenieWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,StockUchastka,BuferZona")] PeremeshenieWorks peremeshenieWorks)
        {
            if (ModelState.IsValid)
            {
                db.PeremeshenieWorks.Add(peremeshenieWorks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName", peremeshenieWorks.DepartmentId);
            return View(peremeshenieWorks);
        }

        // GET: PeremeshenieWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeremeshenieWorks peremeshenieWorks = db.PeremeshenieWorks.Find(id);
            if (peremeshenieWorks == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName", peremeshenieWorks.DepartmentId);
            return View(peremeshenieWorks);
        }

        // POST: PeremeshenieWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentId,StockUchastka,BuferZona")] PeremeshenieWorks peremeshenieWorks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peremeshenieWorks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.t_Item.Where(x => x.FItemClassID == 2), "FItemID", "FName", peremeshenieWorks.DepartmentId);
            return View(peremeshenieWorks);
        }

        // GET: PeremeshenieWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeremeshenieWorks peremeshenieWorks = db.PeremeshenieWorks.Find(id);
            if (peremeshenieWorks == null)
            {
                return HttpNotFound();
            }
            return View(peremeshenieWorks);
        }

        // POST: PeremeshenieWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeremeshenieWorks peremeshenieWorks = db.PeremeshenieWorks.Find(id);
            db.PeremeshenieWorks.Remove(peremeshenieWorks);
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
