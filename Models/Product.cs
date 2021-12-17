using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace drumcenterworld.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int AvailableQty { get; set; }
        public decimal Price { get; set; }
    }
}