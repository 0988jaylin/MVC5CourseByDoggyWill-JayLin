using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View("View1");
        }

        public ActionResult View1()
        {
            return View("JSAlert");
        }

        public ActionResult File1()
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Pic1.png"));
            return File(content, "image/png");
        }

        public ActionResult File2()
        {

            return File(Server.MapPath("~/Content/Pic1.png"), "image/png");
        }
        public ActionResult File3(string url)
        {
            var wc = new WebClient();
            var content = wc.DownloadData(url);

            return File(content,"image/png");
        }
        public ActionResult File4(string url)
        {
            return File(Server.MapPath("~/Content/File4.htm"), "text/html");
        }
        public ActionResult File5(string url)
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Pic1.png"));
            return File(content, "image/png", "File5.png");
        }
        public ActionResult File6(string url)
        {
            return File(Server.MapPath("~/Content/File4.htm"),"text/plain");
        }

        public ActionResult Json1()
        {
            var data = db.Product.Take(10);
            db.Configuration.LazyLoadingEnabled = false;
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Redirect1()
        {
            return RedirectToAction("File3", new { url = "http://localhost:10681/Content/Pic1.png"});
        }

        public ActionResult Redirect2()
        {
            return RedirectToActionPermanent("File3", new { url = "http://localhost:10681/Content/Pic1.png" });
        }

        public ActionResult HttpNotFound()
        {
            return HttpNotFound();
        }
        public ActionResult HttpBadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}