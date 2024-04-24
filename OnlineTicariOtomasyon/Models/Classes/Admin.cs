using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminName {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string AdminPassword { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Authority { get; set; }
    }
}