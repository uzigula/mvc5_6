using System.Linq;
using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.ADO
{
    interface IDbRepository<TEntity>
       where TEntity:Entidad
    {
        IQueryable<TEntity> Get();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
