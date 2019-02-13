using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.DataBaseModels;

namespace WebMVC.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult Index()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            Employee employee = db.Employee.SingleOrDefault(x => x.EmployeeID == 2);

            Models.EmployeeViewModel employeeVM = new Models.EmployeeViewModel();
            employeeVM.EmployeeID = employee.EmployeeID;
            employeeVM.Address = employee.Address;
            employeeVM.DepartmentId = employee.DepartmentId;
            employeeVM.Name = employee.Name;

            return View(employeeVM);
        }

        public ActionResult EmployeesInfo()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<Employee> employeeList = db.Employee.ToList();

            List<Models.EmployeeViewModel> employeeVMList = employeeList.Select(x => new Models.EmployeeViewModel
            {
                Name = x.Name,
                EmployeeID = x.EmployeeID,
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName
            }).ToList();

            return View(employeeVMList);
        }

        public ActionResult EmployessList()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<Employee> employeeList = db.Employee.ToList();

            List<Models.EmployeeViewModel> employeeVMList = employeeList.Select(x => new Models.EmployeeViewModel
            {
                Name = x.Name,
                EmployeeID = x.EmployeeID
            }).ToList();

            return View(employeeVMList);
        }

        public ActionResult EmployeeDetails(int employeeId)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            Employee employee = db.Employee.SingleOrDefault(x => x.EmployeeID == employeeId);
            Models.EmployeeViewModel employeeViewModel = new Models.EmployeeViewModel();
            employeeViewModel.EmployeeID = employee.EmployeeID;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.DepartmentId = employee.DepartmentId;
            employeeViewModel.Name = employee.Name;
            employeeViewModel.DepartmentName = employee.Department.DepartmentName;
            return View(employeeViewModel);
        }
    }
}