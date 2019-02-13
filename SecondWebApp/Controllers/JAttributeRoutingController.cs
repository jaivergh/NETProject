using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/***
 * First enable it in RouteConfig
 * "routes.MapMvcAttributeRoutes()"
 * 
 ***/
namespace SecondWebApp.Controllers
{      
    /***
     * Route prefix for all
     ***/
    [RouteArea("City")]    //All going to begin with area/prefix
    [RoutePrefix("Prefix")]
    [Route("{action=Index}")]  //Default
    public class JAttributeRoutingController : Controller
    {
        // GET: JAttributeRouting

        public string Index()
        {
            return "Hola";
        }

        [Route("Student")]
        public string getStudent()
        {
            return "Todos los estudiantes de la base de datos";
        }

        [Route("Student/{studentId}")]
        public string getStudent(int studentId)
        {
            return "Estudiante con Id: " + studentId;
        }

        /***
         * Make it optional
         ***/
        [Route("Student/Name/{Name?}")]
        public string getStudent(string Name)
        {
            return "Estudiante con nombre: " + Name;
        }

        /***
         * Default value
         ***/
        [Route("Student/LastName/{lastName=Smith}")]
        public string getStudentLastname(string lastName)
        {
            return "Estudiante con apellido: " + lastName;
        }
        [Route("Student/StudentByAge/{age:int:min(18):max(90)}")]
        public string getStudentByAge(int age)
        {
            return "todos los estudiantes con edad: " + age;
        }

        [Route("Student/StudentByAge/{age}")]
        public string getStudentByAge(string age)
        {
            return "todos los estudiantes con edad: " + age;
        }
    }
}