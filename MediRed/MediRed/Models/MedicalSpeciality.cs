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
        public string NameSpeciality { get; set; }
    }
}