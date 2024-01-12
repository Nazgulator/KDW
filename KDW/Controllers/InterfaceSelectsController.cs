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
    public class InterfaceSelectsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: InterfaceSelects
        public ActionResult Index()
        {
            return View(db.InterfaceSelect.ToList());
        }

        public Dictionary<string, string> FindStocks(int SkladPriemki = 1, int SkladBraka = 1, int SkladUchastka = 1, int SkladBrakaUchastka = 1, int SkladVosvrataNZP = 1, int SkladBuferZone = 1, int SkladPereemesheniyaBuferZone = 1)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            List<StocksSelect> SS = new List<StocksSelect>();
            List<int> Stocks = new List<int>();
            List<int> RemoveStocks = new List<int>();
            try
            {
                SS = db.StocksSelect.ToList();
            }
            catch
            {

            }

            if (SkladPriemki > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladPriemki && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }

            if (SkladBraka > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladBraka && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }

            if (SkladUchastka > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladUchastka && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }

            if (SkladBrakaUchastka > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladBrakaUchastka && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }


            if (SkladVosvrataNZP > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladVozvrataNZP && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }

            if (SkladBuferZone > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladBuferZone && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }


            if (SkladPereemesheniyaBuferZone > 0)
            {
                try
                {
                    Stocks.AddRange(SS.Where(x => x.SkladPeremesheniyaBuferZone && x.Active).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }



            //Вычитаем склады

            if (SkladPriemki < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladPriemki).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }

            if (SkladBraka < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladBraka).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }
            if (SkladUchastka < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladUchastka).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }
            if (SkladBrakaUchastka < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladBrakaUchastka).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }
            if (SkladVosvrataNZP < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladVozvrataNZP).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }
            if (SkladBuferZone < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladBuferZone).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }
            if (SkladPereemesheniyaBuferZone < 0)
            {
                try
                {
                    RemoveStocks.AddRange(SS.Where(x => x.SkladPeremesheniyaBuferZone).Select(x => x.StockId).ToList());
                }
                catch
                {

                }
            }

            if (Stocks.Count > 0)
            {
                Stocks.Distinct();
            }
            if (RemoveStocks.Count > 0)
            {
                RemoveStocks.Distinct();
                if (Stocks.Count > 0)
                {

                    Stocks = Stocks.Where(x => RemoveStocks.Contains(x) == false).ToList();
                }


            }

            try
            {
                if (CultureRU() == false)
                {
                    Dic = db.StocksSelect.Where(x => Stocks.Contains(x.StockId)).ToDictionary(x => x.StockId.ToString(), y => y.StockNameZH);
                }
                else
                {
                    Dic = db.StocksSelect.Where(x => Stocks.Contains(x.StockId)).ToDictionary(x => x.StockId.ToString(), y => y.StockNameRU);
                }
            }
            catch
            {

            }

            return Dic;
        }

        public bool CultureRU()
        {
            string Culture = "zh";

            HttpCookie cultureCookie = HttpContext.Request.Cookies["lang"];
            if (cultureCookie != null)
            {
                Culture = cultureCookie.Value;
                // cultureCookie.SameSite = SameSiteMode.Lax;
            }


            bool Result = false;
            if (Culture.Contains("ru"))
            {
                Result = true;
            }
            return Result;
        }
        public Dictionary<string, string> FindStocksByInterface(string Interface = "")
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            try
            {
                var SI = db.InterfaceSelect.Where(x => x.InterfaceName.Equals(Interface)).Distinct().First(); //.Select(x=> new { StockId = x.Id })


             //   Dic = FindStocks(SI.SkladPriemki, SI.SkladBraka, SI.SkladUchastka, SI.SkladBrakaUchastka, SI.SkladVozvrataNZP, SI.SkladBuferZone, SI.SkladPeremesheniyaBuferZone);
            }
            catch
            {

            }

            return Dic;
        }

        public List<string> StocksFromDepartment(int DepartmentId=0)
        {
            List<string> Dic = new List<string>();
            if (DepartmentId > 0)
            {
                try
                {
                    db.DepartmentToStocks.Where(x => x.DepartmentId == DepartmentId).Select(x => x.StockId.ToString()).Distinct().ToList();
                }
                catch
                {

                }
            }

            return Dic;
        }

        public ActionResult InterfaceTest(int DepartmentId = 0, string Interface = "")
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            List<InterfaceSelect> I = new List<InterfaceSelect>();
           
            if (Interface.Equals("") == false)
            {
                try
                {
                    Dic = FindStocksByInterface(Interface);
                 //.Select(x=> new { StockId = x.Id })

                }
                catch
                {

                }
            }
            if (DepartmentId != 0)
            {
                try
                {
                 var Depts=   StocksFromDepartment(DepartmentId);
                    Dic = Dic.Where(x => Depts.Contains(x.Key) ==true).ToDictionary(x=>x.Key, y=>y.Value);
                }
                catch
                {

                }
            }

            try
            {
                I = db.InterfaceSelect.Distinct().ToList();
            }
            catch
            {

            }


            List<string> Interfaces = new List<string>();
            Interfaces.Add(Interface);
            Interfaces.AddRange(I.Select(x=>x.InterfaceName).ToList());
            ViewBag.Interfaces = Interfaces;
            ViewBag.Stocks = Dic;
            ViewBag.CurrentInterface = Interface;//Interfaces.Where(x=>x.Equals(Interface)).First();
           
            // var Departments = db.t_Department.ToDictionary(x => x.FItemID, y => y.FName);
            var Ds = db.t_Department.ToDictionary(x => x.FItemID, y => y.FName);
            Ds.Add(0, "-");
            var CurrentDepartment = Ds.Where(x => x.Key == DepartmentId).Select(x => x.Value).First();
            Dictionary<int, string> Departments = new Dictionary<int, string>();
            Ds.Remove(DepartmentId);
            Departments.Add(DepartmentId,CurrentDepartment);
            foreach (var d in Ds)
            {
                Departments.Add(d.Key,d.Value);
            }


            ViewBag.CurrentDepartment = CurrentDepartment;
            ViewBag.Departments = Departments;

            return View(db.InterfaceSelect.ToList());
        }
        // GET: InterfaceSelects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterfaceSelect interfaceSelect = db.InterfaceSelect.Find(id);
            if (interfaceSelect == null)
            {
                return HttpNotFound();
            }
            return View(interfaceSelect);
        }

        // GET: InterfaceSelects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterfaceSelects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InterfaceName,Active,SkladPriemki,SkladBraka,SkladUchastka,SkladBrakaUchastka,SkladVozvrataNZP,SkladBuferZone,SkladPeremesheniyaBuferZone")] InterfaceSelect interfaceSelect)
        {
            if (ModelState.IsValid)
            {
                db.InterfaceSelect.Add(interfaceSelect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interfaceSelect);
        }

        // GET: InterfaceSelects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterfaceSelect interfaceSelect = db.InterfaceSelect.Find(id);
            if (interfaceSelect == null)
            {
                return HttpNotFound();
            }
            return View(interfaceSelect);
        }

        // POST: InterfaceSelects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InterfaceName,Active,SkladPriemki,SkladBraka,SkladUchastka,SkladBrakaUchastka,SkladVozvrataNZP,SkladBuferZone,SkladPeremesheniyaBuferZone")] InterfaceSelect interfaceSelect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interfaceSelect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interfaceSelect);
        }

        // GET: InterfaceSelects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterfaceSelect interfaceSelect = db.InterfaceSelect.Find(id);
            if (interfaceSelect == null)
            {
                return HttpNotFound();
            }
            return View(interfaceSelect);
        }

        // POST: InterfaceSelects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterfaceSelect interfaceSelect = db.InterfaceSelect.Find(id);
            db.InterfaceSelect.Remove(interfaceSelect);
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
