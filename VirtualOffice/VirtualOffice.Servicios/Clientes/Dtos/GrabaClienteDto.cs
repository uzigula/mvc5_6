using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOffice.Servicios.Clientes.Dtos
{
    public class GrabaClienteDto
    {
        public string Nombre { get; set; }
        public string DocumentoIdentidad { get; set; }
        public DireccionDto Direccion { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
