using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class AFController : Controller
    {
        // GET: AF
        public ActionResult Index()
        {
            return View();
        }

        [HandleError]
        public ActionResult ShowError()
        {
            throw new Exception("Error Occured");
            return View();
        }
    }
}