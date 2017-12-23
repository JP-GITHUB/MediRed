using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    [Table("Patient")]
    public class Patient: Person
    {
        [Required]
        [StringLength(10, ErrorMessage = "Campo no puede superar los 10 caracteres.")]
        [Display(Name = "Tipo de Sangre")]
        public string BloodType { get; set; }
                
        public int WellfareId { get; set; }

        public virtual Wellfare Wellfare { get; set; }
    }
}