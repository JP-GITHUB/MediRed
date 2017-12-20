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
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name="Apellidos")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        public string ContactEmail { get; set; }

        [Display(Name="Teléfono")]
        public int ContactNumber{ get; set; }
        
        public int? IdCountry { get; set; }

        [ForeignKey("IdCountry")]
        public virtual Country Country { get; set; }

    }
}