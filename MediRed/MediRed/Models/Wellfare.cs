using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Wellfare
    {
        [Key]
        public int WellfareId { get; set; }

        [Required]
        [Display(Name = "(*) Previsión")]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        public string Name { get; set; }

        public string detail { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}