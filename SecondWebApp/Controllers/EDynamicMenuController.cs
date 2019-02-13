using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class EDynamicMenuController : Controller
    {
        // GET: EDynamicMenu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SideMenu()
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            listMenu.Add(new MenuItem { Link = "/ABootstrapGrid/Index", LinkName = "Grid" });
            listMenu.Add(new MenuItem { Link = "/BRegistrationJQuery/Registration", LinkName = "Registrarse" });
            listMenu.Add(new MenuItem { Link = "/CLoginJQuery/Index", LinkName = "Iniciar Sesion" });
            listMenu.Add(new MenuItem { Link = "/FUploadImage/Index", LinkName = "Subir Imagenes" });

            listMenu.Add(new MenuItem { Link = "/GUploadImageByUrl/Index", LinkName = "Subir Imagenes Url" });
            listMenu.Add(new MenuItem { Link = "/HDropDownCascading/Index", LinkName = "Drop Down" });
            listMenu.Add(new MenuItem { Link = "/ISearchRecord/Index", LinkName = "Buscar Empleado" });


            listMenu.Add(new MenuItem { Link = "/City/Prefix/Student/", LinkName = "Ruteador" });
            listMenu.Add(new MenuItem { Link = "/KMultipleCheckbox/Index", LinkName = "CheckBox" });

            listMenu.Add(new MenuItem { Link = "/LSortablePhotoGallery/Index", LinkName = "Galeria organizable" });
            listMenu.Add(new MenuItem { Link = "/MAutocompleteTextbox/Index", LinkName = "Autocompletado de texto" });
            listMenu.Add(new MenuItem { Link = "/NSendEmail/Index", LinkName = "Enviar correos electronicos" });
            listMenu.Add(new MenuItem { Link = "/OJQueryDataTables/Index", LinkName = "DataTable" });
            listMenu.Add(new MenuItem { Link = "/PSendOTP/Index", LinkName = "Enviar OTP (one time password)" });

            return PartialView("SideMenu", listMenu);
        }
    }
}