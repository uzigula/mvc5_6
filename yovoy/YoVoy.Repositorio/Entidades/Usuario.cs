using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace YoVoy.Repositorio.Entidades
{
    // la informacion del usuario segun mi logica de negocio
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
