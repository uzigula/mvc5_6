using System;

namespace Web.UI.Models
{
    public class EventosListaViewModel
    {
        public string Descripcion { get; internal set; }
        public DateTime Fecha { get; internal set; }
        public string Lugar { get; internal set; }
        public string Nombre { get; internal set; }
        public string Nota { get; internal set; }
    }
}