using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class CLoginJQueryController : Controller
    {
        // GET: CLoginJQuery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogInUser(LoginViewModelo loginViewModelo)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            string result = "Error";
            SiteUser siteUser = db.SiteUser.SingleOrDefault(m => m.EmailId == loginViewModelo.EmailId &&
            m.Password == loginViewModelo.Password);

            if (siteUser != null)
            {
                Session["UserId"] = siteUser.UserId;
                Session["UserName"] = siteUser.UserName;

                if (siteUser.RoleId == 3)
                {
                    result = "GeneralUser";
                }
                else if (siteUser.RoleId == 2)
                {
                    result = "SuperAdmin";
                }
                else if (siteUser.RoleId == 1)
                {
                    result = "Admin";
                }

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult LogOutUser(RegistrationViewModel registrationViewModel)
        {
            bool result = false;

            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}