using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }

        [Required]
        public string Detail { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}