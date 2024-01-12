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


  

    public class DayView
    {


       
        public List<StarMehWorks> SW = new List<StarMehWorks>();

        public List<SmenaHour> SH = new List<SmenaHour>();
        public string PlanshetName = "";
        public DateTime D = DateTime.Now;

       


    }
       
}