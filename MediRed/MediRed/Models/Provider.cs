using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "Campo no puede superar los 100 caracteres.")]
        public string Name { get; set; }

        public virtual ICollection<AtentionCenter> AtentionCenter { get; set; }
    }
}