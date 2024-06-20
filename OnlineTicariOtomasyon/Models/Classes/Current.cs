using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "30 Karakterden uzun olamaz")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="30 Karakterden uzun olamaz")]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentMail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrrentPassword { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public bool State {  get; set; }
    }
}