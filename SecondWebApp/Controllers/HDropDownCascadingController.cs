using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class HDropDownCascadingController : Controller
    {
        // GET: HDropDownCascading
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId","CountryName");

            return View();
        }

        public List<Country> GetCountryList()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();

            List<Country> countries = db.Country.ToList();

            return countries;
        }

        public ActionResult GetStatesList(int countryID)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<State> states = db.State.Where(x=>x.CountryId==countryID).ToList();
            ViewBag.StateList = new SelectList(states, "StateId", "StateName");
            return PartialView("StateOptionPartial");
        }
    }
}