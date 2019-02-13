using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.Name = "Camilo";
            List<string> list = new List<string>();
            list.Add("Camilo");
            list.Add("Mario");
            list.Add("Juan");
            list.Add("Jose");

            ViewBag.List = list;

            return View();
        }
    }
}