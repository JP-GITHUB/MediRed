using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Concentración")]
        public string Concentration { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}