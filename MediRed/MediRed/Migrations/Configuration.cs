namespace MediRed.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MediRed.Context.MediRedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
<<<<<<< HEAD
            ContextKey = "MediRed.Context.MediRedContext";
            AutomaticMigrationDataLossAllowed = true;
=======
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MediRed.Context.MediRedContext";
>>>>>>> 610c351f6f7f7f2dca59feed4e695c294e281069
        }

        protected override void Seed(MediRed.Context.MediRedContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
