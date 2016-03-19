namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sucursales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sucursals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion_Ciudad = c.String(maxLength: 50),
                        Direccion_Provincia = c.String(maxLength: 50),
                        Direccion_Distrito = c.String(maxLength: 50),
                        Direccion_Ubicacion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);

            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sucursals");
        }
    }
}
