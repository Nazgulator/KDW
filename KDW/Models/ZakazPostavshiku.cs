using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace KDW.Models
{

    public class ZakazEntry
    {
        public int FInterId = 0;
        public int FEntryId = 0;
        public decimal FQtyMust = 0;
        public decimal FCommitQty = 0;
        public int ItemId = 0;
        public string ItemName = "";
        public string ItemNumber = "";
        public string FNote = "";
        public string FMTONo = "";
        public t_Item Item = new t_Item();
        public decimal Price = 0;
        public decimal PurchasePrice = 0;
        public decimal TaxRate = 13;
        public int UnitId = 0;
        public int DetailId = 0;
    }

    public class ZakazPostavshiku
    {
        private KingDeeDB db = new KingDeeDB();
        public POOrder POOrder = new POOrder();
        public ICSubContract Subcontract = new ICSubContract();
        public DateTime Date = DateTime.Now;
        public int SupplierId = 0;
        public string SupplierName = "";
        public int DepartmentId = 0;
        public string DepartmentName = "";
        public int EmployeeId = 0;
        public string FMTONo = "";
        public string Tip = "";
        public int ZakazId = 0;
        public string FBillNo = "";
        public List<ZakazEntry> Entries = new List<ZakazEntry>();
        public ZakazEntry SelectedEntry = new ZakazEntry();
        public int FSelTranType = 0;
        public int FPOMode = 0;
        public int FPOStyle = 0;
        public int MaxLev = 0;
        public int PurposeId = 0;

        //Находит уровень +1 
        public int SelectMaxLev()
        {
          
            try
            {
                MaxLev = db.Dvigenie.Where(x => x.POOrderId == ZakazId && x.ItemID == SelectedEntry.ItemId && x.ZakazPostavshiku.Equals(FBillNo)).Max(x => x.Lev);
            }
            catch
            {

            }
            MaxLev++;

            return MaxLev;
        }

      

        public bool EditEntryZakaza(decimal PlusQTY=0, int CurrentUserId=0)
        {
            DateTime D = DateTime.Now;
            bool Result = false;
            
            if (SelectedEntry.ItemId!=0&& PlusQTY!=0&& Tip.Equals("") == false)
            {
                if (Tip.Contains("POORD"))
                {
                    try
                    {
                      using (var db2 = new KingDeeDB())
                        {
                        POOrderEntry E = db2.POOrderEntry.Where(x => x.FInterID == SelectedEntry.FInterId && x.FEntryID == SelectedEntry.FEntryId).First();
                        E.FAuxCommitQty += PlusQTY;
                        E.FCommitQty += PlusQTY;
                            E.FStockQty = E.FCommitQty;
                            E.FAuxStockQty = E.FAuxCommitQty;
                            if (E.FCommitQty>=E.FQty)
                            {
                                E.FCloseEntryDate = D;
                                E.FCloseEntryUser = CurrentUserId;
                                E.FMrpAutoClosed = 1;
                                E.FMrpClosed = 1;
                            }
                            if (E.FCommitQty < E.FQty)
                            {
                                E.FCloseEntryDate = D;
                                E.FCloseEntryUser = CurrentUserId;
                                E.FMrpAutoClosed = 0;
                                E.FMrpClosed = 0;
                            }




                            db2.Entry(E).State = EntityState.Modified;
                            db2.SaveChanges();
                            Result = true;
                        }


                    }
                    catch (Exception e)
                    {

                    
                    
                    }

                    //Проверяем все ли получено по заказу поставщику если все то закрываем заказ
                    try
                    {
                        decimal Raznica = db.POOrderEntry.Where(x => x.FInterID == ZakazId ).Sum(x=>x.FQty - x.FCommitQty);
                        if (Raznica<=0)
                        { 
                            using (var db2 = new KingDeeDB())
                            {
                            POOrder P = db2.POOrder.Where(x => x.FInterID == ZakazId).First();
                            P.FClosed = 1;
                            P.FStatus = 3;
                            P.FCloseUser = CurrentUserId;
                            P.FCloseDate = DateTime.Now;
                            P.FCloseCauses = "KingDeeWeb";
                                
                           
                                db2.Entry(P).State = EntityState.Modified;
                                db2.SaveChanges();
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                if (Tip.Contains("WW"))
                { 
                    using (var db2 = new KingDeeDB())
                    {
                    ICSubContractEntry E = db2.ICSubContractEntry.Where(x => x.FInterID == ZakazId && x.FEntryID == SelectedEntry.FEntryId).First();
                    E.FAuxCommitQty += PlusQTY;
                    E.FCommitQty += PlusQTY;
                        E.FStockQty = E.FAuxCommitQty;
                        E.FAuxStockQty = E.FAuxCommitQty;
                        if (E.FCommitQty >= E.FQty)
                        {
                        
                            E.FMrpAutoClosed = 1;
                            E.FMrpClosed = 1;
                        }
                        if (E.FCommitQty < E.FQty)
                        {
                            E.FMrpAutoClosed = 0;
                            E.FMrpClosed = 0;
                        }
                        try
                        {
                            db2.Entry(E).State = EntityState.Modified;
                            db2.SaveChanges();
                        }
                        catch
                        {

                        }
                    }

                    try
                    {
                        decimal Raznica = db.ICSubContractEntry.Where(x => x.FInterID == ZakazId).Sum(x => x.FQty- x.FCommitQty);
                        if (Raznica <= 0)
                        {   using (var db2 = new KingDeeDB())
                            {
                            ICSubContract P = db2.ICSubContract.Where(x => x.FInterID == ZakazId).First();
                            P.FClosed = 1;
                            P.FStatus = 3;
                           
                            P.FCloserID = CurrentUserId;
                            P.FClosedDate = DateTime.Now;

                         
                                db2.Entry(P).State = EntityState.Modified;
                                db2.SaveChanges();
                                Result = true;
                            }
                        }
                    }
                    catch
                    {

                    }

                }

            }
            return Result;
        }

      public void FindEntries(int IdZakaza, string TipZakaza, int EntryId =0, string ItemNumber="")
        {
            Tip = TipZakaza.ToUpper();
            ZakazId = IdZakaza;
            if (Tip.Equals("")==false)
            {

             
                if (Tip.Contains("POORD"))
                {
                    var ZEntries = db.POOrderEntry.Where(x => x.FInterID == ZakazId).Include(x=>x.POOrder).Include(x=>x.t_Item).Include(x=>x.t_Item.NomenklaturaEnterprise).Include(x=>x.POOrder.t_Supplier).Include(x=>x.POOrder.t_Department).ToList();
                    FSelTranType = 71;
                    FPOMode = 36680;
                    FPOStyle = 252;
                    Tip = "POORD";

                    foreach ( var e in  ZEntries)
                    {
                        ZakazEntry ZE = new ZakazEntry();
                        ZE.FEntryId = e.FEntryID;
                        ZE.FInterId = e.FInterID;
                        ZE.FCommitQty = e.FCommitQty;
                        ZE.FQtyMust = e.FQty;
                        ZE.ItemId = e.FItemID;
                        ZE.Item = e.t_Item;
                        ZE.ItemName = e.t_Item.FName;
                        ZE.ItemNumber = e.t_Item.FNumber;
                        ZE.Price =  e.FPrice;
                        ZE.PurchasePrice = e.FAuxTaxPrice;
                        ZE.UnitId = e.FUnitID;
                        ZE.DetailId = e.FDetailID;
                        ZE.FNote = e.FNote;
                        ZE.FMTONo = e.FNote;
                        ZE.TaxRate = e.FTaxRate.Value;
                        Entries.Add(ZE);
                        SupplierId = e.POOrder.t_Supplier.FItemID;
                        SupplierName = e.POOrder.t_Supplier.FName;
                        DepartmentId = e.POOrder.t_Department.FItemID;
                        DepartmentName = e.POOrder.t_Department.FName;
                        EmployeeId = e.POOrder.FEmpID.Value;
                        Date = e.POOrder.FDate.Value;
                        FBillNo = e.POOrder.FBillNo;
                        PurposeId = 0;
                    }
                }
                if (Tip.Contains("WW"))
                {
                    var ZEntries = db.ICSubContractEntry.Where(x => x.FInterID == ZakazId).Include(x => x.ICSubContract).Include(x => x.t_Item).Include(x => x.t_Item.NomenklaturaEnterprise).Include(x => x.ICSubContract.Supplier).Include(x=>x.ICSubContract.t_Department).ToList();
                    FSelTranType = 1007105;
                    FPOMode = 0;
                    FPOStyle = 0;
                    Tip = "WW";
                    foreach (var e in ZEntries)
                    {
                        ZakazEntry ZE = new ZakazEntry();
                        ZE.FEntryId = e.FEntryID;
                        ZE.FInterId = e.FInterID;
                        ZE.FCommitQty = e.FCommitQty;
                        ZE.FQtyMust = e.FQty;
                        ZE.ItemId = e.FItemID;
                        ZE.Item = e.t_Item;
                        ZE.ItemName = e.t_Item.FName;
                        ZE.ItemNumber = e.t_Item.FNumber;
                        ZE.Price = e.FPrice;
                        ZE.FMTONo = e.FNote;
                        ZE.PurchasePrice = e.FAuxTaxPrice;
                        ZE.UnitId = e.FUnitID;
                        ZE.DetailId = e.FDetailID;
                        ZE.FNote = e.FNote;
                        ZE.TaxRate = e.FTaxRate;

                        Entries.Add(ZE);
                        SupplierId = e.ICSubContract.Supplier.FItemID;
                        SupplierName = e.ICSubContract.Supplier.FName;
                        DepartmentId = e.ICSubContract.t_Department.FItemID;
                        DepartmentName = e.ICSubContract.t_Department.FName;
                        EmployeeId = e.ICSubContract.FEmployee;
                        FBillNo = e.ICSubContract.FBillNo;
                        Date = e.ICSubContract.FDate.Value;
                        PurposeId = 14190; //Должен быть указан при создании JIN 03.03.2023
                    }
                }
                if (EntryId!=0)
                {
                    
                    try
                    {
                        Entries = Entries.Where(x => x.FEntryId == EntryId).ToList();
                        SelectedEntry = Entries.First();
                    }
                    catch
                    {
                        SelectedEntry = Entries.First();
                    }
                }
                else
                {
                    if (ItemNumber!="")
                    {
                        int NN = 0;
                        int ItemId = 0;
                        //Ищем по ID
                        try
                        {
                            NN = Convert.ToInt32(ItemNumber);
                            ItemId = NN;
                         
                        }
                        catch
                        {

                        }
                        //Ищем по партномеру
                        if (NN == 0)
                        {
                            try
                            {
                                ItemId = db.t_Item.Where(x => x.FNumber.Equals(ItemNumber)).Select(x => x.FItemID).First();
                               
                            }
                            catch
                            {

                            }
                        }

                        //Ищем строку
            
                        try
                        {
                            Entries = Entries.Where(x => x.ItemId == ItemId).ToList();
                            SelectedEntry = Entries.First();
                        }
                        catch
                        {

                        }
                    }
                    }

                SelectMaxLev();
            }
        }

    }
}