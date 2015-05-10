using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = false, Duration = 0)]
        public String GetTime()
        {
            Thread.Sleep(3000);
            return DateTime.Now.ToString();
        }

        public ActionResult GetJson()
        {
            Thread.Sleep(3000);
            Console.Write("OK");
            return Json(new { result = "OK" });
        }
    }
}