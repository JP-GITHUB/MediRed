using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        [Display(Name = "Detalle")]
        public string Detail { get; set; }
    }
}
