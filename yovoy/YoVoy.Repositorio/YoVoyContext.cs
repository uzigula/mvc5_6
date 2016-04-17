using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio
{
    public class YoVoyContext : DbContext
    {
        public YoVoyContext():base("name=YoVoyDB")
        {

        }

        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento>  Eventos { get; set; }

    }
}
