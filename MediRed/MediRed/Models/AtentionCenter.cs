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

        [Display(Name = "Nombre del Centro")]
        public string NameCenter { get; set; }

        [Display(Name = "Dirección")]
        public string  DirCenter { get; set; }

        [Display(Name = "Teléfono")]
        public int PhoneCener { get; set; }
    }

}