using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        [Display(Name = "(*) Nombre")]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]

        public string Name { get; set; }

        [Required]
        [Display(Name = "(*) Concentración")]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        public string Concentration { get; set; }

        [Display(Name = "(*) Descripción")]
        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        public string Description { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}