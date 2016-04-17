using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoVoy.Web.Models
{
    public class EventoDetalleViewModel
    {
        public int EventoId { get; set; }
        public string Titulo { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public DateTime Cuando { get; set; }
        public OrganizadorEvento Organizador { get; set; }
        public bool InscripcionesAbiertas { get; set; }
        public IEnumerable<AsistenteEvento> Asistentes { get; set; }
    }

    public class OrganizadorEvento
    {
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string InformacionAdicional { get; set; }
    }

    public class AsistenteEvento
    {
        public string Nombre { get; set; }
    }
}
