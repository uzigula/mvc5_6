using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoVoy.Servicios.Dtos
{
    public class EventoDto
    {
        public int EventoId { get; set; }
        public string Titulo { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
        public UsuarioDto Organizador { get; set; }
        public IEnumerable<AsistenteDto> Asistentes { get; set; }
    }
}
