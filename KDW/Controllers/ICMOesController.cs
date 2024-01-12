using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Filters;
using KDW.Models;

using MessagingToolkit.QRCode.Codec;

namespace KDW.Controllers
{
    [Culture]
    public class ICMOesController : Controller
    {
        private KingDeeDB db = new KingDeeDB();

        // GET: ICMOes
        [Culture]
        public ActionResult Index()
        {
            List<ICMO> iCMO = new List<ICMO>();
            DateTime Date = DateTime.Now.AddMonths(-6);
            iCMO = db.ICMO.Include(i => i.t_Department).Include(x => x.t_Item).Where(x => x.FCheckDate>=Date&& x.FCommitQty != x.FQty).ToList();

  
            if (Session["CurrentDepartment"]!=null) //Фильтруем по выбранному работником подразделению
            {
                string Dept = (string)Session["CurrentDepartment"];
                int DeptId = FindDeptId(Dept);
                iCMO = iCMO.Where(x => x.FWorkShop == DeptId).ToList();
            }
            else
            {
            
            }

      
            return View(iCMO.ToList());
        }

        [Culture]
        public ActionResult CompleteWork(int Id)
        {
            DateTime Date = DateTime.Now.AddMonths(-6);
            var Items = db.ICMO.Where(x => x.FInterID == Id ).Include(x => x.t_Item).Include(x=>x.t_Department).First();
            var Stocks = db.t_Stock;
         
            //Переделать на фильтр по DepartmentToStocks
            SelectList SL ;
     if (Items.t_Department!=null) // Тут был фильтр по DepartmentToStock
            {
            //    List<int> StocksInDept = Items.t_Department.DepartmentToStock.Select(x => x.StockId.Value).ToList();
          //      SL = new SelectList(Stocks.Where(x => StocksInDept.Contains(x.FItemID)), "FItemID", "FName");
          //      Session["StocksByDept"] = Stocks.Where(x => StocksInDept.Contains(x.FItemID)).Select(x=>x.FName).ToList() ;
            }
     else
            {
                SL = new SelectList(Stocks, "FItemID", "FName");
                Session["StocksByDept"] = db.t_Stock.Select(x => x.FName).ToList();
            }
            ViewBag.Department = Items.t_Department;
     //       ViewBag.Stocks = SL;
            ViewBag.Managers = new SelectList(db.t_Item.Where(x => x.FItemClassID == 3), "FItemID", "FName");
          
            return View(Items);
        }


        public int FindUserId()
        {
            int userId = 0;
            if (Session["CurrentUser"] != null)
            {
                string user = (string)Session["CurrentUser"];
                userId = db.t_Item.Where(x => x.FItemClassID == 3 && x.FName.Equals(user))
                               .Select(a => a.FItemID)
                               .First();
            }
            return userId;
        }

