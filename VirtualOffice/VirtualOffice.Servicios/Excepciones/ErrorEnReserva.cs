using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualOffice.Servicios.Excepciones
{
    public class ErrorEnReserva : Exception
    {
        public ErrorEnReserva(string mensaje) : base(mensaje)
        {

        }
    }
}
