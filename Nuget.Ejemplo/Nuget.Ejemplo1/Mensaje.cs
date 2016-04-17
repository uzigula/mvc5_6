using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Ventas.Mensajeria.Email
{
    public class Mensaje
    {
        public string Para { get; set; }
        public string De { get; set; }
        public string Titulo { get; set; }

        public string Contenido { get; set; }
    }
}
