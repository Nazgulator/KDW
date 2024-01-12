using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Models;using KDW.Controllers;

namespace KDW.Controllers
{
    public class ICStockBillEntriesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: ICStockBillEntries
        public ActionResult Index(int id=0, string FBillNo = "")
        { List<ICStockBillEntry> E = new List<ICStockBillEntry>();
            if (id > 0)
            {
                E = db.ICStockBillEntry.Where(x => x.FInterID == id).Include(i => i.t_Item).Include(i => i.ICStockBill).Include(i => i.POOrder).Include(i => i.t_StockTo).ToList();
            }
            if (FBillNo.Equals("")==false)
            {
                E = db.ICStockBillEntry.Include(i => i.ICStockBill).Where(x=>x.ICStockBill.FBillNo.Contains(FBillNo)).Include(i => i.t_Item).Include(i => i.POOrder).Include(i => i.t_StockTo).ToList();

            }
            return View(E);
        }

        // GET: ICStockBillEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICStockBillEntry iCStockBillEntry = db.ICStockBillEntry.Find(id);
            if (iCStockBillEntry == null)
            {
                return HttpNotFound();
            }
            return View(iCStockBillEntry);
        }

        // GET: ICStockBillEntries/Create
        public ActionResult Create()
        {
            ViewBag.FItemID = new SelectList(db.t_Item, "FItemID", "FNumber");
            ViewBag.FInterID = new SelectList(db.ICStockBill, "FInterID", "FBrNo");
            ViewBag.FOrderInterID = new SelectList(db.POOrder, "FInterID", "FBrNo");
            ViewBag.FDCStockID = new SelectList(db.t_Stock, "FItemID", "FBrNO");
            return View();
        }

        // POST: ICStockBillEntries/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FBrNo,FInterID,FEntryID,FItemID,FQtyMust,FQty,FPrice,FBatchNo,FAmount,FNote,FSCBillInterID,FSCBillNo,FUnitID,FAuxPrice,FAuxQty,FAuxQtyMust,FQtyActual,FAuxQtyActual,FPlanPrice,FAuxPlanPrice,FSourceEntryID,FCommitQty,FAuxCommitQty,FKFDate,FKFPeriod,FDCSPID,FSCSPID,FConsignPrice,FConsignAmount,FProcessCost,FMaterialCost,FTaxAmount,FMapNumber,FMapName,FOrgBillEntryID,FOperID,FPlanAmount,FProcessPrice,FTaxRate,FSnListID,FAmtRef,FAuxPropID,FCost,FPriceRef,FAuxPriceRef,FFetchDate,FQtyInvoice,FQtyInvoiceBase,FUnitCost,FSecCoefficient,FSecQty,FSecCommitQty,FSourceTranType,FSourceInterId,FSourceBillNo,FContractInterID,FContractEntryID,FContractBillNo,FICMOBillNo,FICMOInterID,FPPBomEntryID,FOrderInterID,FOrderEntryID,FOrderBillNo,FAllHookQTY,FAllHookAmount,FCurrentHookQTY,FCurrentHookAmount,FStdAllHookAmount,FStdCurrentHookAmount,FSCStockID,FDCStockID,FPeriodDate,FCostObjGroupID,FCostOBJID,FDetailID,FMaterialCostPrice,FReProduceType,FBomInterID,FDiscountRate,FDiscountAmount,FSepcialSaleId,FOutCommitQty,FOutSecCommitQty,FDBCommitQty,FDBSecCommitQty,FAuxQtyInvoice,FOperSN,FCheckStatus,FSplitSecQty,FInStockID,FSaleCommitQty,FSaleSecCommitQty,FSaleAuxCommitQty,FSelectedProcID,FVWInStockQty,FAuxVWInStockQty,FSecVWInStockQty,FSecInvoiceQty,FCostCenterID,FPlanMode,FMTONo,FSecQtyActual,FSecQtyMust,FClientOrderNo,FClientEntryID,FRowClosed,FCostPercentage,FItemSize,FItemSuite,FPositionNo,FAcctCheck,FClosing,FDeliveryNoticeEntryID,FDeliveryNoticeFID,FIsVMI,FEntrySupply,FChkPassItem,FSEOutInterID,FSEOutEntryID,FSEOutBillNo,FConfirmMemEntry,FWebReturnQty,FWebReturnAuxQty,FItemStatementBillNO,FItemStatementEntryID,FItemStatementInterID,FCommitAmt,FFatherProductID,FRealAmount,FRealPrice,FDefaultBaseQty,FDefaultQty,FRealStockBaseQty,FRealStockQty,FDiscardID,FOLOrderBillNo,FLockFlag,FEntrySelfB0168,FEntrySelfB0169,FEntrySelfB0857,FEntrySelfA0159,FEntrySelfA0557,FEntrySelfB0456,FEntrySelfB0457,FEntrySelfB0458,FEntrySelfA0160,FEntrySelfB0459,FEntrySelfB0858,FEntrySelfA0558,FEntrySelfB0460,FEntrySelfA0240,FEntrySelfA0161,FReturnNoticeBillNO,FReturnNoticeEntryID,FReturnNoticeInterID,FProductFileQty,FServiceRequestNo,FSplitState,FQtySplit,FAuxQtySplit,FAddQty,FAuxAddQty,FPurchasePrice,FPurchaseAmount,FCheckAmount,FOutSourceInterID,FOutSourceEntryID,FOutSourceTranType,FProcessTaxPrice,FProcessTaxCost,FShopName,FPostFee,FReviewBillsQty,FPTLQty,FBarCodeListID,FEntryAccessoryCount,FAUXQTY_Gain,FAUXQTY_Loss,FNeedBackFlush,FBackFlushFlag,FSendPlanID,FEntrySelfA0173")] ICStockBillEntry iCStockBillEntry)
        {
            if (ModelState.IsValid)
            {
                db.ICStockBillEntry.Add(iCStockBillEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FItemID = new SelectList(db.t_Item, "FItemID", "FNumber", iCStockBillEntry.FItemID);
            ViewBag.FInterID = new SelectList(db.ICStockBill, "FInterID", "FBrNo", iCStockBillEntry.FInterID);
            ViewBag.FOrderInterID = new SelectList(db.POOrder, "FInterID", "FBrNo", iCStockBillEntry.FOrderInterID);
            ViewBag.FDCStockID = new SelectList(db.t_Stock, "FItemID", "FBrNO", iCStockBillEntry.FDCStockID);
            return View(iCStockBillEntry);
        }

        // GET: ICStockBillEntries/Edit/5
        public ActionResult Edit(int? id, int entryId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICStockBillEntry iCStockBillEntry = db.ICStockBillEntry.Where(x=>x.FInterID==id&&x.FEntryID == entryId).First();
            if (iCStockBillEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.FItemID = new SelectList(db.t_Item, "FItemID", "FNumber", iCStockBillEntry.FItemID);
            ViewBag.FInterID = new SelectList(db.ICStockBill, "FInterID", "FBillNo", iCStockBillEntry.FInterID);
            ViewBag.FOrderInterID = new SelectList(db.POOrder, "FInterID", "FBillNo", iCStockBillEntry.FOrderInterID);
            ViewBag.FDCStockID = new SelectList(db.t_Stock, "FItemID", "FName", iCStockBillEntry.FDCStockID);
            return View(iCStockBillEntry);
        }

        // POST: ICStockBillEntries/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FInterID,FEntryID,FQty,FNote,FDCStockId")] ICStockBillEntry iCStockBillEntry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    iCStockBillEntry.FQtyMust = iCStockBillEntry.FQty;
                    iCStockBillEntry.FAuxQty = iCStockBillEntry.FQty;
                    iCStockBillEntry.FAuxQtyMust = iCStockBillEntry.FQty;
                    iCStockBillEntry.FAuxQty = iCStockBillEntry.FQty;

                    db.Entry(iCStockBillEntry).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {

                }

                try
                {
                    POOrderEntriesController C = new POOrderEntriesController();
                   
                //    C.PeremeshenieNaSklad(iCStockBillEntry.FDCStockID, iCStockBillEntry.FItemID.Value, iCStockBillEntry.FQty, true, "", true);
                  //  db.ICInventory.Where(x => x.FStockID == iCStockBillEntry.FDCStockID && x.FItemID == iCStockBillEntry.FItemID).First();

                 }
                catch
                {

                }

                return RedirectToAction("Index", new { id = iCStockBillEntry.FInterID });
            }
            return View(iCStockBillEntry);
        }

        // GET: ICStockBillEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICStockBillEntry iCStockBillEntry = db.ICStockBillEntry.Find(id);
            if (iCStockBillEntry == null)
            {
                return HttpNotFound();
            }
            return View(iCStockBillEntry);
        }

        // POST: ICStockBillEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ICStockBillEntry iCStockBillEntry = db.ICStockBillEntry.Find(id);
            db.ICStockBillEntry.Remove(iCStockBillEntry);
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
