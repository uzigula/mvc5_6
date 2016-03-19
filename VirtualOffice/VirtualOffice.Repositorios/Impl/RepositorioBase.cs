using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.EF;

namespace VirtualOffice.Repositorios.Impl
{
    public class RepositorioBase<TEntidad, TContext> : IRepositorio<TEntidad> 
        where TEntidad:Entidad
        where TContext:DbContext
    {
        protected TContext context;
        public RepositorioBase(TContext dbContext)
        {
            context = dbContext;
        }
        
        public virtual void Actualizar(TEntidad entidad)
        {
            context.Entry(entidad).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Agregar(TEntidad entidad)
        {
            context.Set<TEntidad>().Add(entidad);
            context.SaveChanges();
        }

        public virtual void Eliminar(TEntidad entidad)
        {
            context.Set<TEntidad>().Remove(entidad);
            context.SaveChanges();
        }

        public virtual IQueryable<TEntidad> Traer()
        {
            return context.Set<TEntidad>().AsQueryable();
        }

        public virtual TEntidad Traer(int id)
        {
            return context.Set<TEntidad>().FirstOrDefault(x => x.Id == id);
        }
    }
}
