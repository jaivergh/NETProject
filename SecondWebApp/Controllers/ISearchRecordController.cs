using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    public class ISearchRecordController : Controller
    {
        // GET: ISearchRecord
        public ActionResult Index()
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<EmployeeViewModel> listEmployees = db.Employee.Select(x => new EmployeeViewModel
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                EmployeeID = x.EmployeeID,
                Name = x.Name,
                DepartmentName = x.Department.DepartmentName
            }).ToList();

            ViewBag.ListEmployees = listEmployees;

            return View();
        }

        public ActionResult GetSearchRecord(string SearchWord)
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();

            List<EmployeeViewModel> employeeViewModels = db.Employee.Where(x => x.Name.Contains(SearchWord) || x.Department.DepartmentName.Contains(SearchWord)).Select(x => new EmployeeViewModel
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                EmployeeID = x.EmployeeID,
                Name = x.Name,
                DepartmentName = x.Department.DepartmentName
            }).ToList();
            return PartialView("SearchEmployeePartial",employeeViewModels);
        }
    }
}