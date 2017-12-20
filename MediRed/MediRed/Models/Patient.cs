using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Patient: Person
    {
        [Required]
        [StringLength(10, ErrorMessage = "Campo no puede superar los 10 caracteres.")]
        [Display(Name = "Tipo de Sangre")]
        public string BloodType { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name = "Previsión")]
        public string Welfare { get; set; }
    }
}