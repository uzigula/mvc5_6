using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.EF;

namespace VirtualOffice.Repositorios.Impl
{
    public class RepositorioCliente : RepositorioBase<Cliente, VOfficeDbContext>
    {
        public RepositorioCliente(VOfficeDbContext context) : base(context)
        {

        }

        
    }
}
