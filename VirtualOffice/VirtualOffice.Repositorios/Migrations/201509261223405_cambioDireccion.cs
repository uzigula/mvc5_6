namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioDireccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Direccion_Calle", c => c.String(maxLength: 100));
            AddColumn("dbo.Sucursals", "Direccion_Calle", c => c.String(maxLength: 100));
            DropColumn("dbo.Clientes", "Direccion_Ubicacion");
            DropColumn("dbo.Sucursals", "Direccion_Ubicacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sucursals", "Direccion_Ubicacion", c => c.String(maxLength: 100));
            AddColumn("dbo.Clientes", "Direccion_Ubicacion", c => c.String(maxLength: 100));
            DropColumn("dbo.Sucursals", "Direccion_Calle");
            DropColumn("dbo.Clientes", "Direccion_Calle");
        }
    }
}
