using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YoVoy.Web.Models
{
    public class InscribirseViewModel
    {
        public string  Titulo { get; set; }
        [Required]
        [Display(Description="Nombre")]
        [MinLength(2)]
        public string NombreAsistente { get; set; }
        [Required]
        [Display(Description = "# Entradas")]
        public int NumeroEntradas { get; set; }
        public int EventoId { get; set; }
    }
}