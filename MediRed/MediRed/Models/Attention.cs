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

        // From Person
        public int Id { get; set; }

        public virtual Medic Medic { get; set; }

        public int DiagnosticId { get; set; }

        public virtual Diagnostic Diagnostic { get; set; }

        public int HistoryId { get; set; }

        public virtual History History { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public bool NewAttention()
        {
            return true;
        }

    }
}