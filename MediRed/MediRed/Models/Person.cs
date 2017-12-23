using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediRed.Models
{
    [Table("Person")]
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name = "(*) Nombres")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name="(*) Apellidos")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Campo no puede superar los 50 caracteres.")]
        [Display(Name = "(*) Email")]
        public string ContactEmail { get; set; }

        [Display(Name="(*) Teléfono")]
        public int ContactNumber{ get; set; }
        
        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

    }
}