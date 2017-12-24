using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class History
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HistoryId { get; set; }

        public int Id { get; set; }

        public virtual Patient Patient { get; set; }

        public string PatientName { get; set; }

        public string ClientIdentification { get; set; }

        public string ClientBloodType { get; set; }

        public bool Hypertension { get; set; }

        public bool Diabetes { get; set; }

        public virtual ICollection<Attention> Attencions { get; set; }

        public bool GetMorbility()
        {
            return true;
        }

        public bool GetBloodType()
        {
            return true;
        }
    }
}