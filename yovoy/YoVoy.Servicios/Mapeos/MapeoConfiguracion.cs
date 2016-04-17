using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoVoy.Repositorio.Entidades;
using YoVoy.Servicios.Dtos;

namespace YoVoy.Servicios.Mapeos
{
    public class MapeoConfiguracion
    {
        public static void Configura()
        {
            Mapper.CreateMap<Evento, EventoDto>()
                .ForMember(dest=>dest.EventoId, 
                map=>map.MapFrom(orig=>orig.Id));
            Mapper.CreateMap<Usuario, UsuarioDto>();
            Mapper.CreateMap<Asistente, AsistenteDto>();
        }
    }
}
