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
        public int AtentionCenterId { get; set; }

        [Required]
        [Display(Name = " (*) Dirección")]
        [StringLength(100, ErrorMessage = "La dirección ingresada no es válida", MinimumLength = 6)]
        public string Address { get; set; }

        [Required]
        [Display(Name = " (*) Teléfono")]
        public int PhoneCener { get; set; }

        public int ProviderId { get; set; }

        public virtual Provider Provider {get; set;}

        public virtual ICollection<Medic> Medic { get; set; }
    }

}