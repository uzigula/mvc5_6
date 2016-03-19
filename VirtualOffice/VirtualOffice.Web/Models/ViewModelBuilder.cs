using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using VirtualOffice.Web.Areas.Administrativa.Models;

namespace VirtualOffice.Web.Models
{
    internal class ViewModelBuilder
    {
        internal ReservaViewModel ReservaViewModel(ReservaGrabarViewModel reserva)
        {
            var reservaViewModel = new ReservaViewModel();
            reservaViewModel.ClienteId = reserva.ClienteId;
            reservaViewModel.FechaFinal = reserva.FechaFinal;
            reservaViewModel.FechaInicio = reserva.FechaInicio;
            reservaViewModel.HoraFin = reserva.HoraFin;
            reservaViewModel.HoraInicio = reserva.HoraInicio;
            reservaViewModel.Indicaciones = reserva.Indicaciones;
            reservaViewModel.Participantes = reserva.Participantes;
            reservaViewModel.SalaId = reserva.SalaId;

            ConfigurarListas(reservaViewModel);

            return reservaViewModel;
        }
        
        internal ReservaViewModel ReservaViewModel()
        {
            var reserva = new ReservaViewModel();
            ConfigurarListas(reserva);
            return reserva;
        }

        private static void ConfigurarListas(ReservaViewModel reservaViewModel)
        {
            var listaVacia = new List<String>() { "Seleccione.." };
            reservaViewModel.Salas = new SelectList(listaVacia);
            reservaViewModel.Locales = new SelectList(listaVacia);
        }
             

    }
}

