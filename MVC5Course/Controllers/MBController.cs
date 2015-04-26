using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            Client client = db.Client.Find(100);
            Product product = db.Product.Find(1);

            ViewData.Model = client;
            ViewBag.Product = product;

            return View();
        }

        public ActionResult TempData1()
        {
            ViewData["hello1"] = "hello1 viewdata";
            TempData["hello2"] = "hello2 tempdata";
            Session["hello3"] = "hello3 session";
            return RedirectToAction("TempData2");
        }

        public ActionResult TempData2()
        {
            ViewBag.hello1 = ViewData["hello1"];
            ViewBag.hello2 = TempData["hello2"];
            ViewBag.hello3 = Session["hello3"];
            return View();
        }

        public ActionResult Form1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form1(string username, int age)
        {
            return Content(username + ":" + age);
        }

        public ActionResult Form2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form2(SimpleViewModel item1, SimpleViewModel item2)
        {
            return Content("item1 = " +item1.Username + ":" + item1.Age + ". item2 = " + item2.Username + ":" + item2.Age);
        }


        public ActionResult Form3()
        {
            return View("Form1");
        }

        [HttpPost]
        public ActionResult Form3(FormCollection item)
        {
            return Content(item["Username"] + ":" + item["Age"]);
        }
    }
}