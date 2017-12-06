using System.ComponentModel.DataAnnotations;

namespace MediRed.Models
{
    public class Diagnostic
    {
        [Key]
        public int DiagnosticId { get; set; }
        public string NameDiagnostic { get; set; }
        public string Description { get; set; }
    }
}       