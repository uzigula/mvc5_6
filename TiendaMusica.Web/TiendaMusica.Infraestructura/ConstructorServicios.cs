using TiendaMusica.Logica;
using TiendaMusica.Data.Repositorio;

namespace TiendaMusica.Infraestructura
{
    public class ConstructorServicios
    {
        public static TiendaConsultas TiendaConsultas()
        {
            return new TiendaConsultas(new EFTiendaMusicaRepository());
        }
    }
}
