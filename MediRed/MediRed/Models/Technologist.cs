using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Technologist: Person
    {
        public Speciality SpecialityTech { get; set; }
        public Laboratory LabWork { get; set; }
    }
}       