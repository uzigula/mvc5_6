namespace VirtualOffice.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuariopersonalizado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Area", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropColumn("dbo.AspNetUsers", "Area");
        }
    }
}
