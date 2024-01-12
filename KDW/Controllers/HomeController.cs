using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDW.Filters;
using KDW.Models;
using KDW.Controllers;
using System.Data.Entity;
using System.Net;

namespace KDW.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        // PersonContext db = new PersonContext();
        private KingDeeDB db = new KingDeeDB();
        private AIS20141015154903Entities ProdDB = new AIS20141015154903Entities();
        public ActionResult Login()
        {
            DateTime Date = DateTime.Now.AddMonths(-6);

            Session["Roles"] = null;
            // Session["CurrentUser"] = null;
            Session["CurrentUserId"] = null;
            Session["CurrentDepartment"] = null;
            Session["CurrentDepartmentId"] = null;
            Session["CurrentDepartmentIdArray"] = null;
            Session["CurrentUserKDWModel"] = null;
            Session["Stocks"] = null;

            HttpCookie cookie = Request.Cookies["CurrentUser"];
         //   HttpCookie UserModel = Request.Cookies["CurrentUserModel"];
         //   HttpCookie UserRoles = Request.Cookies["CurrentUserRoles"];
            if (cookie != null)
            { 
                cookie = null;
            }

            AutocompleteSearchUser("");
            AutocompleteSearchDepartment("");
            

            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            string compname = Environment.MachineName.ToString();
            string compname2 = Request.UserHostAddress;
            string compname3 = Request.LogonUserIdentity.Name.ToString();
  

            ViewBag.Comp1 = compname;
            ViewBag.Comp2 = compname2;
            ViewBag.Comp3 = compname3;
            ViewBag.Host = hostName;
            return View();

        }

        public void AddToEnterLog(UsersKDW U)
        {
            
            string hostName = Request.UserHostAddress; // Retrive the Name of HOST  
            string compname = Request.LogonUserIdentity.Name.ToString();
            

            EnteryLogs EL = new EnteryLogs();
            EL.IPAdress = hostName;
            EL.Name = compname;
            EL.WebUserName = U.Name;
            EL.WebUserId = U.Id;
            EL.KingDeeUserName = "ItemName=" + U.t_Item.FName + " BaseUser=" + U.t_Base_User.FName;
            EL.EnterDate = DateTime.Now;
            try
            {
                db.EnteryLogs.Add(EL);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

        public UsersKDW FindCurrentKDWUser(bool Fast = false)
        {
            UsersKDW U = new UsersKDW();

            int UserId = 0;
            HttpCookie userCookie = HttpContext.Request.Cookies["CurrentUser"];
            if (userCookie != null)
            {
                try
                {
                    UserId = Convert.ToInt32(userCookie.Value);
                }
                catch
                {

                }
            }
            else
            {
                RedirectToAction("Login", "Home");
            }

            if (UserId > 0)
            {

                if (!Fast)
                {

                    try
                    {

                        U = db.UsersKDW.Where(x => x.Id == UserId).Include(x => x.t_Base_User).Include(x => x.t_Item).Include(x => x.DepartmentsToUsers).Include(x => x.KingDeeWebRoles).First();
                    }
                    catch
                    {
                        RedirectToAction("Login", "Home");

                    }
                }
                else
                {
                    try
                    {
                        U = db.UsersKDW.Where(x => x.Id == UserId).First();
                    }
                    catch
                    {
                        RedirectToAction("Login", "Home");
                    }
                }

            }
            else
            {


            }

            return U;
        }

        public JsonResult ProverkaParolya(string Login, int Password)
        {
            int Result = 0;
            int C = 0;
            
            UsersKDW U = new UsersKDW();
            try
            {
               U = db.UsersKDW.Include(x => x.t_Base_User).Include(x=>x.t_Item).Include(x=>x.DepartmentsToUsers).Include(x=>x.KingDeeWebRoles).Where(x => x.Name.Equals(Login) && x.Password == Password).First();
               Session["CurrentUserKDWModel"] = U;

                HttpCookie cookie = Request.Cookies["CurrentUser"];
                if (cookie != null)
                    cookie.Value = U.Id.ToString();    // если куки уже установлено, то обновляем значение
                else
                {

                    cookie = new HttpCookie("CurrentUser");
                    cookie.HttpOnly = false;
                    cookie.Value = U.Id.ToString();
                    cookie.Expires = DateTime.Now.AddYears(1);
                }
                Response.Cookies.Add(cookie);
                AddToEnterLog(U);

            }
            catch
            {

            }
            if (U.Id!=0)
            {
                Result = U.Id;
            }
            else
            {
                Result = 0;
            }
                return Json(Result);
        }

        public string FindCurrentUser()
        {
            string User = "";
            UsersKDW U = new UsersKDW();
          
            /*     if (Session["CurrentUser"] != null)
                 {
                     User = (string)Session["CurrentUser"];
                 }
                 else
                 {

                 }
            */
            HttpCookie userCookie = HttpContext.Request.Cookies["user"];
            if (userCookie != null)
            {
                User = userCookie.Value;
               
                try
                {
                    

                    if (Session["CurrentUserKDWModel"] == null)
                    {
                        int UID = Convert.ToInt32(User);

                        U = db.UsersKDW.Include(x => x.t_Base_User).Include(x => x.t_Item).Include(x => x.DepartmentsToUsers).Include(x => x.KingDeeWebRoles).Where(x => x.Id == UID).First();
                        Session["CurrentUserKDWModel"] = U;
                    }
                    else
                    {
                        U = (UsersKDW)Session["CurrentUserKDWModel"];
                    }
             
                }
                catch
                {

                }
                // cultureCookie.SameSite = SameSiteMode.Lax;
            }
            else
            {
                RedirectToAction("Login", "Home");
            }

            if (U.Id==0)
            {
                RedirectToAction("Login", "Home");
                User = "";
            }
            else
            {
                User = U.Name;
            }

            return User ;
        }

        public List<string> FindCurrentRoles()
        {
            List<string> Roles = new List<string>();
            if (Session["Roles"] != null)
            {
                Roles = (List<string>)Session["Roles"];
            }
            else
            {
                try
                {

                    int UserId = FindCurrentKDWUser(true).Id;
                    //   t_Item U = db.t_Item.Where(x => x.FName.Equals(User)).First();

                  //  List<KingDeeWebRoles> WR = ;
                    Roles = db.KingDeeWebRoles.Where(x => x.UserId == UserId).Include(x => x.WebRoles).Select(x => x.WebRoles.Name).ToList();
                    Session["Roles"] = Roles;
                }
                catch
                {

                }
            }

            return Roles;
        }



        public ActionResult Index()
        {
            DateTime Date = DateTime.Now.AddMonths(-6);
            AutocompleteSearchUser("");
            int a = FindCurrentKDWUser(true).Id;
            if (a == 0)
            {
                return RedirectToAction("Login");
            }
            bool ObnovitPOOrder = false;
            bool ObnovitICMO = false;
            ObnovitPOOrder= testPOOrder();
            ObnovitICMO = testICMO();
            ViewBag.ObnovitPOOrder = ObnovitPOOrder;
            ViewBag.ObnovitICMO = ObnovitICMO;
            ViewBag.Roles = FindCurrentRoles();
         //   AutocompleteSearchStorage("");

          //  @ViewBag.CurrentUser = CurrentUser();
         //   db.t_Item.Where(x => x.FItemClassID == 3 && x.FName.Contains(term)
      
        //    ViewBag.Managers = Names;
            //  var Zakazi = db.POOrder.Where(x => x.FDate >= Date).ToList();
            return View();

        }

        

        public ActionResult Proizvodstvo()
        {
            int a = FindCurrentKDWUser(true).Id;
            if (a==0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Roles = FindCurrentRoles();
            ViewBag.IPAdress = Request.UserHostAddress; // Retrive the Name of HOST  
            ViewBag.CompName = Request.LogonUserIdentity.Name.ToString();
            return View();

        }

        public ActionResult Admins()
        {
            int a = FindCurrentKDWUser(true).Id;
            if (a == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Roles = FindCurrentRoles();
            return View();

        }

        public ActionResult YZ()
        {
            int a = FindCurrentKDWUser(true).Id;
            if (a == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Roles = FindCurrentRoles();
            ViewBag.IPAdress = Request.UserHostAddress; // Retrive the Name of HOST  
            ViewBag.CompName = Request.LogonUserIdentity.Name.ToString();
            return View();

        }

        public List<Control> FindLastStatusesOTK(int Count, int UserId =0)
        {
            List<Control> Dvigs = new List<Control>();
            List<Control> Result = new List<Control>();
            try
            {
              
               Dvigs = db.Control.Include(x => x.Dvigenie.Item).Where(x=>x.Dvigenie.QRID!=null).OrderByDescending(x => x.Id).Take(100).Include(x=>x.Dvigenie).Include(x=>x.StatusOTK).Include(x=>x.Dvigenie.UsersKDW).ToList();
                List<int> D = Dvigs.Select(x=>x.Dvigenie.QRID.Value).Distinct().ToList();
                int C = 0;
                foreach (var d in D)
                {
                    try
                    {
                        Result.Add(Dvigs.Where(x => x.Dvigenie.QRID == d).First());


                        C++;
                        if (C == Count)
                        {
                            break;
                        }
                    }
                    catch
                    {

                    }
                }


            }
            catch (Exception e)
            {

            }
            if (UserId > 0 && Result.Count > 0)
            {
                try
                {
                    Result = Result.Where(x => x.UserId == UserId).ToList();
                }
                catch
                {
                    Result = new List<Control>();
                }
            }
            return (Result);
        }

        [Culture]
        public ActionResult SkladskoiUchet()
        {
            string a = CurrentUserNow();
            if (a.Equals(""))
            {
                return RedirectToAction("Login");
            }
            List<Control> Dvigs = FindLastStatusesOTK(5);
            ViewBag.Dvigs = Dvigs;
            

            ViewBag.Roles = FindCurrentRoles();
            ViewBag.IPAdress = Request.UserHostAddress; // Retrive the Name of HOST  
            ViewBag.CompName = Request.LogonUserIdentity.Name.ToString();
            return View();

        }

        public ActionResult LastStatuses()
        {
            List<Control> Dvigs = FindLastStatusesOTK(100);
            ViewBag.Dvigs = Dvigs;
            return View();

        }

     

        public JsonResult CurrentUser ()
        {
            
           string User = CurrentUserNow();
            return Json(User, JsonRequestBehavior.AllowGet);
        }

        public string CurrentUserNow()
        {
            string User = "";
            /*   if (Session["CurrentUser"] != null)
               {
                   User = (string)Session["CurrentUser"];
               }
               else
               {

               }
            */
            User =FindCurrentUser();
            return User;
        }

        public JsonResult AutocompleteSearchDepartment(string term)
        {

            List<string> Result = new List<string>();
            if (Session["Departments"] == null)
            {
                //Получаем всех пользаков
                Result = db.t_Item.Where(x => x.FItemClassID == 2) // && x.FName.Contains(term)
                            .Select(a => a.FName)
                            .Distinct().ToList();

                //Сохраняем в сессию чтобы все было свеженькое
                Session["Departments"] = Result;


            }
            else
            {//Загружаем из сессии
                Result = (List<string>)Session["Departments"];


            }
            try
            {
                Result = Result.Where(x => x.Contains(term)).ToList();
            }
            catch
            {
                Result = new List<string>();
            }
            if (Result.Count == 0)
            {
                Result.Add(Resources.Resource.PoZaprosuNeNaideno);
            }
            return Json(Result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult AutocompleteSearchStorage(string term)
        {
            List<string> Result = new List<string>();
            if (Session["Stocks"] == null)
            {
                //Получаем всех пользаков
                Result = db.t_Stock
                            .Select(a => a.FName)
                            .Distinct().ToList();
              
                //Сохраняем в сессию чтобы все было свеженькое
                Session["Stocks"] = Result;


            }
            else
            {//Загружаем из сессии
                Result = (List<string>)Session["Stocks"];
            }
            try
            {
                Result = Result.Where(x => x.Contains(term)).ToList();
            }
            catch
            {
                Result = new List<string>();
            }

            if (Result.Count == 0)
            {
                Result.Add(Resources.Resource.PoZaprosuNeNaideno);
            }

            return Json(Result, JsonRequestBehavior.AllowGet);





            ///   var models = db.t_Stock.Where(x => x.FName.Contains(term))
            //                    .Select(a => new { value = a.FName })
            //                   .Distinct();

            //   return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CurrentDepartment()
        {
            string User = "";
            if (Session["CurrentDepartment"] != null)
            {
                User = (string)Session["CurrentDepartment"];
            }
            else
            {

            }
            return Json(User, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SetUser(string User)
        {
            Session["CurrentUser"] = User;
           
            return Json(User, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetDepartment(string User)
        {
            Session["CurrentDepartment"] = User;

            return Json(User, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Planovi()
        {
            return View();
        }
        public JsonResult AutocompleteSearchUser(string term)
        {

            List<string> Result = new List<string>();
            if (Session["Users"] == null)
            {
                //Получаем всех пользаков
                /*       Result = db.t_Item.Where(x => x.FItemClassID == 3) // && x.FName.Contains(term)
                                   .Select(a => a.FName)
                                   .Distinct().ToList();
                */
                term = term.ToLower();
                Result = db.UsersKDW.Where(x => x.Name.ToLower().Contains(term)).Select(x=>x.Name).ToList();

                //Сохраняем в сессию чтобы все было свеженькое
                Session["Users"] = Result;


            }
            else
            {//Загружаем из сессии
                Result = (List<string>)Session["Users"];


            }
            try
            {
                Result = Result.Where(x => x.Contains(term)).ToList();
            }
            catch
            {
                Result = new List<string>();
            }
            if (Result.Count == 0)
            {
                Result.Add(Resources.Resource.PoZaprosuNeNaideno);
            }
            return Json(Result, JsonRequestBehavior.AllowGet);

        }


        public bool testPOOrder()
        {
            bool Go = false;
            try
            {
                int maxProd = ProdDB.ICMaxNum.Where(x => x.FTableName.Equals("POOrder")).First().FMaxNum.Value;
                int maxTest = db.ICMaxNum.Where(x => x.FTableName.Equals("POOrder")).First().FMaxNum.Value;
                if (maxProd != maxTest)
                {
                    Go = true;
                }
            }
            catch
            {

            }
            return Go;
        }

        public bool testICMO()
        {
            bool Go = false;
            try
            {
                int maxProd = ProdDB.ICMaxNum.Where(x => x.FTableName.Equals("ICMO")).First().FMaxNum.Value;
                int maxTest = db.ICMaxNum.Where(x => x.FTableName.Equals("ICMO")).First().FMaxNum.Value;
                if (maxProd != maxTest)
                {
                    Go = true;
                }
            }
            catch
            {

            }
            return Go;
        }





        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "zh" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }

            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        public JsonResult ChangeCultureJson(string lang)
        {
            //string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            string Soobshit = lang;

            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
            {
                try
                {
                    cookie.Value = lang;   // если куки уже установлено, то обновляем значение
                    cookie.SameSite = SameSiteMode.Strict;
                    Soobshit = "Ok";
                }
                catch (Exception e)
                {
                    Soobshit = e.Message;
                }
            }
            else
            {
                try
                {
                    cookie = new HttpCookie("lang");
                    cookie.HttpOnly = true;
                    cookie.Value = lang;
                    cookie.Expires = DateTime.Now.AddYears(1);
                    cookie.SameSite = SameSiteMode.Strict;
                    Soobshit = "Ok";
                }
                catch (Exception e)
                {
                    Soobshit = e.Message;
                }
            }
            Response.Cookies.Add(cookie);
            return Json(Soobshit,JsonRequestBehavior.AllowGet);
        }
    }
}