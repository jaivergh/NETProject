using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class DMultipleModelsInViewController : Controller
    {
        // GET: DMultipleModelsInView
        public ActionResult Index()
        {
            List<ModelA> listModelA = new List<ModelA>();
            List<ModelB> listModelB = new List<ModelB>();

            listModelA.Add(new ModelA { Name = "Juan" });
            listModelA.Add(new ModelA { Name = "Jose" });
            listModelA.Add(new ModelA { Name = "Pegro" });

            listModelB.Add(new ModelB { Country = "Colombia" });
            listModelB.Add(new ModelB { Country = "Peru" });
            listModelB.Add(new ModelB { Country = "Mexico" });

            ModelC modelC = new ModelC();
            modelC.modelAs = listModelA;
            modelC.modelBs = listModelB;
            modelC.Age = 27;

            return View(modelC);
        }
    }
}