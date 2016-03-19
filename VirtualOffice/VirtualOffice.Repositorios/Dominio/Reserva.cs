using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOffice.Repositorios.Dominio
{
    public class Reserva : Entidad
    {
        public int ClienteId { get; set; }
        public int LocalId { get; set; }
        public int SalaId { get; set; }
        public int Participantes { get; set; }
        public string Indicaciones { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public virtual Cliente Cliente { get; set; }

        
        public Reserva(int clienteId, int localId,
            int salaId, int participantes, string indicaciones,
            DateTime inicio, DateTime fin)
        {
            // TODO: Complete member initialization
            this.ClienteId = clienteId;
            this.LocalId = localId;
            this.SalaId = salaId;
            this.Participantes = participantes;
            this.Indicaciones = indicaciones;
            this.Inicio = inicio;
            this.Fin = fin;
        }

        public Reserva()
        {

        }
    }
}
