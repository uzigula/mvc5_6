using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoVoy.Servicios.Dtos
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }

        public string CorreoElectronico { get; set; }

        public string InformacionAdicional { get; set; }

        public string NombreCuenta { get; set; }
        public DateTime AfiliadoEn { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }

        public FileContent Avatar { get; set; }
    }
}
