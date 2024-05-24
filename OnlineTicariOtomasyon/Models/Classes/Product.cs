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
        [Display(Name ="Urun Id")]   
        [Key]
        public   int ProductId {  get; set; }

        [Display(Name = "Name")]
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Display(Name = "Marka")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        [Display(Name = "Stok")]
        public short Stock {  get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal PurchasePrice {  get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice {  get; set; }
        public bool State {  get; set; }

        [Display(Name = "Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image {  get; set; }
        public int CategoryId {  get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}