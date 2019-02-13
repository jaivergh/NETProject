using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/***
 * Para esto necesito descargar jqueryui: https://jqueryui.com/download/
 ***/
namespace SecondWebApp.Controllers
{
    public class LSortablePhotoGalleryController : Controller
    {
        // GET: LSortablePhotoGallery
        public ActionResult Index()
        {
            return View();
        }
    }
}