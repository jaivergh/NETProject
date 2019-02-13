using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondWebApp.Models;

/***
 * Para instalar AutoMapper ir a References - > NuggetPackages -> search automapper
 ***/
namespace SecondWebApp.Controllers
{
    public class QAutoMapperController : Controller
    {
        // GET: QAutoMapper
        public ActionResult Index()
        {
            MVCDataBaseEntities db = new MVCDataBaseEntities();
            List<Department> listDep = db.Department.ToList();

            ViewBag.DepartmentList = new SelectList(listDep,"DepartmenId","DepartmentName");

            List<EmployeeDomainModel> listEmployeeDM = db.Employee.Select(x => new EmployeeDomainModel {
                //Address = x.Address,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
                EmployeeID = x.EmployeeID,
                ExtraProperty=10,
                ExtraProperty2=20,
                currentDate=DateTime.Now
            }).ToList();


            List<EmployeeViewModel> listEmployeeVM = new List<EmployeeViewModel>();
            AutoMapper.Mapper.Map(listEmployeeDM, listEmployeeVM);

            ViewBag.EmployeeVMList = listEmployeeVM;

            return View();
        }
    }
}