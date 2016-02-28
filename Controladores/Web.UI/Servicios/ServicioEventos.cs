using System;
using System.Collections.Generic;
using System.Linq;
using Web.UI.Models;

namespace Web.UI.Servicios
{
    public class ServicioEventos
    {
        private List<EventosListaViewModel> eventos;

        public ServicioEventos()
        {
            eventos = new List<EventosListaViewModel>()
            {
                new EventosListaViewModel
                {
                    Nombre = ".Net Meetup",
                    Descripcion = "Meetup del Mes de Marzo, Key Note Sobre AKKA .Net",
                    Fecha = new DateTime(2016,3,15),
                    Lugar = "Barranco Beer Company",
                    Nota = "Llevar Laptop y algo de comer"
                },
                new EventosListaViewModel
                {
                    Nombre = "JavaScript Meetup",
                    Descripcion = "Meetup del Mes de Marzo, Key Note Sobre angular2",
                    Fecha = new DateTime(2016,3,16),
                    Lugar = "Barranco Beer Company",
                    Nota = "Llevar Laptop y algo de comer"
                },
                new EventosListaViewModel
                {
                    Nombre = "Ruby Meetup",
                    Descripcion = "Meetup del Mes de Marzo, Key Note RSSpec y BDD",
                    Fecha = new DateTime(2016,3,28),
                    Lugar = "Barranco Beer Company",
                    Nota = "Llevar Laptop y algo de comer"
                }
            };
        }
        internal List<EventosListaViewModel> Buscar(string busqueda)
        {
            return eventos.Where(p=>
                    p.Nombre.IndexOf(busqueda, StringComparison.CurrentCultureIgnoreCase)!=-1 ||
                    p.Descripcion.IndexOf(busqueda, StringComparison.CurrentCultureIgnoreCase)!=-1 ||
                    p.Lugar.IndexOf(busqueda, StringComparison.CurrentCultureIgnoreCase)!=-1 ||
                    p.Nota.IndexOf(busqueda, StringComparison.CurrentCultureIgnoreCase)!=-1
                    ).ToList();
        }
    }
}