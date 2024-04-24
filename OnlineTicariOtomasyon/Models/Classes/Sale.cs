using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Sale
    {
        [Key]
        public int SalesId { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Date {  get; set; }
        public int Piece {  get; set; }//adet 
        public decimal Price { get; set; }//fiyat
        public decimal SumPrice {  get; set; }//toplam tutar

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CurrentId {  get; set; }
        public virtual Current Current { get; set; }

        public int EmployeeId {  get; set; }
        public virtual Employee Employee { get; set; }




    }
}