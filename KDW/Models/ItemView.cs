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

    public class ItemToWork
    {
        public string Work;
        public decimal QTY;
    }
    public class ItemView
    {
        private KingDeeDB db = new KingDeeDB();
        public t_Item Item;
        public POOrder POOrder = new POOrder();
        public ZakazPostavshiku Z = new ZakazPostavshiku();
        public ICMO Work = new ICMO();
        public decimal QTY = 0;
        public string ZakazPostavshiku = "";
        public int Lev = 0;
        public t_Stock Stock = new t_Stock();
        public t_Item StockOrDep = new t_Item();
        public List<t_Stock> Stocks = new List<t_Stock>();
        public PPBOM PPBOM = new PPBOM();
        public List<ICMO> Works = new List<ICMO>();
        public List<Dvigenie> Dvigenies = new List<Dvigenie>();
        public Dvigenie LastDvig = new Dvigenie();
        public Dvigenie LastDvigNoWork = new Dvigenie();
        public Dvigenie LastSOUT = new Dvigenie();

        public List<Dvigenie> Childrens = new List<Dvigenie>();
        public List<Dvigenie> DvigeniesChilds = new List<Dvigenie>();
        public Dvigenie Parent = new Dvigenie();
        public List<ItemToWork> ItemToWork= new List<ItemToWork>();
        public Dvigenie LastDvigChild = new Dvigenie();
        public Dvigenie LastDvigChildParent = new Dvigenie();
        public Control LastControl = new Control(); 


        public void FindLastDvig(string QRData)
        {
            string[] S = QRData.Split(';');
            if (S != null && S.Length > 0)
            {
                try
                {
                    int POId = 1;
                    int Lev = 1;
                    string ZakazPostavshiku = "";
                    string Nomenklatura = S[0];

                    QRTable QR = db.QRTable.Where(x => x.QRstring.Equals(QRData)).First();

                    LastDvig = db.LastDvigs.Where(x => x.QRId == QR.Id).Include(x=>x.Dvigenie).Select(x=>x.Dvigenie).Include(x=>x.Item).Include(x => x.Item.t_ICItemMaterial).First();
                    LastDvig.QRTable = QR;

                    Z.FindEntries(LastDvig.POOrderId, LastDvig.ZakazPostavshiku, 0, LastDvig.ItemID.ToString());
                }
                catch
                {

                }
            }
        }
        public void FindDvigenies()
        {
            try
            {
            
               List<Dvigenie> AllDvigenies = db.Dvigenie.Where(x => x.POOrderId == Z.ZakazId && x.ItemID == Item.FItemID ).Include(x=>x.Stock).Include(x=>x.QRTable).Include(x=>x.NomenklaturaPlace).Include(x=>x.Control).Include(x=>x.QRTable).Include(x=>x.Komplekt).OrderBy(x=>x.Id).ToList();//.Include(x=>x.POOrder).Include(x=>x.POOrder.t_Supplier)

               

                foreach (var d in AllDvigenies)
                {
                           d.Komplekt =  db.Komplekt.Where(x => x.DvigenieCIN == d.Id).Include(x=>x.t_Item).Include(x=>x.POOrder).ToList();
              
                 //   if (Z.Tip.Equals("POORD"))
                //    {

                 //   }
                }
               //Находим все движения этого POORDER
                Dvigenies = AllDvigenies.Where(x => x.Lev == Lev).OrderBy(x=>x.Id).ToList();
                int CountDvigs = 0;
                //Если движений более 1  то берем только те что без отмены
                try
                {
                    CountDvigs = Dvigenies.Where(x => x.Otmena == false).Count();
                    if (CountDvigs>0)
                    {
                        Dvigenies = Dvigenies.Where(x => x.Otmena == false).ToList();
                    }
                }
                catch
                {

                }


                try
                {
                    LastControl = Dvigenies.Where(x => x.Control != null && x.Control.Count > 0).Select(x=>x.Control.OrderBy(y=>y.Id).LastOrDefault()).Last();
                    LastControl.StatusOTK = db.StatusOTK.Where(x => x.Id == LastControl.Status).First();
                   
                }
                catch
                {

                }

                //Находим максимальное движение
                int MaxId = Dvigenies.Max(x => x.Id);
                LastDvig = Dvigenies.Where(x => x.Id == MaxId).First();
                try
                {
                    LastSOUT = Dvigenies.Where(x => x.FBillNo.Contains("SOUT") && (x.Work == null || x.Work.Contains("STORNO")==false)).OrderByDescending(x => x.Id).First();
                }
                catch (Exception e)
                {

                }
                
                //Ищем последнее движение без ворка
                try
                {
                 //   LastDvigNoWork = Dvigenies.Where(x => x.Work.Contains("WORK") == false).OrderByDescending(x => x.Id).First();
                }
                catch
                {

                }
                //ищем место хранения номенклатуры
                if (LastDvig.NomenklaturaPlace!= null && LastDvig.NomenklaturaPlace.Count>0)
                {
                    try
                    {
                        NomenklaturaPlace NP = db.NomenklaturaPlace.Where(x => x.DvigenieId == LastDvig.Id).Include(x=>x.Stellag).Include(x=>x.Yacheika).First();
                      //  NP.Stellag = db.Planogramma.Where(x => x.Id == NP.StellagId).First();
                      //  LastDvig.NomenklaturaPlace = new List<NomenklaturaPlace>();
                      //  LastDvig.NomenklaturaPlace.Add(NP);
                    }
                    catch (Exception e)
                    {

                    }
                }
                //Ищем родителя последнего движения
                if (LastDvig.Parent != 0)
                {
                    try
                    {
                        Parent = AllDvigenies.Where(x => x.Id == LastDvig.Parent).First();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    if (Dvigenies.Count > 1)
                    {
                        Parent = Dvigenies[Dvigenies.Count - 2];
                    }
                }





                int MaxIdChild = 0;
                
                foreach (Dvigenie D in Dvigenies)
                {
                    try
                    {
                        Childrens.AddRange(AllDvigenies.Where(x => x.Parent == D.Id&&x.Otmena==false).ToList());
                    }
                    catch
                    {

                    }
                }
                if (Childrens!=null && Childrens.Count>0)
                {
                    MaxIdChild = Childrens.Max(x => x.Id);
              //      if (MaxIdChild > MaxId)
               //     {
               //         MaxId = MaxIdChild;
              //      }
                    LastDvigChild = AllDvigenies.Where(x => x.Id == MaxIdChild).First();
                }
                else
                {
                    LastDvigChild = LastDvig;
                }

                if (LastDvigChild.Parent != 0)
                {
                    //Ищем родителя последнего Child
                    try
                    {
                        LastDvigChildParent = AllDvigenies.Where(x => x.Id == LastDvigChild.Parent).First();
                    }
                    catch
                    {

                    }
                }
                else
                {

                }
               
              

                Dvigenies.AddRange(Childrens);//Добавляем детей в движение
                Dvigenies = Dvigenies.OrderBy(x => x.Id).ToList();
            }
            catch (Exception e)
            {

            }

            try
            {
                QTY = LastDvig.QTYFact;
               
            }
            catch
            {

            }
        }

    }
}