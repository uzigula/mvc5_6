using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio.DDDContext
{
    public class UsuarioRepositorio : GenericRepository<EFYovoyRepository,Usuario>
    {
        public UsuarioRepositorio(EFYovoyRepository context) : base(context)
        {
        }
    }
}