using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Technologist: Person
    {
        public MedicalSpeciality SpecialityTech { get; set; }
    }
}