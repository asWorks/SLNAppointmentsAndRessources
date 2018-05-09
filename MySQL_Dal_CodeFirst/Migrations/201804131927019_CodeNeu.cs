namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeNeu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TerminDatas", "BehandlerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TerminDatas", "BehandlerID");
        }
    }
}
