using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOffice.Servicios.Reservas.Dtos
{
    public class ReservaDto
    {
        public int ClienteId { get; set; }
        public int LocalId { get; set; }
        public int SalaId { get; set; }
        public int Participantes { get; set; }
        public string Indicaciones { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
