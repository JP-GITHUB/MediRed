using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediRed.Models
{
    public abstract class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name="Apellidos")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        public string Email { get; set; }

        [Display(Name="Teléfono")]
        public int Phone{ get; set; }
        
        public int? IdCountry { get; set; }

        [ForeignKey("IdCountry")]
        public virtual Country Country { get; set; }

    }
}