using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }

        [Required]
        [Display(Name = "Descripción Especialidad")]
        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        public string Description { get; set; }

        public virtual ICollection<Medic> Medic { get; set; }

        public virtual ICollection<Technologist> Technologist { get; set; }
    }
}