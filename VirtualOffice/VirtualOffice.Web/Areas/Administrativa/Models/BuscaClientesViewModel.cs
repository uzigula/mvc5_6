using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Areas.Administrativa.Models
{
    public class BuscaClientesViewModel
    {
        public BuscaClientesViewModel()
        {
            Clientes = new List<ClientesListaViewModel>();
        }
        public string Busqueda { get; set; }
        public IEnumerable<ClientesListaViewModel> Clientes { get; set; }
    }
}