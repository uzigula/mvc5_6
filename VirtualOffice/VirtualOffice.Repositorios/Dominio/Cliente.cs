using System.Collections.Generic;
using VirtualOffice.Repositorios.Dominio.Componentes;

namespace VirtualOffice.Repositorios.Dominio
{
    public class Cliente : Entidad
    {
        public string Nombre { get; set; }
        public string DocumentoIdentidad { get; set; }
        public Direccion Direccion { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string ContactoNombre { get; set; }
        public string ContactoCargo { get; set; }
        public virtual IList<Reserva> Reservas { get; set; }
        public string NombreUsuario { get; set; }
        public string Url { get; set; }

        public Cliente()
        {
            Direccion = new Direccion();
        }
    }
}
