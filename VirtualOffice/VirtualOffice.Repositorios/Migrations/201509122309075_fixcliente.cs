namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "DocumentoIdentidad", c => c.String());
            DropColumn("dbo.Clientes", "DocumentIdentidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "DocumentIdentidad", c => c.String());
            DropColumn("dbo.Clientes", "DocumentoIdentidad");
        }
    }
}
