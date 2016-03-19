using System.Collections.Generic;
using VirtualOffice.Repositorios.Dominio.Componentes;

namespace VirtualOffice.Repositorios.Dominio
{
    public class Sucursal : Entidad
    {
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }
        public IList<Sala> Salas { get; set; }

        public Sucursal()
        {
            Direccion = new Direccion();
            Salas = new List<Sala>();
        }
    }
}