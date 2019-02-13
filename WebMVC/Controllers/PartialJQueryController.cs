using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.DataBaseModels;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PartialJQueryController : Controller
    {
        // GET: PartialJQuery
        public ActionResult Index()
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

        public ActionResult ShowEmployee(int EmployeeId)
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();            

            List<EmployeeViewModel> employeeList = db.Employee.Where(x => x.IsDeleted == false && x.EmployeeID == EmployeeId).Select(x => new EmployeeViewModel
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                EmployeeID = x.EmployeeID,
                Name = x.Name
            }).ToList();

            ViewBag.EmployeeList = employeeList;

            return PartialView("PartialExample");
        }

        public ActionResult AddEditEmployee(int EmployeeId)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            List<Department> departmentList = db.Department.ToList();
            ViewBag.DepartmentList = new SelectList(departmentList, "DepartmentID", "DepartmentName");

            if (EmployeeId > 0)
            {
                WebMVC.DataBaseModels.Employee employee = db.Employee.SingleOrDefault(x => x.EmployeeID == EmployeeId);

                employeeViewModel = new EmployeeViewModel
                {
                    EmployeeID = employee.EmployeeID,
                    Address = employee.Address,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.Department.DepartmentName,
                    Name = employee.Name,
                    SiteName = employee.Name
                };
            }

            return PartialView("AddEditEmployee", employeeViewModel);
        }
        
        [HttpPost]
        public ActionResult Index(EmployeeViewModel employeeVM)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<Department> listDep = db.Department.ToList();
            ViewBag.DepartmentList = new SelectList(listDep, "DepartmenId", "DepartmentName");


            if(employeeVM.EmployeeID>0)
            {
                WebMVC.DataBaseModels.Employee employee = db.Employee.SingleOrDefault(x => x.EmployeeID == employeeVM.EmployeeID);

                employee.Address = employeeVM.Address;
                employee.DepartmentId = employeeVM.DepartmentId;
                employee.Name = employeeVM.Name;
                db.SaveChanges();
            }
            else
            {
                WebMVC.DataBaseModels.Employee employee = new DataBaseModels.Employee();
                employee.DepartmentId = employeeVM.DepartmentId;
                employee.Address = employeeVM.Address;
                employee.Name = employeeVM.Name;
                employee.Sites = employee.Sites;
                db.Employee.Add(employee);
                db.SaveChanges();
            }

            return View();
        }
    }
}