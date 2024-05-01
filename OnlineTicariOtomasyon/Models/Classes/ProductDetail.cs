using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class ProductDetail
    {
        [Key]
        public int DetailId {  get; set; }
        public int ProductId { get; set; }
        public virtual  Product product { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Explain { get; set; }
    }
} 