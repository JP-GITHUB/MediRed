using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class AtentionCenter
    {
        [Key]
        public int CenterId { get; set; }
        public string NameCenter { get; set; }
        public string  DirCenter { get; set; }
        public int PhoneCener { get; set; }
    }

}