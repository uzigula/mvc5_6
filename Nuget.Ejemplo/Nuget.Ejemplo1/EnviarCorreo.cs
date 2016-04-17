using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Ventas.Mensajeria.Email
{
    public class EnviarCorreo
    {
        [Obsolete]
        public void Enviar(Mensaje mensaje)
        {
            // ponder codigo de envio de correo
            Console.WriteLine("Enviando mensaje de correo Obsoleto");
        }

        public void Enviar(Mensaje mensaje, int numeroIntentos)
        {
            // ponder codigo de envio de correo
            Console.WriteLine($"Enviando mensaje de correo hasta {numeroIntentos} numero de intentos");

            // instanciar Autofixture

            var fixture = new Fixture();
        }


    }
}
