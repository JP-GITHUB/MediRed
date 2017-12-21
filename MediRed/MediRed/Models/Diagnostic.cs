using System.ComponentModel.DataAnnotations;

namespace MediRed.Models
{
    public class Diagnostic
    {
        [Key]
        public int DiagnosticId { get; set; }
        
        public string Description { get; set; }

        public bool RedDiagnostic { get; set; }

        public int TreatmentId { get; set; }

        public virtual Treatment Treatment { get; set; }

        public bool ValidateRedDiagnostic()
        {
            return true;
        }
    }
}       