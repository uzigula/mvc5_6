using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOffice.Servicios.Clientes.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string DocumentoIdentidad { get; set; }
        public DireccionDto Direccion { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string ContactoNombre { get; set; }
        public string ContactoCargo { get; set; }
        public string NombreUsuario { get; set; }
        public string Url { get; set; }
    }
}
