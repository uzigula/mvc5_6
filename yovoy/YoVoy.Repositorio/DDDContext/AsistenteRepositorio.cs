using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio.DDDContext
{
    public class AsistenteRepositorio : GenericRepository<EFYovoyRepository,Asistente>
    {
        public AsistenteRepositorio(EFYovoyRepository context) : base(context)
        {
        }
    }
}