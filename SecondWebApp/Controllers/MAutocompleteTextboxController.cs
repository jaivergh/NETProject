using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondWebApp.Models;

namespace SecondWebApp.Controllers
{
    public class MAutocompleteTextboxController : Controller
    {
        // GET: MAutocompleteTextbox
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetSuggestions(string text)
        {
            List<Shop> shops = new List<Shop>();
            shops.Add(new Shop { ItemId = 1, ItemName = "Casa", IsAvailable = true });
            shops.Add(new Shop { ItemId = 2, ItemName = "Caandado", IsAvailable = true });
            shops.Add(new Shop { ItemId = 3, ItemName = "Pastilla", IsAvailable = true });
            shops.Add(new Shop { ItemId = 4, ItemName = "Teclado", IsAvailable = true });
            shops.Add(new Shop { ItemId = 5, ItemName = "Caja", IsAvailable = true });
            shops.Add(new Shop { ItemId = 6, ItemName = "Letra", IsAvailable = true });
            shops.Add(new Shop { ItemId = 7, ItemName = "Tablet", IsAvailable = true });
            shops.Add(new Shop { ItemId = 8, ItemName = "Estropajo", IsAvailable = true });
            shops.Add(new Shop { ItemId = 9, ItemName = "Repisa", IsAvailable = true });
            shops.Add(new Shop { ItemId = 10, ItemName = "Crema para peinar", IsAvailable = true });
            shops.Add(new Shop { ItemId = 11, ItemName = "Seda dental", IsAvailable = true });
            shops.Add(new Shop { ItemId = 12, ItemName = "Cepillo", IsAvailable = true });
            shops.Add(new Shop { ItemId = 13, ItemName = "Jabón", IsAvailable = true });
            shops.Add(new Shop { ItemId = 14, ItemName = "Agenda", IsAvailable = true });

            List<string> listWords = new List<string>();
            listWords = shops.Where(x => x.ItemName.ToLower().Contains(text.ToLower())).Select(x => x.ItemName).ToList();

            return Json(listWords, JsonRequestBehavior.AllowGet);
        }
    }
}