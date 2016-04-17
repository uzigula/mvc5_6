using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YoVoy.Web.Models
{
    public class EventoNuevoViewModel
    {
        public string Lugar { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public string Notas { get; set; }
    }
}
