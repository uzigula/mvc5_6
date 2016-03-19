using AutoMapper;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.Dominio.Componentes;
using VirtualOffice.Servicios.Clientes.Dtos;
using VirtualOffice.Servicios.Configuracion.Dtos;

namespace VirtualOffice.Servicios.Mapeos
{
    public class ServiciosAutomapperConfiguracion
    {
        public static void Configuracion()
        {
            Mapper.CreateMap<GrabaClienteDto, Cliente>()
                .ForMember(dest => dest.NombreUsuario, map => map.MapFrom(orig => orig.CorreoElectronico))
                .ForMember(dest=>dest.Url, map => map.UseValue(string.Empty));
            Mapper.CreateMap<Cliente, ClienteDto>();
            Mapper.CreateMap<Direccion, DireccionDto>();
            Mapper.CreateMap<DireccionDto, Direccion>();
            Mapper.CreateMap<Sucursal, SucursalDto>();
            Mapper.CreateMap<Sala, SalaDto>();

        }
    }
}
