using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualOffice.Repositorios.DDDContext;
using VirtualOffice.Servicios.Excepciones;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.EF;
using ReservaRepositorio = VirtualOffice.Repositorios.Impl.ReservaRepositorio;

namespace VirtualOffice.Servicios.Reservas
{
    public class ServicioReserva
    {
        private IVirtualOfficeRepository _contexto;
        public ServicioReserva()
        {
            //Inversion de COntrol, IInyeccion de Dependencia
            //reservaRepositorio = new ReservaRepositorio(new VOfficeDbContext("name=VOffice"));
            _contexto = new EFVirtualOfficeRepository();
        }
        public void Reservar(Dtos.ReservaDto reservaDto)
        {
            try
            {
                Reserva reserva = new Reserva(
                    reservaDto.ClienteId,
                    reservaDto.LocalId,
                    reservaDto.SalaId,
                    reservaDto.Participantes,
                    reservaDto.Indicaciones,
                    reservaDto.FechaInicio,
                    reservaDto.FechaFinal
                    );

                _contexto.ReservaRepository.Add(reserva);
                _contexto.Commit();
            }
            catch (Exception ex)
            {
                throw new ErrorEnReserva("Hubo un error al procesar la reserva");
            }
        }

  
    }
}
