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


    public class DvigeniesView
    {

        public DvigenieNEW Dvig = new DvigenieNEW();
        public List<DvigenieNEW> Childrens = new List<DvigenieNEW>();
        public DvigenieNEW Parent = new DvigenieNEW();
        public DvigenieNEW Start = new DvigenieNEW();
        public DvigenieNEW End = new DvigenieNEW();
        public ProverkaOTK ProverkaOTK = new ProverkaOTK();
        public List<NZPNEW> NZP = new List<NZPNEW>();
        public ZakazPostavshiku Zakaz = new ZakazPostavshiku();
    

    }
       
}