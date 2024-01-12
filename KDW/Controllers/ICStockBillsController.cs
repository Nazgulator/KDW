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
    public class ICStockBillsController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: ICStockBills
        public ActionResult Index()
        {
            return View(db.ICStockBill.OrderByDescending(x=>x.FInterID).Take(100).ToList());
        }

        // GET: ICStockBills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICStockBill iCStockBill = db.ICStockBill.Find(id);
            if (iCStockBill == null)
            {
                return HttpNotFound();
            }
            return View(iCStockBill);
        }

        // GET: ICStockBills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ICStockBills/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FBrNo,FInterID,FTranType,FDate,FBillNo,FUse,FNote,FDCStockID,FSCStockID,FDeptID,FEmpID,FSupplyID,FPosterID,FCheckerID,FFManagerID,FSManagerID,FBillerID,FReturnBillInterID,FSCBillNo,FHookInterID,FVchInterID,FPosted,FCheckSelect,FCurrencyID,FSaleStyle,FAcctID,FROB,FRSCBillNo,FStatus,FUpStockWhenSave,FCancellation,FOrgBillInterID,FBillTypeID,FPOStyle,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FTaskID,FResourceID,FBackFlushed,FWBInterID,FTranStatus,FZPBillInterID,FRelateBrID,FPurposeID,FUUID,FRelateInvoiceID,FOperDate,FImport,FSystemType,FMarketingStyle,FPayBillID,FCheckDate,FExplanation,FFetchAdd,FFetchDate,FManagerID,FRefType,FSelTranType,FChildren,FHookStatus,FActPriceVchTplID,FPlanPriceVchTplID,FProcID,FActualVchTplID,FPlanVchTplID,FBrID,FVIPCardID,FVIPScore,FHolisticDiscountRate,FPOSName,FWorkShiftId,FCussentAcctID,FZanGuCount,FPOOrdBillNo,FLSSrcInterID,FSettleDate,FManageType,FOrderAffirm,FAutoCreType,FConsignee,FDrpRelateTranType,FPrintCount,FPOMode,FInventoryType,FObjectItem,FConfirmStatus,FConfirmMem,FConfirmDate,FConfirmer,FAutoCreatePeriod,FYearPeriod,FPayCondition,FsourceType,FReceiver,FHeadSelfB0154,FHeadSelfA0143,FHeadSelfB0435,FHeadSelfA0537,FHeadSelfB0836,FHeadSelfA9738,FHeadSelfB0939,FHeadSelfD0134,FHeadSelfC0131,FHeadSelfC0231,FHeadSelfA0230,FHeadSelfB0837,FHeadSelfB0436,FInvoiceStatus,FSendStatus,FEnterpriseID,FBillReviewer,FBillReviewDate,FCod,FReceiveMan,FConsigneeAdd,FISUpLoad,FReceiverMobile,FAccessoryCount,FHeadSelfA0233")] ICStockBill iCStockBill)
        {
            if (ModelState.IsValid)
            {
                db.ICStockBill.Add(iCStockBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iCStockBill);
        }

        // GET: ICStockBills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICStockBill iCStockBill = db.ICStockBill.Find(id);
            if (iCStockBill == null)
            {
                return HttpNotFound();
            }
            return View(iCStockBill);
        }

        // POST: ICStockBills/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FBrNo,FInterID,FTranType,FDate,FBillNo,FUse,FNote,FDCStockID,FSCStockID,FDeptID,FEmpID,FSupplyID,FPosterID,FCheckerID,FFManagerID,FSManagerID,FBillerID,FReturnBillInterID,FSCBillNo,FHookInterID,FVchInterID,FPosted,FCheckSelect,FCurrencyID,FSaleStyle,FAcctID,FROB,FRSCBillNo,FStatus,FUpStockWhenSave,FCancellation,FOrgBillInterID,FBillTypeID,FPOStyle,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FTaskID,FResourceID,FBackFlushed,FWBInterID,FTranStatus,FZPBillInterID,FRelateBrID,FPurposeID,FUUID,FRelateInvoiceID,FOperDate,FImport,FSystemType,FMarketingStyle,FPayBillID,FCheckDate,FExplanation,FFetchAdd,FFetchDate,FManagerID,FRefType,FSelTranType,FChildren,FHookStatus,FActPriceVchTplID,FPlanPriceVchTplID,FProcID,FActualVchTplID,FPlanVchTplID,FBrID,FVIPCardID,FVIPScore,FHolisticDiscountRate,FPOSName,FWorkShiftId,FCussentAcctID,FZanGuCount,FPOOrdBillNo,FLSSrcInterID,FSettleDate,FManageType,FOrderAffirm,FAutoCreType,FConsignee,FDrpRelateTranType,FPrintCount,FPOMode,FInventoryType,FObjectItem,FConfirmStatus,FConfirmMem,FConfirmDate,FConfirmer,FAutoCreatePeriod,FYearPeriod,FPayCondition,FsourceType,FReceiver,FHeadSelfB0154,FHeadSelfA0143,FHeadSelfB0435,FHeadSelfA0537,FHeadSelfB0836,FHeadSelfA9738,FHeadSelfB0939,FHeadSelfD0134,FHeadSelfC0131,FHeadSelfC0231,FHeadSelfA0230,FHeadSelfB0837,FHeadSelfB0436,FInvoiceStatus,FSendStatus,FEnterpriseID,FBillReviewer,FBillReviewDate,FCod,FReceiveMan,FConsigneeAdd,FISUpLoad,FReceiverMobile,FAccessoryCount,FHeadSelfA0233")] ICStockBill iCStockBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCStockBill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iCStockBill);
        }

        // GET: ICStockBills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICStockBill iCStockBill = db.ICStockBill.Find(id);
            if (iCStockBill == null)
            {
                return HttpNotFound();
            }
            return View(iCStockBill);
        }

        // POST: ICStockBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ICStockBill iCStockBill = db.ICStockBill.Find(id);
            db.ICStockBill.Remove(iCStockBill);
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
