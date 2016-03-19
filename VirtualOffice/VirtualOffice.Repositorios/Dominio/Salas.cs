using System;

namespace VirtualOffice.Repositorios.Dominio
{
    public class Sala : Entidad
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public String Caracteristicas { get; set; }
        public int SucursalId { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}