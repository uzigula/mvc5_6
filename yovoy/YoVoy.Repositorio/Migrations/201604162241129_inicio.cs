namespace YoVoy.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        EventoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.EventoId, cascadeDelete: true)
                .Index(t => t.EventoId);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Lugar = c.String(),
                        Descripcion = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CorreoElectronico = c.String(),
                        InformacionAdicional = c.String(),
                        NombreCuenta = c.String(),
                        AfiliadoEn = c.DateTime(nullable: false),
                        Departamento = c.String(),
                        Provincia = c.String(),
                        Distrito = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Asistente", "EventoId", "dbo.Evento");
            DropIndex("dbo.Evento", new[] { "UsuarioId" });
            DropIndex("dbo.Asistente", new[] { "EventoId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Evento");
            DropTable("dbo.Asistente");
        }
    }
}
