using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TiendaMusica.Data.Repositorio;

namespace TiendaMusica.Data.EF
{
    abstract class EFGenericRepository<TContexto, TEntidad> :
          IGenericRepository<TEntidad>
          where TEntidad : class
          where TContexto : DbContext, new()
    {
        private TContexto _contexto;

        protected EFGenericRepository(TContexto context)
        {
            _contexto = context;
        }

        public IQueryable<TEntidad> GetAll()
        {
            return _contexto.Set<TEntidad>().AsQueryable();
        }

        public IQueryable<TEntidad> Find(Expression<Func<TEntidad, bool>> predicate)
        {
            IQueryable<TEntidad> query = _contexto.Set<TEntidad>().Where(predicate);
            return query;

        }

        public TEntidad Single(Expression<Func<TEntidad, bool>> predicate)
        {
            return _contexto.Set<TEntidad>().Single(predicate);
        }

        public TEntidad SingleOrDefault(Expression<Func<TEntidad, bool>> predicate)
        {
            return _contexto.Set<TEntidad>().SingleOrDefault(predicate);
        }

        public TEntidad First(Expression<Func<TEntidad, bool>> predicate)
        {
            return _contexto.Set<TEntidad>().FirstOrDefault(predicate);
        }


        public void Add(TEntidad entity)
        {
            _contexto.Set<TEntidad>().Add(entity);
        }

        public void Delete(TEntidad entity)
        {
            _contexto.Set<TEntidad>().Remove(entity);
        }

        public void Update(TEntidad entity)
        {
            if (_contexto.Entry(entity).State == EntityState.Detached)
                _contexto.Set<TEntidad>().Attach(entity);
            _contexto.Entry(entity).State = EntityState.Modified;
        }

        [Obsolete("Solo disponible para Insight Database Provider")]
        public IEnumerable<TEntidad> ConsultaAdHoc(string query, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
