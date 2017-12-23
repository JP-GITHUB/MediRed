using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        public string Detail { get; set; }

        public bool Result { get; set; }

        // From Person
        public int Id { get; set; }

        public virtual Technologist Technologist { get; set; }

        public virtual ICollection<Attention> Attentions { get; set; }
    }
}