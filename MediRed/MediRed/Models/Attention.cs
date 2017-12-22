using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Attention
    {
        [Key]
        public int AttentionId { get; set; }

        public string Detail { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public int DiagnosticId { get; set; }

        public virtual Diagnostic Diagnostic { get; set; }

        // Falta la relaccion de examenes Muchos a Muchos
        public virtual ICollection<Exam> Exams { get; set; }

        public bool NewAttention()
        {
            return true;
        }

    }
}