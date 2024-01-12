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

 
    public class WorkNeed
    {

        public t_Item Item;
        public StarMehWorks SW = new StarMehWorks();
        public PlanoviWorks PW = new PlanoviWorks();
        public ICMO Work = new ICMO();
        public decimal QTY = 0;
        public decimal QTYFact = 0;
    
    }
}