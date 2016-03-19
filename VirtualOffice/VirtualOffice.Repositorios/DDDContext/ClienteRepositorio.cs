using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.DDDContext
{
    public class ClienteRepositorio : GenericRepository<EFVirtualOfficeRepository,Cliente>
    {
        public ClienteRepositorio(EFVirtualOfficeRepository context) : base(context)
        {
        }
    }
}