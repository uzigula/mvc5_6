using System.Linq;
using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio.ADO
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
