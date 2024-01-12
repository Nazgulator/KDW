

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KDW.Models;
using MessagingToolkit.QRCode.Codec;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using KDW.Filters;
using KDW.Models;
using System.Runtime;
using System.Globalization;
using System.Web.SessionState;

namespace KDW.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string cultureName = null;
            // Получаем куки из контекста, которые могут содержать установленную культуру
            
            HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
                if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
               // cultureCookie.SameSite = SameSiteMode.Lax;
            }
            else

                cultureName = "zh";

            // Список культур
            List<string> cultures = new List<string>() { "ru",  "zh" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "zh";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //не реализован
        }
    }
}