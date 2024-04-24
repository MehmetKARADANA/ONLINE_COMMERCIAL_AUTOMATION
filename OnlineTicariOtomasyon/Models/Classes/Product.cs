using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public   int ProductId {  get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock {  get; set; }
        public decimal PurchasePrice {  get; set; }
        public decimal SalePrice {  get; set; }
        public bool State {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image {  get; set; }
        public int CategoryId {  get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}