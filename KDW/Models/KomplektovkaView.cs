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

  
    public class KomplektovkaView
    {
     //   private KingDeeDB db = new KingDeeDB();
        public int ItemId; //то что производим
        public List<NZP> NZPs = new List<NZP>(); // список всей номенклатуры
        public int WorkId = 0;
        public decimal QTY = 0;
        public int StarWorkId = 0;
        public int DepartmentId = 0;
        public int PlanshetId = 0;
        public string WorkNumber;
        public string QRD = "";
        public int StockId = 0;

        public List<Komplekt> Komplekt = new List<Komplekt>();

        public List<PPBOMEntry> BOMs = new List<PPBOMEntry>();

        public List<PlanoviWorks> PW = new List<PlanoviWorks>();

        public List<DateTime> PlanDates = new List<DateTime>();
        DateTime D = DateTime.Now.Date;
        DateTime Tomorrow = DateTime.Now.Date;

        public void FindStock()
        {
            try
            {
                using (var db = new KingDeeDB())
                {
                //  StockId =  db.DepartmentToStock.Where(x => x.DepartmentId == DepartmentId).Select(x=>x.StockId.Value).First();
                }
                
            }
            catch
            {

            }
        }

        public void SaveComplekt(int CIN)
        {
            try
            {
                var Komplekt = new List<Komplekt>();
                if (NZPs.Count>0&&CIN>0)
                {
                    foreach (var nzp in NZPs)
                    {
                        try
                        {
                            Komplekt K = new Komplekt();
                            K.POOrderId = nzp.POOrderId;
                            K.ItemId = nzp.ItemId;
                            K.DvigenieCIN = CIN;
                            using (var db = new KingDeeDB())
                            {
                                db.Komplekt.Add(K);
                                db.SaveChanges();
                            }
                            }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {

            }
        }


        public void FindNZP(int WorkID)
        
        {
            WorkId = WorkID;
            using (var db = new KingDeeDB())
            {
                WorkNumber = db.ICMO.Where(x => x.FInterID == WorkId).Select(x => x.FBillNo).First();
            }
            ZagruzkaBOM();

        }
        public void FindNZP(string QRData)
        {
                QRD = QRData;
                string[] S = QRData.Split(';');
                if (S[0].Equals("KOMPLEKTOVKA"))
                {

                    WorkId = Convert.ToInt32(S[1]);
                    StarWorkId = Convert.ToInt32(S[2]);
                    DepartmentId = Convert.ToInt32(S[3]);
                    PlanshetId = Convert.ToInt32(S[4]);
                    QTY = Convert.ToDecimal(S[5]);
                }
                else
                {

                }
                try
            {
                using (var db = new KingDeeDB())
                {
                    WorkNumber = db.ICMO.Where(x => x.FInterID == WorkId).Select(x=>x.FBillNo).First();
                }

                }
            catch
            {

            }
            
            ZagruzkaBOM();

           
        }

        public void FindNZPLight(string QRData)
        {
            QRD = QRData;
            string[] S = QRData.Split(';');
            if (S[0].Equals("KOMPLEKTOVKA"))
            {

                WorkId = Convert.ToInt32(S[1]);
                StarWorkId = Convert.ToInt32(S[2]);
                DepartmentId = Convert.ToInt32(S[3]);
                PlanshetId = Convert.ToInt32(S[4]);
                QTY = Convert.ToDecimal(S[5]);
            }
            else
            {

            }
            try
            {
                using (var db = new KingDeeDB())
                {
                    WorkNumber = db.ICMO.Where(x => x.FInterID == WorkId).Select(x => x.FBillNo).First();
                }

            }
            catch
            {

            }

          //  ZagruzkaBOM();


        }

        public void ZagruzkaBOM ()
        {
            
            List<int> SB = new List<int>();
            List<ICStockBillEntry> SBE = new List<ICStockBillEntry>();
            List<PlanoviWorks> P = new List<PlanoviWorks>();
            StarMehWorks S = new StarMehWorks();
            decimal NugnoToday = 0;
            decimal NugnoTomorrow = 0;

            FindPlan();

           
            try
            {
                P = PW.Where(x => x.Date == D && x.WorkId == WorkId).ToList();
            }
            catch
            {

            }


            try
            {
                using (var db = new KingDeeDB())
                {
                   // S = db.StarMehWorks.Where(x => x.DateStart == D && x.WorkId == WorkId&&x.Complete==false).OrderBy(x=>x.Poryadok).First();
                   
                    NugnoToday = db.StarMehWorks.Where(x => x.DateStart == D && x.WorkId == WorkId && x.Complete == false).Sum(x => (x.QTY - x.QTYFact));
                }
            }
            catch
            {

            }

            if (P.Count > 0)
            {
               decimal  NugnoToday2 = P.Sum(x => x.QTY);
                if (NugnoToday2>NugnoToday)
                {
                    NugnoToday = NugnoToday2;
                }
            }

            if (Tomorrow != DateTime.Today)
            {
                try
                {
                    P = PW.Where(x => x.Date == Tomorrow && x.WorkId == WorkId).ToList();
                }
                catch
                {

                }
                if (P.Count > 0)
                {
                    NugnoTomorrow = P.Sum(x => x.QTY);
                }
            }



            try
            {
                using (var db = new KingDeeDB())
                {
                    BOMs = db.PPBOMEntry.Where(x => x.FICMOInterID == WorkId).Include(x => x.t_Item).Include(x=>x.t_Item.NomenklaturaEnterprise).Include(x => x.PPBOM).Include(x => x.ICMO).ToList();
                }
            }
            catch
            {

            }

            using (var db = new KingDeeDB())
            {
                try
                {
                    SB = db.ICStockBill.Where(x => x.FTranType == 2 && x.FDate == D ).Select(x => x.FInterID).ToList(); //&& x.FCancellation == false && x.FStatus == 1
                    foreach (var a in SB)
                    {
                        try
                        {
                            SBE.AddRange(db.ICStockBillEntry.Where(x => x.FInterID == a&&x.FICMOInterID==WorkId).ToList());
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }


            }

            ObnovitNZP();

            foreach (var ent in BOMs)
            {
                ent.FQtyPick = 0;
                ent.FAuxQtyConsume = NZPs.Where(x => x.ItemId == ent.FItemID).Sum(x => x.QTY);
                ent.FQtyMust = NugnoToday * ent.FQtyScrap;
                ent.FAuxQtyMust = NugnoTomorrow * ent.FQtyScrap;
                try
                {

                    ent.FQtyPick += SBE.Where(x => x.FItemID == ent.FItemID).Sum(x => x.FQty); //Сколько использовали при пр-ве сегодня
                    //ent.FQtyPick += ent.FWIPQTY.Value;
                }
                catch
                {

                }
           
                

            }

        }

        public List<DateTime> PlanCalendar()
        {
            DateTime D = DateTime.Now.Date;
            List<DateTime> Dates = new List<DateTime>();
            using (var db = new KingDeeDB())
            {
              Dates =   db.PlanoviWorks.Select(x => x.Date.Value).Where(x => x >= D).Distinct().ToList();
            }
            return Dates;
            }
        public void FindPlan()
        {
            List<DateTime> Dates = PlanCalendar();

            using (var db = new KingDeeDB())
            {
                try
                {
                    PW = db.PlanoviWorks.Where(x => x.Date >= D && x.WorkId == WorkId).ToList();
                   // PlanDates = PW.Select(x => x.Date.Value).Distinct().OrderBy(x=>x.Date).ToList();
                }
                catch
                {

                }
                if (Dates.Count>1)
                {
                    Tomorrow = Dates[1];
                }
            }

            }
        public void ObnovitNZP()
        {
           
            try
            {
                using (var db = new KingDeeDB())
                {
                    NZPs = db.NZP.Where(x => x.WorkId == WorkId && x.Active == true).Include(x=>x.Dvigenie).Include(x=>x.Item).OrderBy(x => x.Id).ToList();
                    foreach (var nzp in NZPs)
                    {
                        string Tip = "POORD";
                        try
                        {
                            if (nzp.Dvigenie.ZakazPostavshiku.Contains("WW"))
                            {
                                Tip = "WW";
                            }
                        }
                        catch
                        {

                        }
                      //  nzp.Z.FindEntries(nzp.WorkId, Tip, 0, nzp.Item.FName);
                    }
                    //.Include(x => x.Item).Include(x => x.Stock).Include(x => x.Department).Include(x => x.POOrder).Include(x => x.Dvigenie).Include(x => x.StarMehWorks).Include(x => x.ICMO).OrderBy(x => x.Id).ToList();
                }
                    //   WorkId = WId;
                //   QTY = NZPs[0].ICMO.FAuxQty - NZPs[0].ICMO.FAuxCommitQty;
                //    ItemId = NZPs[0].ICMO.FItemID;
            }
            catch
            {

            }


        }

    }
}