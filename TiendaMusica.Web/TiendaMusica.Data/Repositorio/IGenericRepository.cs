using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TiendaMusica.Data.Repositorio
{
    public interface IGenericRepository<TEntidad> where TEntidad : class
    {
        IQueryable<TEntidad> GetAll();
        IQueryable<TEntidad> Find(Expression<Func<TEntidad, bool>> predicate);
        TEntidad Single(Expression<Func<TEntidad, bool>> predicate);
        TEntidad SingleOrDefault(Expression<Func<TEntidad, bool>> predicate);
        TEntidad First(Expression<Func<TEntidad, bool>> predicate);

        void Add(TEntidad entity);
        void Delete(TEntidad entity);
        void Update(TEntidad entity);

        //metodo para Insight Database
        IEnumerable<TEntidad> ConsultaAdHoc(string query, object parameters);

    }

    
}