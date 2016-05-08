using TiendaMusica.Data.Repositorio;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.EF.RepositoriosEntidades
{
    class AlbumRepository : EFGenericRepository<EFTiendaMusicaRepository, Album>
    {
        public AlbumRepository(EFTiendaMusicaRepository contexto)
            :base(contexto)
        {

        }
    }
}
