using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.EF;
namespace VirtualOffice.Repositorios.Impl
{
    public class ReservaRepositorio : RepositorioBase<Reserva,VOfficeDbContext>
    {
        public ReservaRepositorio(VOfficeDbContext context) : base(context)
        {

        }
    }
}
