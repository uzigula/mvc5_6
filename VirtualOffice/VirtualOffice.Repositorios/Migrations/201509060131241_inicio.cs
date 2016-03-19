namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        LocalId = c.Int(nullable: false),
                        SalaId = c.Int(nullable: false),
                        Participantes = c.Int(nullable: false),
                        Indicaciones = c.String(),
                        Inicio = c.DateTime(nullable: false),
                        Fin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservas");
        }
    }
}
