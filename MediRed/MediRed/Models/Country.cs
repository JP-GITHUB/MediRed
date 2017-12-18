using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        //public ICollection<Person> People { get; set; }
    }
}
