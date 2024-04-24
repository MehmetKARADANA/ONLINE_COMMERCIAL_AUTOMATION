using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeImage { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


    }
}