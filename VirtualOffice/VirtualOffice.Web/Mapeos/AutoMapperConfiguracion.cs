using AutoMapper;
using VirtualOffice.Servicios.Clientes.Dtos;
using VirtualOffice.Servicios.Configuracion.Dtos;
using VirtualOffice.Servicios.Reservas.Dtos;
using VirtualOffice.Web.Areas.Administrativa.Models;
using VirtualOffice.Web.Models;

namespace VirtualOffice.Web.Mapeos
{
    public class AutoMapperConfiguracion
    {
        public static void Configuracion()
        {
            Mapper.CreateMap<ReservaGrabarViewModel, ReservaDto>();
            Mapper.CreateMap<GrabaClienteViewModel, GrabaClienteDto>()
                .ForMember(dest => dest.Direccion,
                    map =>
                        map.MapFrom(
                            orig =>
                                new DireccionDto()
                                {
                                    Ciudad = orig.DireccionCiudad,
                                    Calle = orig.DireccionCalle,
                                    Provincia = orig.DireccionProvincia,
                                    Distrito = orig.DireccionDistrito
                                }));
            Mapper.CreateMap<ClienteDto, ClientesListaViewModel>()
                .ForMember(dest => dest.ClienteId,
                    map => map.MapFrom(orig => orig.Id))
                .ForSourceMember(orig => orig.NombreUsuario, map => map.Ignore());

            Mapper.CreateMap<ClienteDto, GrabaClienteViewModel>()
                .ForMember(dest => dest.CorreoElectronico,
                    map => map.MapFrom(orig => orig.NombreUsuario))
                .ForMember(dest => dest.Departamentos,
                    map => map.Ignore())
                .ForMember(dest => dest.Provincias,
                    map => map.Ignore())
                .ForMember(dest => dest.Distritos,
                    map => map.Ignore());

            Mapper.CreateMap<GrabaClienteViewModel, ClienteDto>()
                .ForMember(dest => dest.NombreUsuario,
                    map => map.MapFrom(orig => orig.CorreoElectronico))
                .ForMember(dest => dest.Direccion,
                    map =>
                        map.MapFrom(
                            orig =>
                                new DireccionDto()
                                {
                                    Ciudad = orig.DireccionCiudad,
                                    Calle = orig.DireccionCalle,
                                    Provincia = orig.DireccionProvincia,
                                    Distrito = orig.DireccionDistrito
                                }))
                 .ForSourceMember(orig => orig.Departamentos,
                    map => map.Ignore())
                .ForSourceMember(orig => orig.Provincias,
                    map => map.Ignore())
                .ForSourceMember(orig => orig.Distritos,
                    map => map.Ignore());

            Mapper.CreateMap<SucursalDto, SucursalListaViewModel>().MaxDepth(2);
            Mapper.CreateMap<SalaDto, SalaListaViewModel>().MaxDepth(2);
        }
    }
}