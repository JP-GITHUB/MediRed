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
        public string NameLab { get; set; }
        public string DirLab { get; set; }
        public MedicalSpeciality MedicalSpeciality { get; set; }
        public int PhoneLab { get; set; }
    }
}