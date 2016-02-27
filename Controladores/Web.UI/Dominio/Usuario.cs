using System;

namespace Dominio
{
    public class Usuario : Entidad
    {
        public string Nombre { get; set; }
        
        public string CorreoElectronico { get; set; }

        public string InformacionAdicional { get; set; }
        public string NombreCuenta { get; set; }
        public DateTime AfiliadoEn { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }
}
