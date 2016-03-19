namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rutasalternas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Url");
        }
    }
}
