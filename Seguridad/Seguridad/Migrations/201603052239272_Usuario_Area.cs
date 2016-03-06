namespace Seguridad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario_Area : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Area");
        }
    }
}
