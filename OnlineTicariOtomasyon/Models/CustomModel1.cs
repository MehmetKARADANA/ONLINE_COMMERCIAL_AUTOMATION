using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class CustomModel1
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductDetail> Details { get; set; }
    }
}