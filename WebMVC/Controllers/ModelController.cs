using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            List<Employee> listaEmpleados = new List<Employee>();
            Employee emp = new Employee();
            emp.EmployeeID = 1;
            emp.Department = "IT";
            emp.Name = "Adolfo";
            listaEmpleados.Add(emp);


            listaEmpleados.Add(new Employee { EmployeeID = 2, Name = "Pedro", Department = "IT" });
            listaEmpleados.Add(new Employee { EmployeeID = 3, Name = "Juan", Department = "Soporte" });
            listaEmpleados.Add(new Employee { EmployeeID = 4, Name = "Camilo", Department = "RH" });
            listaEmpleados.Add(new Employee { EmployeeID = 5, Name = "Ester", Department = "IT" });

            return View(listaEmpleados);
        }
    }
}