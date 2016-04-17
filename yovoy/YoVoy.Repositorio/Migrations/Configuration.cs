using YoVoy.Repositorio.DDDContext;

namespace YoVoy.Repositorio.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YoVoy.Repositorio.Entidades;

    internal sealed class Configuration : DbMigrationsConfiguration<EFYovoyRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFYovoyRepository context)
        {
            //  This method will be called after migrating to the latest version.
            var evento1 = new Evento()
            {
                Id = 1,
                Titulo = "Conferencia JS",
                Descripcion = "Una Charla sobre Promesas en JS",
                Activo = true,
                Lugar = "UPC Faculta de Ciencias",
                Fecha = new DateTime(2015, 10, 8),
                Organizador = new Usuario()
                {
                    Nombre = "Juan Perez",
                    CorreoElectronico = "jperez@juanperez.me",
                    InformacionAdicional = "Developer",
                    NombreCuenta = "@jperez",
                    AfiliadoEn = DateTime.Now

                }
            };
            var evento2 = new Evento()
            {
                Id = 2,
                Titulo = "Conferencia .NET",
                Descripcion = "Como Usar Automapper",
                Activo = true,
                Lugar = "UPC Faculta de Ciencias",
                Fecha = new DateTime(2015, 10, 8),
                Organizador = new Usuario()
                {
                    Nombre = "Uzi Mamani",
                    CorreoElectronico = "hola@uzimamani.me",
                    InformacionAdicional = "Developer",
                    NombreCuenta = "@uzigula",
                    AfiliadoEn = DateTime.Now
                }
            };
            evento2.AddAsistente(new Asistente() { Nombre = "Jorge Gonzales" });
            evento1.AddAsistente(new Asistente() { Nombre = "Jorge Gonzales" });
            context.EventoRepository.Add(evento1);
            context.EventoRepository.Add(evento2);
            context.Commit();
        }
    }
}
