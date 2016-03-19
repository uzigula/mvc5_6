namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DocumentIdentidad = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Reservas", "ClienteId");
            AddForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Reservas", new[] { "ClienteId" });
            DropTable("dbo.Clientes");
        }
    }
}
