using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.UI.Models
{
    public class BuscarEventoViewModel
    {
        public BuscarEventoViewModel()
        {
            Eventos = new List<EventosListaViewModel>();
        }
        public string Busqueda { get; set; }
        public List<EventosListaViewModel> Eventos { get; internal set; }
    }
}
