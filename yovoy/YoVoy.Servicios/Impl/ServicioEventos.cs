using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using YoVoy.Repositorio.DDDContext;
using YoVoy.Repositorio.Entidades;
using YoVoy.Servicios.Dtos;

namespace YoVoy.Servicios.Impl
{
    public class ServicioEventos
    {
        private IYoVoyRepository contexto;

        public ServicioEventos()
        {
            contexto = new EFYovoyRepository();
        }

        public IEnumerable<EventoDto> TraerTodos()
        {
            var evento = contexto
                .EventoRepository.GetAll()
                .ProjectTo<EventoDto>();
            return evento;

        }        
        public Dtos.EventoDto Traer(int id)
        {
            //return eventos.FirstOrDefault(e => e.EventoId == id);
            var evento = contexto
                .EventoRepository.Find(e => e.Id == id)
                .ProjectTo<EventoDto>().FirstOrDefault();
            return evento;

            //return eventos.Find(e => e.EventoId == id);
        }

        public void Inscribir(InscripcionDto request)
        {
            var evento = contexto
                .EventoRepository
                .SingleOrDefault(x => x.Id == request.EventoId);
            evento.AddAsistente(new Asistente() { Nombre = request.Asistente });
            contexto.EventoRepository.Update(evento);
            contexto.Commit();
        }
    }
}
