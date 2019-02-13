using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.DataBaseModels;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class JQueryAjaxController : Controller
    {
        // GET: JQueryAjax
        public ActionResult Index()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();

            List<Department> departmentList = db.Department.ToList();
            ViewBag.DepartmentList = new SelectList(departmentList, "DepartmentID", "DepartmentName");

            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeViewModel employeeViewModel)
        {
            try
            {
                MVCDataBaseEntities db = new MVCDataBaseEntities();


                List<Department> departmentList = db.Department.ToList();
                ViewBag.DepartmentList = new SelectList(departmentList, "DepartmentID", "DepartmentName");

                if (ModelState.IsValid)
                {
                    DataBaseModels.Employee e = new DataBaseModels.Employee
                    {
                        Address = employeeViewModel.Address,
                        DepartmentId = employeeViewModel.DepartmentId,
                        Name = employeeViewModel.Name
                    };

                    db.Employee.Add(e);
                    db.SaveChanges();

                    int idEmp = e.EmployeeID;

                    DataBaseModels.Sites EmployeeSite = new DataBaseModels.Sites
                    {
                        EmployeeId = idEmp,
                        SiteName = employeeViewModel.SiteName
                    };

                    db.Sites.Add(EmployeeSite);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return View(employeeViewModel);
        }
    }
}