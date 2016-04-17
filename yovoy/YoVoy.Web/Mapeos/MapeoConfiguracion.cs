using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoVoy.Servicios.Dtos;
using YoVoy.Web.Models;

namespace YoVoy.Web.Mapeos
{
    public class MapeoConfiguracion
    {
        public static void Configuracion()
        {
            Mapper.CreateMap<EventoDto, ListaEventosViewModel>()
                .ForMember(dest => dest.Estado, exp => exp.MapFrom(orig => orig.Activo ? "Esta Abierto" : "Cerrado"))
                .ForMember(dest => dest.Fecha, exp => exp.MapFrom(orig => orig.Fecha.ToString("dd MMMM")));

            Mapper.CreateMap<EventoDto, EventoDetalleViewModel>()
                .ForMember(dest=>dest.Cuando, map=>map.MapFrom(orig=>orig.Fecha))
                .ForMember(dest=>dest.InscripcionesAbiertas, 
                map=>map.MapFrom(orig=>orig.Activo));

            Mapper.CreateMap<UsuarioDto, OrganizadorEvento>()
                .ForSourceMember(orig=>orig.NombreCuenta,
                map=>map.Ignore());

            Mapper.CreateMap<AsistenteDto, AsistenteEvento>();

            Mapper.CreateMap<UsuarioDto, UsuarioEditModel>();
            Mapper.CreateMap<UsuarioEditModel, UsuarioDto>();

        }
    }
}