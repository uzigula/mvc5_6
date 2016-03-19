using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.DDDContext
{
    public class SalaRepositorio : GenericRepository<EFVirtualOfficeRepository,Sala>
    {
        public SalaRepositorio(EFVirtualOfficeRepository context) : base(context)
        {
        }
    }
}