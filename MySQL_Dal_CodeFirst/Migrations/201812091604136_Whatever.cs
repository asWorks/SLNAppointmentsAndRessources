namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Whatever : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TestPeopleX");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestPeopleX",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForeName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
