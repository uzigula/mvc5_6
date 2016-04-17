using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio.DDDContext
{
    public class EventoRepositorio : GenericRepository<EFYovoyRepository,Evento>
    {
        public EventoRepositorio(EFYovoyRepository context) : base(context)
        {
        }
    }
}