using SecondWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondWebApp.Controllers
{
    /***
     * Descargar paquete JQueryDataTables: https://datatables.net/download/download
     * 
     ***/
    public class OJQueryDataTablesController : Controller
    {
        // GET: OJQueryDataTables
        public ActionResult Index()
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();

            List<Department> listDep = db.Department.ToList();
            ViewBag.DepartmentList = new SelectList(listDep, "DepartmentId", "DepartmentName");

            List<EmployeeViewModel> listEmployeesVM = db.Employee.Where(x => x.IsDeleted == false).Select(x => new EmployeeViewModel
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
                EmployeeID = x.EmployeeID

            }).ToList();

            ViewBag.EmployeeList = listEmployeesVM;

            return View();
        }

        public JsonResult getEmployeeList(DataTablesParam dataTablesParam, string EName)
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<EmployeeViewModel> listEmployeesVM;

            int pageNumber = 1;
            int totalCount = 0;
            if(dataTablesParam.iDisplayStart >= dataTablesParam.iDisplayLength)
            {
                pageNumber = (dataTablesParam.iDisplayStart / dataTablesParam.iDisplayLength) + 1;
            }

            if (dataTablesParam.sSearch != null)
            {
                totalCount = db.Employee.Where(x => x.Name.Contains(dataTablesParam.sSearch)).Count();

                listEmployeesVM = db.Employee
                    .Where(x=>x.Name.Contains(dataTablesParam.sSearch))
                    .OrderBy(x => x.EmployeeID)
                    .Skip((pageNumber - 1) * dataTablesParam.iDisplayLength)
                    .Take(dataTablesParam.iDisplayLength)
                    .Select(x => new EmployeeViewModel
                {
                    Address = x.Address,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.DepartmentName,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    EmployeeID = x.EmployeeID

                }).ToList();

                
            }else if (EName != "")
            {
                totalCount = db.Employee.Where(x => x.Department.DepartmentName.Contains(EName)).Count();

                listEmployeesVM = db.Employee
                    .Where(x => x.Department.DepartmentName.Contains(EName))
                    .OrderBy(x => x.EmployeeID)
                    .Skip((pageNumber - 1) * dataTablesParam.iDisplayLength)
                    .Take(dataTablesParam.iDisplayLength)
                    .Select(x => new EmployeeViewModel
                    {
                        Address = x.Address,
                        DepartmentId = x.DepartmentId,
                        DepartmentName = x.Department.DepartmentName,
                        Name = x.Name,
                        IsDeleted = x.IsDeleted,
                        EmployeeID = x.EmployeeID

                    }).ToList();
            }
            else
            {
                totalCount = db.Employee.Count();

                listEmployeesVM = db.Employee
                    .OrderBy(x=>x.EmployeeID)
                    .Skip((pageNumber-1)* dataTablesParam.iDisplayLength)
                    .Take(dataTablesParam.iDisplayLength)                    
                    .Select(x => new EmployeeViewModel
                {
                    Address = x.Address,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.DepartmentName,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    EmployeeID = x.EmployeeID

                }).ToList();
            }


            return Json(new
            {
                aaData = listEmployeesVM,
                sEcho = dataTablesParam.sEcho,
                iTotalDisplayRecords = totalCount,
                iTotalRecords = totalCount
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(EmployeeViewModel employeeViewModel)
        {
            try
            {
                MVCDataBaseEntities db = new MVCDataBaseEntities();

                List<Department> listDep = db.Department.ToList();
                ViewBag.DepartmentList = new SelectList(listDep, "DepartmentId", "DepartmentName");

                if (employeeViewModel.EmployeeID > 0)
                {
                    Employee employee = db.Employee.SingleOrDefault(x => x.EmployeeID == employeeViewModel.EmployeeID
                    && x.IsDeleted == false);
                    employee.Name = employeeViewModel.Name;
                    employee.DepartmentId = employeeViewModel.DepartmentId;
                    employee.Address = employeeViewModel.Address;
                    db.SaveChanges();
                }
                else
                {
                    Employee employee = new Employee();
                    employee.Name = employeeViewModel.Name;
                    employee.Address = employeeViewModel.Address;
                    employee.DepartmentId = employeeViewModel.DepartmentId;
                    employee.IsDeleted = false;
                    db.Employee.Add(employee);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return View(employeeViewModel);
        }

        public ActionResult AddEditEmployee(int EmployeeId)
        {

            MVCDataBaseEntities db = new MVCDataBaseEntities();

            List<Department> listDep = db.Department.ToList();
            ViewBag.DepartmentList = new SelectList(listDep, "DepartmentId", "DepartmentName");

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            if (EmployeeId > 0)
            {
                Employee employee = db.Employee.SingleOrDefault(x => x.IsDeleted == false && x.EmployeeID == EmployeeId);
                employeeViewModel.EmployeeID = employee.EmployeeID;
                employeeViewModel.Address = employee.Address;
                employeeViewModel.Name = employee.Name;
                employeeViewModel.DepartmentId = employee.DepartmentId;
            }
            return PartialView("Partial2", employeeViewModel);
        }


    }
}