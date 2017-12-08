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
        public int LabId { get; set; }

        [Display(Name = "Nombre Laboratorio")]
        public string NameLab { get; set; }

        [Display(Name = "Dirección")]
        public string DirLab { get; set; }

        //[Display(Name = "Especialidad Médica")]
        //public MedicalSpeciality MedicalSpeciality { get; set; }

        [Display(Name = "Teléfono")]
        public int PhoneLab { get; set; }
    }
}