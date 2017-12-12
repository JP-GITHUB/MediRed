using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class MedicalSpeciality
    {
        [Key]
        public int SpecialityId { get; set; }

        [Required]
        [Display(Name = "Nombre Especialidad")]
        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        public string NameSpeciality { get; set; }
    }
}