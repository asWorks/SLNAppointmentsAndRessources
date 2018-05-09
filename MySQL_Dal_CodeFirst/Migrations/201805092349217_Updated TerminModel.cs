namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTerminModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TerminDatas", "Mandant", c => c.Int(nullable: false));
            AddColumn("dbo.TerminDatas", "RezeptID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TerminDatas", "RezeptID");
            DropColumn("dbo.TerminDatas", "Mandant");
        }
    }
}
