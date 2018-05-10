namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TerminData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientenID = c.Int(nullable: false),
                        PatientenName = c.String(unicode: false),
                        Memo = c.String(unicode: false),
                        BehandlerID = c.Int(nullable: false),
                        Behandler = c.String(unicode: false),
                        Termin = c.DateTime(nullable: false, precision: 0),
                        Mandant = c.Int(nullable: false),
                        RezeptID = c.Int(nullable: false),
                        istVergeben = c.Boolean(nullable: false),
                        istAusgeführt = c.Boolean(nullable: false),
                        test = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TerminData");
        }
    }
}
