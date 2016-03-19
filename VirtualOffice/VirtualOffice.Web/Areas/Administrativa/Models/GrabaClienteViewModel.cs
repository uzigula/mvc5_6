using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.Areas.Administrativa.Models
{
    public class GrabaClienteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string DocumentoIdentidad { get; set; }
        
        public string DireccionCiudad { get; set; }

        [Display(Name = "Departamento")]
        public SelectList Departamentos { get; set; }

        public string DireccionProvincia { get; set; }

        [Display(Name = "Provincia")]
        public SelectList Provincias { get; set; }
        public string DireccionDistrito{ get; set; }

        [Display(Name = "Distrito")]
        public SelectList Distritos { get; set; }

        [Display(Name = "Dirección")]
        public string DireccionCalle { get; set; }
        
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        public GrabaClienteViewModel()
        {
            var emptyList = new List<string> { "Seleccione..." };
            Departamentos = new SelectList(emptyList);
            Provincias = new SelectList(emptyList);
            Distritos = new SelectList(emptyList);
        }
    }
}