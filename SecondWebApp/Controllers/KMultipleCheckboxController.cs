using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class KMultipleCheckboxController : Controller
    {
        // GET: KMultipleCheckbox
        public ActionResult Index()
        {
            List<Shop> shops = new List<Shop>();
            shops.Add(new Shop { ItemId = 1, ItemName = "Prestobarba", IsAvailable = true });
            shops.Add(new Shop { ItemId = 2, ItemName = "Computador", IsAvailable = false });
            shops.Add(new Shop { ItemId = 3, ItemName = "Talco", IsAvailable = true });
            shops.Add(new Shop { ItemId = 4, ItemName = "Crema para peinar", IsAvailable = false });
            shops.Add(new Shop { ItemId = 5, ItemName = "pastillas", IsAvailable = true });

            ViewBag.ShopList = shops;

            return View();
        }

        [HttpPost]
        public JsonResult SaveList(string ItemList)
        {
            string[] arrayItems = ItemList.Split(',');

            foreach(string itemStrId in arrayItems)
            {
                int currentId = int.Parse(itemStrId);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}