using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.DDDContext
{
    public class SucursalRepositorio : GenericRepository<EFVirtualOfficeRepository,Sucursal>
    {
        public SucursalRepositorio(EFVirtualOfficeRepository context) : base(context)
        {
        }
    }
}