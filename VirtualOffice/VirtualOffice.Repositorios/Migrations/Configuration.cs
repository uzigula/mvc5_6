using System.Collections.Generic;
using FileHelpers;
using VirtualOffice.Repositorios.DDDContext;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.Dominio.Componentes;

namespace VirtualOffice.Repositorios.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFVirtualOfficeRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFVirtualOfficeRepository context)
        {
            context.Sucursales.AddOrUpdate(new Sucursal()
                {
                    Nombre = "Torre1",
                    Direccion =
                        new Direccion()
                        {
                            Ciudad = "Lima",
                            Distrito = "Miraflores",
                            Provincia = "Lima",
                            Calle = "Av. Benavides 2345"
                        },
                    Salas = new List<Dominio.Sala>()
                    {
                        new Sala()
                        {
                            Nombre = "Amazonas",
                            Capacidad = 100,
                            Caracteristicas = "Multiple"
                        },
                        new Sala()
                        {
                            Nombre = "Machupicchu",
                            Capacidad = 250,
                            Caracteristicas = "Multiple"
                        },
                        new Sala()
                        {
                            Nombre = "Nazca",
                            Capacidad = 25,
                        }
                    }
                }, new Sucursal()
                {
                    Nombre = "Torre2",
                    Direccion =
                        new Direccion()
                        {
                            Ciudad = "Lima",
                            Distrito = "Jesus María",
                            Provincia = "Lima",
                            Calle = "Av. Salaverry 1234"
                        },
                    Salas = new List<Dominio.Sala>()
                    {
                        new Sala()
                        {
                            Nombre = "Neptuno",
                            Capacidad = 150,
                            Caracteristicas = "Multiple"
                        },
                        new Sala()
                        {
                            Nombre = "Jupiter",
                            Capacidad = 350,
                            Caracteristicas = "Multiple"
                        },
                        new Sala()
                        {
                            Nombre = "Mercurio",
                            Capacidad = 50,
                        }
                    }
                }, new Sucursal()
                {
                    Nombre = "Torre3",
                    Direccion =
                        new Direccion()
                        {
                            Ciudad = "Lima",
                            Distrito = "Surco",
                            Provincia = "Lima",
                            Calle = "Av. Primavera 2345"
                        },
                    Salas = new List<Dominio.Sala>()
                    {
                        new Sala()
                        {
                            Nombre = "Turin",
                            Capacidad = 100,
                            Caracteristicas = "Multiple"
                        },
                        new Sala()
                        {
                            Nombre = "Tesla",
                            Capacidad = 250,
                            Caracteristicas = "Multiple"
                        },
                        new Sala()
                        {
                            Nombre = "Galileo",
                            Capacidad = 150,
                        },
                    }
                });

            context.Clientes.AddOrUpdate(new Cliente()
            {
                Nombre = "Acme CIA",
                DocumentoIdentidad = "20124252628",
                ContactoCargo = "Manager",
                ContactoNombre = "Cliente de Prueba",
                Fax = "519787874",
                NombreUsuario = "cliente@mailinator.com",
                Telefono = "518758754",
                Direccion = new Direccion()
                {
                    Ciudad = "Lima",
                    Distrito = "Miraflores",
                    Provincia = "Lima",
                    Calle = "Comandante Espinar 1234"
                }
            });
        }
    }
}
