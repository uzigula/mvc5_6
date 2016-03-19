namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientesV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Telefono", c => c.String());
            AddColumn("dbo.Clientes", "Fax", c => c.String());
            AddColumn("dbo.Clientes", "ContactoNombre", c => c.String());
            AddColumn("dbo.Clientes", "ContactoCargo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "ContactoCargo");
            DropColumn("dbo.Clientes", "ContactoNombre");
            DropColumn("dbo.Clientes", "Fax");
            DropColumn("dbo.Clientes", "Telefono");
        }
    }
}
