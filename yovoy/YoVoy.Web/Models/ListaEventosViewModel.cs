using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoVoy.Web.Models
{
    public class ListaEventosViewModel
    {
        public int EventoId { get; set; }
        public string Titulo { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
    }
}
