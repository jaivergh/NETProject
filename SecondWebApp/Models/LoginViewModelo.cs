using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondWebApp.Models
{
    public class LoginViewModelo
    {
        [Required(ErrorMessage ="Por favor ingrese el emilio")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la contraseña")]
        public string Password { get; set; }
    }
}