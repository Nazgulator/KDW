using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Filters;
using KDW.Models;

namespace KDW.Controllers
{
    [Culture]
    public class POOrdersController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: POOrders
       
        public ActionResult Index()
        {

            DateTime Date = DateTime.Now.AddMonths(-6);
            var Items = db.POOrderEntry.Where(x=>x.FDate>=Date).OrderByDescending(x=>x.FDate).Take(10).Include(x => x.t_Item).Include(x=>x.POOrder.t_Supplier).ToList().First();
        //    foreach (var I in Items)
      //      {
       //         foreach (var E in I.POOrderEntry)
       //         {
       //            E.POOrder = db.POOrderEntry.Where(x => x.FInterID == E.FInterID).Include(x => x.POOrder);
        //        }
         //   }
           var Zakazi = db.POOrder.Where(x => x.FDate >= Date).Include(x => x.t_Supplier).Include(x=>x.POOrderEntry).ToList();
            return View(Zakazi);
        }

       

        // GET: POOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POOrder pOOrder = db.POOrder.Find(id);
            if (pOOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOOrder);
        }

        // GET: POOrders/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "zh" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
        // POST: POOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FBrNo,FTranType,FInterID,FBillNo,FSupplyID,FDate,FEmpID,FDeptID,FCurrencyID,FCheckerID,FBillerID,FMangerID,FClosed,FTranStatus,FExchangeRate,FStatus,FCancellation,FPOStyle,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FRelateBrID,FOrderAffirm,FCashDiscount,FCheckDate,FExplanation,FFetchAdd,FSettleDate,FSettleID,FSelTranType,FChildren,FBrID,FPOOrdBillNo,FAreaPS,FClassTypeID,FTotalCostFor,FlastModyDate,FOperDate,FManageType,FSysStatus,FVersionNo,FChangeDate,FChangeCauses,FChangeMark,FChangeUser,FValidaterName,FConsignee,FPrintCount,FExchangeRateType,FDeliveryPlace,FAccessoryCount,FPOMode,FPlanCategory,FLastAlterBillNo,FHeadSelfP0252,FMultiCheckStatus,FHeadSelfP0253,FCloseUser,FCloseDate,FCloseCauses,FSendStatus,FEnterpriseID")] POOrder pOOrder)
        {
            if (ModelState.IsValid)
            {
                db.POOrder.Add(pOOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pOOrder);
        }

        // GET: POOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POOrder pOOrder = db.POOrder.Find(id);
            if (pOOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOOrder);
        }

        // POST: POOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FBrNo,FTranType,FInterID,FBillNo,FSupplyID,FDate,FEmpID,FDeptID,FCurrencyID,FCheckerID,FBillerID,FMangerID,FClosed,FTranStatus,FExchangeRate,FStatus,FCancellation,FPOStyle,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FRelateBrID,FOrderAffirm,FCashDiscount,FCheckDate,FExplanation,FFetchAdd,FSettleDate,FSettleID,FSelTranType,FChildren,FBrID,FPOOrdBillNo,FAreaPS,FClassTypeID,FTotalCostFor,FlastModyDate,FOperDate,FManageType,FSysStatus,FVersionNo,FChangeDate,FChangeCauses,FChangeMark,FChangeUser,FValidaterName,FConsignee,FPrintCount,FExchangeRateType,FDeliveryPlace,FAccessoryCount,FPOMode,FPlanCategory,FLastAlterBillNo,FHeadSelfP0252,FMultiCheckStatus,FHeadSelfP0253,FCloseUser,FCloseDate,FCloseCauses,FSendStatus,FEnterpriseID")] POOrder pOOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOOrder);
        }

        // GET: POOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POOrder pOOrder = db.POOrder.Find(id);
            if (pOOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOOrder);
        }

        // POST: POOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POOrder pOOrder = db.POOrder.Find(id);
            db.POOrder.Remove(pOOrder);
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
