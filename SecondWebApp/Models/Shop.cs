using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondWebApp.Models
{
    public class Shop
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public bool IsAvailable { get; set; }
    }
}