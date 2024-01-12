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


    public class BomEntry
    {
        public decimal QTYNeedWork = 0;
        public decimal QTYNeedToday = 0;
        public decimal QTYOstalosToday = 0;
        public decimal QTYOstalosWork = 0;
        public decimal QTYMAXWork = 0;
        public decimal QTYFact = 0;
        public decimal NZPQty = 0;
        public decimal CINQty = 0;
        public decimal QTYScrap = 0;
        public decimal ESTVQR = 0;
        public decimal QTYMUST = 0;
        public decimal QTYFACT = 0;
        public decimal QTYNEED = 0;
        public decimal QTYNEEDQR = 0;
        public int WORKID = 0;
        public int MognoVipustit = 0;
        public int VipushenoSegodnya = 0;
        public int NugnoVipustitSegodnya = 0;
        public int VipushenoVsego = 0;

        public List<NZPNEW> NZPs = new List<NZPNEW>();
        public List<NZP> NZPOld = new List<NZP>();
        public List<ICInventory> Inventorys = new List<ICInventory>();
        public t_Item Item = new t_Item();

    }

       
}