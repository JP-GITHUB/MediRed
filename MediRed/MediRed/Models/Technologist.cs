using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    [Table("Technologist")]
    public class Technologist: Person
    {
        //[Key]
        //public int TechnologistId { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        [Required]
        public int LaboratoryId { get; set; }

        public virtual Laboratory Laboratory { get; set; }
    }
}       