namespace MySQL_Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVorundNachnamen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BehandlerPatientenTermin", "PatientenVorname", c => c.String(unicode: false));
            AddColumn("dbo.BehandlerPatientenTermin", "PatientenNachname", c => c.String(unicode: false));
            AddColumn("dbo.BehandlerPatientenTermin", "BehandlerVorname", c => c.String(unicode: false));
            AddColumn("dbo.BehandlerPatientenTermin", "BehandlerNachname", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BehandlerPatientenTermin", "BehandlerNachname");
            DropColumn("dbo.BehandlerPatientenTermin", "BehandlerVorname");
            DropColumn("dbo.BehandlerPatientenTermin", "PatientenNachname");
            DropColumn("dbo.BehandlerPatientenTermin", "PatientenVorname");
        }
    }
}
