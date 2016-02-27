using Dominio;

namespace DataLayer.DDDContext
{
    public class EventoRepositorio : GenericRepository<EFYovoyRepository,Evento>
    {
        public EventoRepositorio(EFYovoyRepository context) : base(context)
        {
        }
    }
}