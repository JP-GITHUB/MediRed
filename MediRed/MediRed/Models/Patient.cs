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
        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        [Display(Name = "Diagnóstico")]
        public string Diagnostic { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name = "Tratamiento")]
        public string Treatment { get; set; }
    }
}