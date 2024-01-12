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
    public class GPScansController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: GPScans
        public ActionResult Index()
        {
            return View(db.GPScans.ToList());
        }

        // GET: GPScans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPScans gPScans = db.GPScans.Find(id);
            if (gPScans == null)
            {
                return HttpNotFound();
            }
            return View(gPScans);
        }

        // GET: GPScans/Create
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult ZakazToSession( string ZakazNumber)
        {
            HttpCookie cookie = Request.Cookies["ZakazNumber"];
            if (cookie != null)
            {
                cookie.Value = ZakazNumber;
            }
            else
            {
                cookie = new HttpCookie("ZakazNumber");
                cookie.HttpOnly = false;
                cookie.Value = ZakazNumber;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Json("Ok");
        }



        public string FindZakazPokupatelya()
        {
            string Zakaz = "";
            HttpCookie cultureCookie = HttpContext.Request.Cookies["ZakazNumber"];
            if (cultureCookie != null)
            {
                Zakaz = cultureCookie.Value;
                // cultureCookie.SameSite = SameSiteMode.Lax;
            }
            return Zakaz;
        }
        public JsonResult ScanGPAdd(string QRString="", string WorkNumber="")
        {
            if (QRString == "" || QRString.Length<6)
            {
                return Json("Error");
            }

            string OldQR = "";
            if (Session["QRScan"] != null)
            {
             OldQR =  (string)Session["QRScan"];
            }
            if (OldQR.Equals(QRString))
            {
                return Json("Double");
            }
            string Zakaz = FindZakazPokupatelya();
            GPScans GPS = new GPScans();
            try
            {
               
                GPS.QRString = QRString;
                GPS.ScanDate = DateTime.Now;
                GPS.ZakazString = Zakaz;
                db.GPScans.Add(GPS);
                db.SaveChanges();



            }
            catch (Exception e)
            {

            }

            try
            {
                wk_iot WK = new wk_iot();
                StarMehWorks SW = db.StarMehWorks.Where(x => x.WorkNumber.Equals(WorkNumber)).OrderByDescending(x => x.Id).First();
                int PlanshetId = SW.PlanshetId;

                    if (PlanshetId == 26)
                    {
                        PlanshetId = 101;
                    }
                    if (PlanshetId == 28)
                    {
                        PlanshetId = 102;
                    }
                    if (PlanshetId == 23)
                    {
                        PlanshetId = 103;
                    }

                WK.name = PlanshetId;
                WK.generated_at = DateTime.Now;
                WK.dop_name = GPS.Id.ToString();
                db.wk_iot.Add(WK);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
            Session["QRScan"] = QRString;

            return Json("Ok");
        }

        public JsonResult RemoveString(int Id)
        {
            GPScans GP = new GPScans();
            try
            {
                GP = db.GPScans.Where(x => x.Id == Id).First();
                db.Entry(GP).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

            try
            {
                string GPS = GP.Id.ToString();
                var ToDel =db.wk_iot.Where(x => x.dop_name.Equals(GPS)).First();
                db.wk_iot.Remove(ToDel);
                db.SaveChanges();
            }
            catch
            {

            }

            return Json("Ok");
        }

            public ActionResult ScanGP(string QRString ="")
        {
          
            ViewBag.QRString = QRString;
            ViewBag.ZakazPokupatelya = FindZakazPokupatelya(); 
            return View();
        }

        public ActionResult ScanGPTable(string QRString = "")
        {
            string Zakaz = FindZakazPokupatelya();
            List<GPScans> GPS = new List<GPScans>();
            try
            {
              GPS = db.GPScans.Where(x => x.ZakazString.Equals(Zakaz)).OrderByDescending(x=>x.QRString).ToList();
            }
            catch
            {

            }
          

            ViewBag.QRString = QRString;
            ViewBag.ZakazPokupatelya = Zakaz;
            return View(GPS);
        }

        // POST: GPScans/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QRString,ScanDate")] GPScans gPScans)
        {
            if (ModelState.IsValid)
            {
                db.GPScans.Add(gPScans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gPScans);
        }

        // GET: GPScans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPScans gPScans = db.GPScans.Find(id);
            if (gPScans == null)
            {
                return HttpNotFound();
            }
            return View(gPScans);
        }

        // POST: GPScans/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QRString,ScanDate")] GPScans gPScans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPScans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gPScans);
        }

        // GET: GPScans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPScans gPScans = db.GPScans.Find(id);
            if (gPScans == null)
            {
                return HttpNotFound();
            }
            return View(gPScans);
        }

        // POST: GPScans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPScans gPScans = db.GPScans.Find(id);
            db.GPScans.Remove(gPScans);
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
