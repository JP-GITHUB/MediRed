using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }

        public int Personid { get; set; }

        public virtual Patient Patient { get; set; }

        public string PatientName { get; set; }

        public string ClientIdentification { get; set; }

        public string ClientBloodType { get; set; }

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