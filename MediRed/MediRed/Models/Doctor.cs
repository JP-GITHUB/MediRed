using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Doctor: Person
    {
        public MedicalSpeciality SpecialityDoc { get; set; }
    }
}