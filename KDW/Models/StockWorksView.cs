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

 
    public class StockWorksView
    {

      
        public StockWorkEntrys SWE = new StockWorkEntrys();
        public decimal QTYFromStock = 0;
        public decimal QTYToStock = 0;
        public decimal QTYInQR = 0;
        public decimal MAXPeremestit = 0;
        public decimal NugnoPeremestit = 0;
    
    }
}