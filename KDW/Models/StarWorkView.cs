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




    public class StarWorkView
    {


        public ComputerNames Planshet = new ComputerNames();
        public PlanoviWorks PW = new PlanoviWorks();
        public ICMO WORK = new ICMO();
        public StarMehWorks SMWork = new StarMehWorks();
        public t_Item Item = new t_Item();
        public DateTime StartDate = DateTime.Now;//Дата назначения работы на планшет
        public DateTime PlanDate = DateTime.Now;//Дата из плана
        public decimal Proizvedeno = 0;
        public decimal Proizvesti = 0;
        public decimal Raznica = 0;
        public bool Completed = false;
        //public bool FromStarWork = false;



    }
       
}