        public JsonResult AutocompleteSearchStorage(string term)
        {
            List<string> Result = new List<string>();
            if (Session["StocksByDept"] == null)
            {
                //Получаем всех пользаков
                Result = db.t_Stock.Where(x => x.FName.Contains(term))
                            .Select(a => a.FName)
                            .Distinct().ToList();

                //Сохраняем в сессию чтобы все было свеженькое
                Session["StocksByDept"] = Result;


            }
            else
            {//Загружаем из сессии
                Result = (List<string>)Session["StocksByDept"];
            }
            try
            {
                Result = Result.Where(x => x.Contains(term)).ToList();
            }
            catch
            {
                Result = new List<string>();
            }

            if (Result.Count == 0)
            {
                Result.Add(Resources.Resource.PoZaprosuNeNaideno);
            }

            return Json(Result, JsonRequestBehavior.AllowGet);





            ///   var models = db.t_Stock.Where(x => x.FName.Contains(term))
            //                    .Select(a => new { value = a.FName })
            //                   .Distinct();

            //   return Json(models, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveCompleteWorkJson(string Stock, string Manager, int InterID, int FCommitQty)
        {
            string Message = "";

            int StockID = 0;
            int ManagerID = 0;
         
            try
            {
                StockID = db.t_Stock.Where(x => x.FName.Equals(Stock)).Select(a => a.FItemID).First();
                ManagerID = db.t_Item.Where(x => x.FItemClassID == 3 && x.FName.Equals(Manager)).Select(a => a.FItemID).First();
                
            }
            catch
            {
                return Json(Resources.Resource.ZapolniteYellow);
            }



            var ICMO = db.ICMO.Where(x => x.FInterID == InterID ).Include(x => x.t_Item).Include(x=>x.t_Item.NomenklaturaEnterprise).First();//Строка в заказе поставщику

            if (FCommitQty > ICMO.FQty - ICMO.FCommitQty)
            {
                return Json(Resources.Resource.VveliBolsheChemVZakaze);
            }

            if (FCommitQty == 0)
            {
                return Json(Resources.Resource.NomenklaturiNedostatochno);
            }

            var MaxNum = db.ICMaxNum.Where(x => x.FTableName == "ICStockBill").First();//Максимальный номер ICStockBill в таблице номеров
            //Плюсуем макс номер
            MaxNum.FMaxNum++;
            var MaxStockID = db.ICBillNo.Where(x => x.FBillID == 2).First();

            string WIN = "CIN0" + MaxStockID.FCurNo;


          //  var POOrder = db.POOrder.Where(x => x.FInterID == InterID).Include(x => x.t_Department).First();//Берем данные из заказа поставщику
          if (Session["CurrentUser"]==null)
            {
                return Json(Resources.Resource.ViberitePolzovatelya);
            }


            int userId = FindUserId();
         


            //  MaxStockID = Convert.ToInt32(ZaprosOneZapis("SELECT FCurNo FROM[ICBillNo]  where FBillID = 1", true));

            //  select(FMaxNum + 1) FROM ICMaxNum where FTableName = 'ICStockBill'"
            var StockBill = new ICStockBill();//Создаем новое поступление на склад
            StockBill.FInterID = MaxNum.FMaxNum.Value;
            StockBill.FDate = DateTime.Now;
            StockBill.FTranType = 2;
            StockBill.FBillNo = WIN;
            StockBill.FDeptID = ICMO.FWorkShop.Value;
            StockBill.FCheckerID = userId;
            StockBill.FPosterID = userId;
            StockBill.FManagerID = ManagerID;
            StockBill.FSManagerID = ManagerID;
            StockBill.FBillerID = userId;
            StockBill.FFManagerID = ManagerID;
            StockBill.FHookInterID = 37861;//Неизвестно что за хук
            StockBill.FPosted = 1;
            StockBill.FCheckSelect = 0;
            StockBill.FROB = 1;
            StockBill.FStatus = 1;
            StockBill.FUpStockWhenSave = false;
            StockBill.FCancellation = false;
            StockBill.FOrgBillInterID = 0;
            StockBill.FBillTypeID = 0;
            StockBill.FPOStyle = 252;
            StockBill.FBackFlushed = false;
            StockBill.FUUID = Guid.NewGuid();
            StockBill.FOperDate = BitConverter.GetBytes(DateTime.Now.Ticks);
            StockBill.FMarketingStyle = 12530;
            StockBill.FCheckDate = DateTime.Now;
            StockBill.FExplanation = "KingDeeWeb";
            StockBill.FSelTranType = 85;
            StockBill.FChildren = 1;
            StockBill.FHookStatus = 2;
            StockBill.FEnterpriseID = 0; //здесь можно связать ID с чем-нибудь
            StockBill.FISUpLoad = 1059;
            StockBill.FsourceType = 37521;
            StockBill.FPayCondition = 1000;
            StockBill.FYearPeriod = DateTime.Now.ToString("yyyy-MM");
            StockBill.FPOMode = 36680;
            StockBill.FBrNo = "0";
            StockBill.FFetchAdd = "";
            StockBill.FPOSName = "";
            StockBill.FConfirmMem = "";
            StockBill.FInvoiceStatus = "";
            StockBill.FHeadSelfA0143 = "KingDeeWeb";
            ICStockBillEntry Entry = new ICStockBillEntry();
            bool go = false;
            try
            {
                db.ICStockBill.Add(StockBill);
                db.SaveChanges();

                Entry.FInterID = MaxNum.FMaxNum.Value;

                db.Entry(MaxNum).State = EntityState.Modified;
                db.SaveChanges();


                MaxStockID.FCurNo++;
                MaxStockID.FDesc = "CIN+0" + MaxStockID.FCurNo;
                db.Entry(MaxStockID).State = EntityState.Modified;
                db.SaveChanges();
                go = true;
            }
            catch (Exception e)
            {

            }



            var QR = new QRTable();
            if (go)//если добавлена шапка то добавляем строки
            {



                //Сохраняем QR код
                string STQ = ICMO.t_Item.FNumber + ";" + ICMO.t_Item.FName + ";" + FCommitQty + ";" + StockBill.FCheckDate.Value.ToString("dd.MM.yyyy") + ";" + ICMO.FBillNo+";"+ ICMO.t_Item.NomenklaturaEnterprise.First().RusName + ";" + StockID + ";";

                try
                {


                    QR.QR = CreateQrCode(STQ);
                    QR.QRstring = STQ;
                    QR.Date = DateTime.Now;
                    db.QRTable.Add(QR);
                    db.SaveChanges();

                }
                catch (Exception c)
                {
                    Console.WriteLine("Не смогли сгенерировать QR код " + c.Message);
                }


                go = false;

                Entry.FBrNo = "0";
                decimal price = 0;//Рассчитать стоимость материалов
   
                Entry.FItemID = ICMO.FItemID;
                Entry.FQtyMust = ICMO.FQty;
                Entry.FAuxQtyMust = ICMO.FQty;
                Entry.FQty = FCommitQty;
                Entry.FPrice = price;//TODO сделать расчет стоимости исходя из БОМа?
                Entry.FBatchNo = "";
                decimal Q = Convert.ToDecimal(FCommitQty);
                decimal C = Convert.ToDecimal(price);
                Entry.FAmount = Q * C;
                Entry.FEntryID = 1;//ToDo учесть если будет более 1 строки то номер строки должен меняться
                Entry.FNote = "KingDeeWeb";
                Entry.FUnitID = 257;//Единица измерения прицепить из t_item
                Entry.FAuxPrice = price;
                Entry.FPurchasePrice = price;
                Entry.FPurchaseAmount = Q * C;
                Entry.FAuxQty = FCommitQty;
                Entry.FSourceBillNo = ICMO.FBillNo;
                Entry.FDCStockID = StockID;
                Entry.FSourceInterId = ICMO.FInterID;
                Entry.FOrderBillNo = "";
                Entry.FOrderInterID = 0;
                Entry.FOrderEntryID = 0;
                Entry.FMapNumber = QR.Id.ToString();//Сюда сохраняем QR Id
                

                Entry.FMapNumber = "";
                Entry.FContractBillNo = "";
                Entry.FICMOBillNo = ICMO.FBillNo;
                Entry.FMTONo = "";
                Entry.FItemSize = "";
                Entry.FItemSuite = "";
                Entry.FPositionNo = "";
                Entry.FSEOutBillNo = "";
                Entry.FConfirmMemEntry = "";
                Entry.FItemStatementBillNO = "";
                Entry.FReturnNoticeBillNO = "";
                Entry.FSplitState = "";
                Entry.FICMOInterID = ICMO.FInterID;



                try
                {
                    db.ICStockBillEntry.Add(Entry);
                    db.SaveChanges();




                    go = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Не смогли добавить строку " + ex.Message);
                }
            }

            if (go)
            {
                go = false;
                //Добавляем в остаток на складе
                ICInventory Sklad = new ICInventory();
                int EstLiStrokaNaSklade = 0;
                try
                {
                    EstLiStrokaNaSklade = db.ICInventory.Where(x => x.FStockID == StockID && x.FItemID == ICMO.FItemID).Count();
                }
                catch
                {

                }
                if (EstLiStrokaNaSklade > 0)
                {

                    try
                    {
                        Sklad = db.ICInventory.Where(x => x.FStockID == StockID && x.FItemID == ICMO.FItemID).First();
                        Sklad.FQty += FCommitQty;
                    }
                    catch (Exception SE)
                    {
                        Console.WriteLine("Не смогли найти строку на складе " + SE.Message);
                    }

                    try
                    {

                        db.Entry(Sklad).State = EntityState.Modified;
                        db.SaveChanges();
                        go = true;
                    }

                    catch (Exception exx)
                    {
                        Console.WriteLine("Ошибка добавления на склад " + exx.Message);
                    }
                }
                else
                {
                    //Если нет такой строки то добавляем новую
                    Sklad.FQty = FCommitQty;
                    Sklad.FStockID = StockID;
                    Sklad.FItemID = ICMO.FItemID;
                    Sklad.FBrNo = "0";
                    Sklad.FBatchNo = "";
                    Sklad.FKFDate = "";
                    Sklad.FMTONo = "";
                    try
                    {
                        db.ICInventory.Add(Sklad);
                        db.SaveChanges();
                        go = true;
                    }
                    catch (Exception exxx)
                    {
                        Console.WriteLine("Не смогли добавить новую строку поступления на склад ICInventory " + exxx.Message);
                    }
                }


            }

            if (go)
            {
                Message = "Ok";
            }
            //     "(FBrNo, FInterID, FEntryID, FItemID, FQtyMust,FAuxQtyMust, FQty, FPrice, FBatchNo, " +
            //                        "FAmount, FNote, FUnitID, FAuxPrice, FAuxQty, FProcessCost, FMaterialCost, FTaxAmount," +
            //                         " FSourceBillNo, FDCStockID, FSourceInterId, FOrderBillNo, FOrderInterID, FOrderEntryID)" +
            //                         "VALUES('O', " + InterId + "," + NPP + ", " + NL[0].FItemId + ", " + KolichestvoVZakaze + ", " + KolichestvoVZakaze + ", " + QTY + ", " + CENA + ", '', " +
            //                         "" + Amount + ", 'Enterprise', 259, " + CENA + ", " + QTY + ", 0, 0, 0," +
            //                         " '" + PURCH + "', " + SkladKitai + ", " + PURCHINTERID + ", '" + PURCH + "', " + PURCHINTERID + "," + StrokaPURCH + ")", true);




            //Меняем остатки в заказе поставщику
            try
            {
                ICMO.FCommitQty += FCommitQty;
                db.Entry(ICMO).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Ok";
            }
            catch (Exception E)
            {
                ViewBag.Message = "Ошибка = " + E.Message;
            }


            return Json(Message + ";" + QR.Id);
        }

        private Bitmap NewQR(string QRText)
        {
            string qrtext = QRText; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            return (qrcode); // pictureBox выводит qrcode как изображение.
        }

        public static byte[] ConvertToByteArray(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public ActionResult GenerateQrCode(string QRText)
        {
            string qrtext = QRText; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrCodeImage = encoder.Encode(qrtext);
            //write your own methode to convert your bit map to byte array, here is a link
            //http://stackoverflow.com/questions/7350679/convert-a-bitmap-into-a-byte-array-in-c
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return File(byteArray, "image/jpeg");
        }



        public byte[] CreateQrCode(string QRText)
        {
            string qrtext = QRText; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrCodeImage = encoder.Encode(qrtext);
            //write your own methode to convert your bit map to byte array, here is a link
            //http://stackoverflow.com/questions/7350679/convert-a-bitmap-into-a-byte-array-in-c
            byte[] byteArray = ConvertToByteArray(qrCodeImage);
            return byteArray;
        }

        public int FindDeptId(string Department)
        {
            int Id = 0;
            try
            {
                Id = db.t_Item.Where(x => x.FName.Equals(Department)).Select(x=>x.FItemID).First();
            }
            catch
            {

            }
            return Id;
        }

        // GET: ICMOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICMO iCMO = db.ICMO.Find(id);
            if (iCMO == null)
            {
                return HttpNotFound();
            }
            return View(iCMO);
        }

        // GET: ICMOes/Create
        public ActionResult Create()
        {
            ViewBag.FWorkShop = new SelectList(db.t_Department, "FItemID", "FBrNO");
            return View();
        }

        // POST: ICMOes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FBrNo,FInterID,FBillNo,FTranType,FStatus,FMRP,FType,FWorkShop,FItemID,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FConveyerID,FCommitDate,FCheckerID,FCheckDate,FRequesterID,FBillerID,FSourceEntryID,FClosed,FNote,FUnitID,FAuxCommitQty,FAuxQty,FOrderInterID,FPPOrderInterID,FParentInterID,FCancellation,FSupplyID,FQtyFinish,FQtyScrap,FQtyForItem,FQtyLost,FPlanIssueDate,FRoutingID,FStartDate,FFinishDate,FAuxQtyFinish,FAuxQtyScrap,FAuxQtyForItem,FAuxQtyLost,FMrpClosed,FBomInterID,FQtyPass,FAuxQtyPass,FQtyBack,FAuxQtyBack,FFinishTime,FReadyTIme,FPowerCutTime,FFixTime,FWaitItemTime,FWaitToolTime,FTaskID,FWorkTypeID,FCostObjID,FStockQty,FAuxStockQty,FSuspend,FProjectNO,FProductionLineID,FReleasedQty,FReleasedAuxQty,FUnScheduledQty,FUnScheduledAuxQty,FSubEntryID,FScheduleID,FPlanOrderInterID,FProcessPrice,FProcessFee,FGMPBatchNo,FGMPCollectRate,FGMPItemBalance,FGMPBulkQty,FCustID,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FMRPLockFlag,FHandworkClose,FConfirmerID,FConfirmDate,FInHighLimit,FInHighLimitQty,FAuxInHighLimitQty,FInLowLimit,FInLowLimitQty,FAuxInLowLimitQty,FChangeTimes,FCheckCommitQty,FAuxCheckCommitQty,FCloseDate,FPlanConfirmed,FPlanMode,FMTONo,FPrintCount,FFinClosed,FFinCloseer,FFinClosedate,FStockFlag,FStartFlag,FVchBillNo,FVchInterID,FCardClosed,FHRReadyTime,FPlanCategory,FBomCategory,FSourceTranType,FSourceInterId,FSourceBillNo,FReprocessedAuxQty,FReprocessedQty,FSelDiscardStockInAuxQty,FSelDiscardStockInQty,FDiscardStockInAuxQty,FDiscardStockInQty,FSampleBreakAuxQty,FSampleBreakQty,FResourceID,FAddInterID,FAPSImported,FAPSLastStatus,FAuxPropID,FOrderBOMEntryID,FStartTimePDA,FIsMakeLowerBill,FFlowCardStatus,FIsMesStartWork")] ICMO iCMO)
        {
            if (ModelState.IsValid)
            {
                db.ICMO.Add(iCMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FWorkShop = new SelectList(db.t_Department, "FItemID", "FBrNO", iCMO.FWorkShop);
            return View(iCMO);
        }

        // GET: ICMOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICMO iCMO = db.ICMO.Find(id);
            if (iCMO == null)
            {
                return HttpNotFound();
            }
            ViewBag.FWorkShop = new SelectList(db.t_Department, "FItemID", "FBrNO", iCMO.FWorkShop);
            return View(iCMO);
        }

        // POST: ICMOes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FBrNo,FInterID,FBillNo,FTranType,FStatus,FMRP,FType,FWorkShop,FItemID,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FConveyerID,FCommitDate,FCheckerID,FCheckDate,FRequesterID,FBillerID,FSourceEntryID,FClosed,FNote,FUnitID,FAuxCommitQty,FAuxQty,FOrderInterID,FPPOrderInterID,FParentInterID,FCancellation,FSupplyID,FQtyFinish,FQtyScrap,FQtyForItem,FQtyLost,FPlanIssueDate,FRoutingID,FStartDate,FFinishDate,FAuxQtyFinish,FAuxQtyScrap,FAuxQtyForItem,FAuxQtyLost,FMrpClosed,FBomInterID,FQtyPass,FAuxQtyPass,FQtyBack,FAuxQtyBack,FFinishTime,FReadyTIme,FPowerCutTime,FFixTime,FWaitItemTime,FWaitToolTime,FTaskID,FWorkTypeID,FCostObjID,FStockQty,FAuxStockQty,FSuspend,FProjectNO,FProductionLineID,FReleasedQty,FReleasedAuxQty,FUnScheduledQty,FUnScheduledAuxQty,FSubEntryID,FScheduleID,FPlanOrderInterID,FProcessPrice,FProcessFee,FGMPBatchNo,FGMPCollectRate,FGMPItemBalance,FGMPBulkQty,FCustID,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FMRPLockFlag,FHandworkClose,FConfirmerID,FConfirmDate,FInHighLimit,FInHighLimitQty,FAuxInHighLimitQty,FInLowLimit,FInLowLimitQty,FAuxInLowLimitQty,FChangeTimes,FCheckCommitQty,FAuxCheckCommitQty,FCloseDate,FPlanConfirmed,FPlanMode,FMTONo,FPrintCount,FFinClosed,FFinCloseer,FFinClosedate,FStockFlag,FStartFlag,FVchBillNo,FVchInterID,FCardClosed,FHRReadyTime,FPlanCategory,FBomCategory,FSourceTranType,FSourceInterId,FSourceBillNo,FReprocessedAuxQty,FReprocessedQty,FSelDiscardStockInAuxQty,FSelDiscardStockInQty,FDiscardStockInAuxQty,FDiscardStockInQty,FSampleBreakAuxQty,FSampleBreakQty,FResourceID,FAddInterID,FAPSImported,FAPSLastStatus,FAuxPropID,FOrderBOMEntryID,FStartTimePDA,FIsMakeLowerBill,FFlowCardStatus,FIsMesStartWork")] ICMO iCMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FWorkShop = new SelectList(db.t_Department, "FItemID", "FBrNO", iCMO.FWorkShop);
            return View(iCMO);
        }

        // GET: ICMOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICMO iCMO = db.ICMO.Find(id);
            if (iCMO == null)
            {
                return HttpNotFound();
            }
            return View(iCMO);
        }

        // POST: ICMOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ICMO iCMO = db.ICMO.Find(id);
            db.ICMO.Remove(iCMO);
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
