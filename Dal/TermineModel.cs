namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class TermineModel : DbContext
    {
        // Your context has been configured to use a 'TermineModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Dal.TermineModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TermineModel' 
        // connection string in the application configuration file.
        public TermineModel()
            : base("name=TermineModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

  
}