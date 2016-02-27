
using Dominio;

namespace DataLayer.DDDContext
{
    public class AsistenteRepositorio : GenericRepository<EFYovoyRepository,Asistente>
    {
        public AsistenteRepositorio(EFYovoyRepository context) : base(context)
        {
        }
    }
}