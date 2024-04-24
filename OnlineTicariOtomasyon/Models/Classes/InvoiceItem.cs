using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public int Amount { get; set; }//miktar
        public decimal UnitPrice { get; set; }
        public decimal SumItemPrice { get; set; }

        public int InvoiceId {  get; set; }
        public virtual Invoice invoice { get; set; }

        

    }
}