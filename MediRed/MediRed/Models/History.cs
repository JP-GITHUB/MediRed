using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class History
    {
        public int Personid { get; set; }

        public virtual Person Person { get; set; }

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