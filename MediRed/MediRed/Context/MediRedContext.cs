using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MediRed.Context
{
    public class MediRedContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MediRedContext() : base("name=MediRedContext")
        {
        }

        public System.Data.Entity.DbSet<MediRed.Models.Medicine> Medicines { get; set; }

        public System.Data.Entity.DbSet<MediRed.Models.AtentionCenter> AtentionCenters { get; set; }

        public System.Data.Entity.DbSet<MediRed.Models.Laboratory> Laboratories { get; set; }

        public System.Data.Entity.DbSet<MediRed.Models.Speciality> MedicalSpecialities { get; set; }

        public System.Data.Entity.DbSet<MediRed.Models.Patient> Patient { get; set; }

        public System.Data.Entity.DbSet<MediRed.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<MediRed.Models.Medic> Medics { get; set; }
    }
}
