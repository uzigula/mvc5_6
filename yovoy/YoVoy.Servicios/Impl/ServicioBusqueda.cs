using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoVoy.Servicios.Dtos;
using YoVoy.Repositorio.Entidades;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using YoVoy.Repositorio.DDDContext;

namespace YoVoy.Servicios.Impl
{
    public class ServicioBusqueda
    {
        private IYoVoyRepository contexto;
        public ServicioBusqueda()
        {
            contexto = new EFYovoyRepository();
        }
        public IEnumerable<Dtos.EventoDto> Buscar(string busqueda)
        {
            // Ir al Repositorio de datos y buscar

            IQueryable<Evento> eventos = contexto.EventoRepository.GetAll();
            
            if (!string.IsNullOrEmpty(busqueda)) 
                eventos = eventos.Where(x=>x.Titulo.Contains(busqueda));
                         
            var lista = eventos.ProjectTo<EventoDto>();
            return lista;
        }
    }
}
