using System;
using VirtualOffice.Repositorios.Dominio;

namespace VirtualOffice.Repositorios.DDDContext
{
    public interface IVirtualOfficeRepository : IDisposable
    {
        IGenericRepository<Cliente> ClienteRepository { get; }
        IGenericRepository<Reserva> ReservaRepository { get; }
        IGenericRepository<Sala> SalasRepository { get; }
        IGenericRepository<Sucursal> SucursalRepository { get; }
        void Commit();
    }
}