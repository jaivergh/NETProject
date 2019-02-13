using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class BRegistrationJQueryController : Controller
    {
        // GET: BRegistrationJQuery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegisterUser(RegistrationViewModel registrationViewModel)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            bool result = false;

            SiteUser siteUser = new SiteUser();
            siteUser.Address = registrationViewModel.Address;
            siteUser.EmailId = registrationViewModel.EmailId;
            siteUser.Password = registrationViewModel.Password;
            siteUser.RoleId = 3;
            siteUser.UserName = registrationViewModel.UserName;
            try
            {
                db.SiteUser.Add(siteUser);
                db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}