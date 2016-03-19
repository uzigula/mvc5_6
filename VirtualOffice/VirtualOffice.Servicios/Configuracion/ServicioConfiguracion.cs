using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using VirtualOffice.Repositorios.DDDContext;
using VirtualOffice.Servicios.Configuracion.Dtos;

namespace VirtualOffice.Servicios.Configuracion
{
    public class ServicioConfiguracion
    {
        private IVirtualOfficeRepository _contexto;

        public ServicioConfiguracion()
        {
            _contexto = new EFVirtualOfficeRepository();
        }

        public IEnumerable<Dtos.SucursalDto> Sucursales()
        {
            return _contexto.SucursalRepository.GetAll().ProjectTo<SucursalDto>();
        }

        public IEnumerable<Dtos.SalaDto> Salas(int sucursal)
        {
            return _contexto.SalasRepository.GetAll().Where(s=>s.SucursalId==sucursal).ProjectTo<SalaDto>();
        }
    }
}