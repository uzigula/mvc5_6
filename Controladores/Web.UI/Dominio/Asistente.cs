namespace Dominio
{
    public class Asistente : Entidad
    {
        public string Nombre { get; set; }
        public Evento Evento { get; set; }
        public int EventoId { get; set; }
    }
}
