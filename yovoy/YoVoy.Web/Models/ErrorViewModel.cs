using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoVoy.Web.Models
{
    public class ErrorViewModel
    {
        public string Encabezado { get; set; }

        public string IrAlHome { get; set; }

        public string Mensaje { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
    }
}
