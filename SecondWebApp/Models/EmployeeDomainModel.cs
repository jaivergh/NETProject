using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondWebApp.Models
{
    public class EmployeeDomainModel
    {
        public int EmployeeID { get; set; }
        
        public string Name { get; set; }
        
        //public string Address { get; set; }
        
        public Nullable<int> DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
        public string SiteName { get; set; }
        public bool IsDeleted { get; set; }

        public int ExtraProperty { get; set; }
        public int ExtraProperty2 { get; set; }
        public DateTime currentDate { get; set; }
    }
}