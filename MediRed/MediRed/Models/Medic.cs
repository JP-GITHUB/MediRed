using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediRed.Models
{
    [Table("Medic")]
    public class Medic: Person
    {
        //[Key]
        //public int MedicId { get; set; }

        public int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        public int AtentionCenterId { get; set; }

        public virtual AtentionCenter AtentionCenter { get; set; }
    }   

}