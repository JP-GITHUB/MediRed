using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class History
    {
        public Patient Patient { get; set; }
        public Diagnostic Diagnostic { get; set; }
        public AtentionCenter AtentionCenter { get; set; }

    }
}