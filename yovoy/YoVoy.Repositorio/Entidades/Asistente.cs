using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoVoy.Repositorio.Entidades
{
    public class Asistente : Entidad
    {
        public string Nombre { get; set; }
        public Evento Evento { get; set; }
        public int EventoId { get; set; }
    }
}
