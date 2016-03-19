namespace VirtualOffice.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForzarCambioDePassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DebeCambiarPassword", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DebeCambiarPassword");
        }
    }
}
