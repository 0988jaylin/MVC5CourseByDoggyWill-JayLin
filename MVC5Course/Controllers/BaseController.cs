using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();
        protected ClientRepository clientRepo = RepositoryHelper.GetClientRepository();
        protected OccupationRepository occuRepo = RepositoryHelper.GetOccupationRepository();

        public ActionResult BaseIndex()
        {
            return View();
        }

#if DEBUG
        public ActionResult Debug()
        {
            return View();
        }
#endif
    }
}