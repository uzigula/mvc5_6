namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Salas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Capacidad = c.Int(nullable: false),
                        Caracteristicas = c.String(),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.SucursalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salas", "SucursalId", "dbo.Sucursals");
            DropIndex("dbo.Salas", new[] { "SucursalId" });
            DropTable("dbo.Salas");
        }
    }
}
