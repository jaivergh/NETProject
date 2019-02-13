using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondWebApp.Models
{
    public class ModelC
    {
        public List<ModelA> modelAs { get; set; }
        public List<ModelB> modelBs { get; set; }
        public int Age { get; set; }
    }
}