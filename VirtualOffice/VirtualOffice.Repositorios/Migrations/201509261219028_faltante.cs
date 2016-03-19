namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faltante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Direccion_Ciudad", c => c.String(maxLength: 50));
            AddColumn("dbo.Clientes", "Direccion_Provincia", c => c.String(maxLength: 50));
            AddColumn("dbo.Clientes", "Direccion_Distrito", c => c.String(maxLength: 50));
            AddColumn("dbo.Clientes", "Direccion_Ubicacion", c => c.String(maxLength: 100));
            DropColumn("dbo.Clientes", "Direccion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Direccion", c => c.String());
            DropColumn("dbo.Clientes", "Direccion_Ubicacion");
            DropColumn("dbo.Clientes", "Direccion_Distrito");
            DropColumn("dbo.Clientes", "Direccion_Provincia");
            DropColumn("dbo.Clientes", "Direccion_Ciudad");
        }
    }
}
