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

    public class WorkView
    {

        public int PlanshetId = 0;
        public int MaxVipusk =0;
        public string OgranichenieVipuskaPrichina = "";
        public ComputerNames Planshet = new ComputerNames();
        public ICMO WORK = new ICMO();
        public StarMehWorks StarWork = new StarMehWorks();
        public List<string> Vipusheno = new List<string>();
        public PPBOM BOM = new PPBOM();
        public List<PPBOMEntry> BE = new List<PPBOMEntry>();

        public List<DvigenieNEW> SOUTs = new List<DvigenieNEW>();
        public List<NZPNEW> NZPs = new List<NZPNEW>();
        public List<ICInventory> Inventory = new List<ICInventory>();
        public List<ICStockBillEntry> CINs = new List<ICStockBillEntry>();
        public List<ICStockBillEntry> SOUTS = new List<ICStockBillEntry>();
        public List<BomEntry> BOMEntrys = new List<BomEntry>();
        public List<StarMehWorks> SMWorks = new List<StarMehWorks>();
        public DateTime D = DateTime.Now;

        public t_Item Item = new t_Item();

        public t_Stock StockBase = new t_Stock();


    }
       
}