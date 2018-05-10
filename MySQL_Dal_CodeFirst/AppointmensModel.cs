namespace MySQL_Dal_CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Domain.Models;

    public class AppointmensModel : DbContext
    {
        // Your context has been configured to use a 'AppointmensModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MySQL_Dal_CodeFirst.AppointmensModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AppointmensModel' 
        // connection string in the application configuration file.
        public AppointmensModel()
            : base("name=AppointmensModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<TerminData> Termine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }

  }