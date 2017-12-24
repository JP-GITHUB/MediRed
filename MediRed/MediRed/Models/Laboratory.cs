using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Laboratory
    {
        [Key]
        public int LaboratoryId { get; set; }

        [Required]
        [Display(Name = "Nombre Laboratorio")]
        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(200, ErrorMessage = "Campo no puede superar los 200 caracteres.")]
        public string Description { get; set; }

        public virtual ICollection<Technologist> Technologist { get; set; }
    }
}