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
        public string Name { get; set; }
        public string Concentration { get; set; }
        public string Description { get; set; }
    }
}