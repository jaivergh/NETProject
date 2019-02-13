using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="Por favor ingrese su nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Por favor escoja un departamento")]
        public Nullable<int> DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su sitio web")]
        public string SiteName { get; set; }
    }
}