namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDatumUhrzeitfromBehandlerTerminePatienten : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BehandlerPatientenTermin", "Datum");
            DropColumn("dbo.BehandlerPatientenTermin", "Uhrzeit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BehandlerPatientenTermin", "Uhrzeit", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.BehandlerPatientenTermin", "Datum", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
