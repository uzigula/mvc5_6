using TiendaMusica.Logica;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Data.InsightDB;

namespace TiendaMusica.Infraestructura
{
    public class ConstructorServicios
    {
        public static TiendaConsultas TiendaConsultas()
        {
            // return new TiendaConsultas(new EFTiendaMusicaRepository());

            return new TiendaConsultas(new TiendaMusicaDB("ChinookDominio"));
        }
    }
}
