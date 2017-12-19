using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Medic: Person
    {
        public Speciality Speciality { get; set; }
    }   

}