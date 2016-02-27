using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Evento : Entidad
    {
        public Evento()
        {
            Asistentes = new List<Asistente>();
        }
        public string Titulo { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Organizador { get; set; }
        public int UsuarioId { get; set; } //solo por que uso EF
        public virtual IList<Asistente> Asistentes { get; set; }

        public void AddAsistente(Asistente asistente)
        {
            //EF asignar el Id y la instancia
            asistente.EventoId = this.Id;
            // NHibernate solo asigna la instancia del padre
            asistente.Evento = this;
            
            Asistentes.Add(asistente);
        }
    }
}
