using Acme.Ventas.Mensajeria.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetEjemplo.ConsumidorEjemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new EnviarCorreo();
            sender.Enviar(new Mensaje { Titulo = "un mensaje" }, 3);

            Console.ReadKey();
        }
    }
}
