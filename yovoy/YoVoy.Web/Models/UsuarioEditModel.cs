using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace YoVoy.Web.Models
{
    public class UsuarioEditModel
    {
        public string Nombre { get; set; }
        [Display(Name="Correo Electrónico")]
        public string CorreoElectronico { get; set; }
        [Display(Name = "Información Adicional")]
        public string InformacionAdicional { get; set; }
        public string NombreCuenta { get; set; }
        
        [Display(Name = "Afiliado desde")]
        public DateTime AfiliadoEn { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }

        public SelectList Departamentos { get; set; }
        public SelectList Provincias { get; set; }
        public SelectList Distritos { get; set; }

        public UsuarioEditModel()
        {
            var listaVacia = new List<string>() { "Seleccione ..." };
            Departamentos = new SelectList(listaVacia);
            Provincias = new SelectList(listaVacia);
            Distritos = new SelectList(listaVacia);

        }
        
    }
}
