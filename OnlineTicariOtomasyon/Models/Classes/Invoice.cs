using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Invoice
    {

        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6,ErrorMessage ="6 karakter ile sınırlı...")]
        public string OrderNo { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1,ErrorMessage="Tek karakter ile sınırlı...")]
        public string SerialNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public String TaxAdministration {  get; set; }

        //[Column(TypeName = "char")]
        //[StringLength(5)]
        //public String Hour  { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer {  get; set; }//teslim eden

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set;}//teslim alan

        public decimal SumInvoice { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set;}//1 den n e

    }
}