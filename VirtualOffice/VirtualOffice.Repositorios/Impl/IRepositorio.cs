using System;
using System.Linq;
using VirtualOffice.Repositorios.Dominio;
namespace VirtualOffice.Repositorios.Impl
{
    public interface IRepositorio<TEntidad> where TEntidad:Entidad
    {
        void Actualizar(TEntidad entidad);
        void Agregar(TEntidad entidad);
        void Eliminar(TEntidad entidad);
        IQueryable<TEntidad> Traer();
        TEntidad Traer(int id);
    }
}
