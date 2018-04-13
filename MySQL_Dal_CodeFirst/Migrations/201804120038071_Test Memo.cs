namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMemo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TerminDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientenID = c.Int(nullable: false),
                        PatientenName = c.String(unicode: false),
                        Memo = c.String(unicode: false),
                        Behandler = c.String(unicode: false),
                        Termin = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TerminDatas");
        }
    }
}
