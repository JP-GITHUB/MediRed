using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Exam
    {
        public int ExamId { get; set; }

        public string Detail { get; set; }

        public bool Result { get; set; }

        public int PersonId { get; set; }

        public virtual Technologist Technologist { get; set; }

        public virtual ICollection<Attention> Attentions { get; set; }
    }
}