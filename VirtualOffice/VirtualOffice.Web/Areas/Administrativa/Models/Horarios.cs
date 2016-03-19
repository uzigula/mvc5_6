using System;
using System.Collections.Generic;

namespace VirtualOffice.Web.Areas.Administrativa.Models
{
    public class HorarioItem
    {
        public TimeSpan Inicio { get; set; }
        public String InicioFormateado { get { return Inicio.ToString(@"hh\:mm"); } }
        public TimeSpan Fin { get; set; }
        public String FinFormateado { get { return Fin.ToString(@"hh\:mm"); } }

        public string TimeInterval
        {
            get { return string.Format("{0} - {1}", Inicio.ToString(@"hh\:mm"), Fin.ToString(@"hh\:mm")); }
        }

        public int Index { get; set; }
    }

    public class Horario
    {
        private TimeSpan intervalo;
        private TimeSpan horaInicial;
        private TimeSpan horaFinal;
        private int intervalos;

        public Horario()
        {
            horaInicial = new TimeSpan(8, 0, 0);
            horaFinal = new TimeSpan(20, 0, 0);
            intervalo = new TimeSpan(0, 30, 0);
            intervalos = (int)(horaFinal - horaInicial).TotalMinutes / 30;
        }

        public IEnumerable<HorarioItem> ObtenerHorario()
        {
            var horario = new List<HorarioItem>();
            var intervaloActual = horaInicial;
            for (var i = 0; i <= intervalos; i++)
            {
                horario.Add(new HorarioItem
                {
                    Index = i,
                    Inicio = intervaloActual,
                    Fin = intervaloActual.Add(intervalo)
                });
                intervaloActual = intervaloActual.Add(intervalo);
            }

            return horario;
        }
    }

}