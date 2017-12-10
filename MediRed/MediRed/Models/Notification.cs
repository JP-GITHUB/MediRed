using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    public class Notification

    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Patient Patient { get; set; }                        
        public Diagnostic Diagnostic { get; set; }
        public AtentionCenter AtentionCenter { get; set; }
        public Doctor Doctor { get; set; }
    }
}