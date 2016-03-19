namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "NombreUsuario", c => c.String(nullable:false, maxLength:50));
            CreateIndex("dbo.Clientes","NombreUsuario",true,"UK_NombreUsuario");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", "UK_NombreUsuario");
            DropColumn("dbo.Clientes", "NombreUsuario");
        }
    }
}
