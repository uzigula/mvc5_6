using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.DDDContext
{
    public class ReservaRepositorio : GenericRepository<EFVirtualOfficeRepository,Reserva>
    {
        public ReservaRepositorio(EFVirtualOfficeRepository context) : base(context)
        {
        }
    }
}