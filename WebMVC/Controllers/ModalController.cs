using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.DataBaseModels;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ModalController : Controller
    {
        // GET: Modal
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

        public ActionResult EmployeeList()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();

            List<Department> departmentList = db.Department.ToList();
            ViewBag.DepartmentList = new SelectList(departmentList, "DepartmentID", "DepartmentName");

            List<EmployeeViewModel> employeeList = db.Employee.Where(x => x.IsDeleted == false).Select(x => new EmployeeViewModel
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                EmployeeID = x.EmployeeID,
                Name = x.Name
            }).ToList();

            ViewBag.EmployeeList = employeeList;

            return View();
        }

        public JsonResult DeleteEmployee(int EmployeeId)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();

            bool result = false;
            DataBaseModels.Employee emp = db.Employee.SingleOrDefault(x => x.IsDeleted == false && x.EmployeeID == EmployeeId);

            if (emp != null)
            {
                emp.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowPartial ()
        {

            return PartialView("PartialExample");
        }
        
    }
}