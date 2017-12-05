using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Patient: Person
    {
        public string Diagnostic { get; set; }
        public string Treatment { get; set; }
    }
}