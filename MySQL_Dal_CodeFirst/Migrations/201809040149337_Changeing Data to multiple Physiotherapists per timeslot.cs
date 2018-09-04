namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeingDatatomultiplePhysiotherapistspertimeslot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BehandlerPatientenTermin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false, precision: 0),
                        Uhrzeit = c.DateTime(nullable: false, precision: 0),
                        BehandlerID = c.Int(nullable: false),
                        Termin = c.DateTime(nullable: false, precision: 0),
                        MandantID = c.Int(nullable: false),
                        RezeptID = c.Int(nullable: false),
                        istVergeben = c.Boolean(nullable: false),
                        istAusgefuehrt = c.Boolean(nullable: false),
                        test = c.Boolean(nullable: false),
                        PatientenID = c.Int(nullable: false),
                        PatientenName = c.String(unicode: false),
                        BehandlerName = c.String(unicode: false),
                        TerminData_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TerminData", t => t.TerminData_ID)
                .Index(t => t.TerminData_ID);
            
            DropColumn("dbo.TerminData", "PatientenID");
            DropColumn("dbo.TerminData", "PatientenName");
            DropColumn("dbo.TerminData", "Memo");
            DropColumn("dbo.TerminData", "BehandlerID");
            DropColumn("dbo.TerminData", "Behandler");
            DropColumn("dbo.TerminData", "Mandant");
            DropColumn("dbo.TerminData", "RezeptID");
            DropColumn("dbo.TerminData", "istVergeben");
            DropColumn("dbo.TerminData", "istAusgeführt");
            DropColumn("dbo.TerminData", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TerminData", "test", c => c.Boolean(nullable: false));
            AddColumn("dbo.TerminData", "istAusgeführt", c => c.Boolean(nullable: false));
            AddColumn("dbo.TerminData", "istVergeben", c => c.Boolean(nullable: false));
            AddColumn("dbo.TerminData", "RezeptID", c => c.Int(nullable: false));
            AddColumn("dbo.TerminData", "Mandant", c => c.Int(nullable: false));
            AddColumn("dbo.TerminData", "Behandler", c => c.String(unicode: false));
            AddColumn("dbo.TerminData", "BehandlerID", c => c.Int(nullable: false));
            AddColumn("dbo.TerminData", "Memo", c => c.String(unicode: false));
            AddColumn("dbo.TerminData", "PatientenName", c => c.String(unicode: false));
            AddColumn("dbo.TerminData", "PatientenID", c => c.Int(nullable: false));
            DropForeignKey("dbo.BehandlerPatientenTermin", "TerminData_ID", "dbo.TerminData");
            DropIndex("dbo.BehandlerPatientenTermin", new[] { "TerminData_ID" });
            DropTable("dbo.BehandlerPatientenTermin");
        }
    }
}
