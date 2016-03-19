using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VirtualOffice.Repositorios.DDDContext;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.EF;
using VirtualOffice.Repositorios.Impl;
using VirtualOffice.Servicios.Clientes.Dtos;
using VirtualOffice.Repositorios.Dominio.Componentes;

namespace VirtualOffice.Servicios.Clientes
{
    public class ServicioClientes
    {
        private IVirtualOfficeRepository _contexto;
        public ServicioClientes()
        {
            //repositorioCliente = new RepositorioCliente(new VOfficeDbContext("name=VOffice"));
            _contexto = new EFVirtualOfficeRepository();
        }
        public void Nuevo(GrabaClienteDto grabaClienteDto)
        {
            var cliente = Mapper.Map<GrabaClienteDto, Cliente>(grabaClienteDto);
            //repositorioCliente.Agregar(cliente);
            _contexto.ClienteRepository.Add(cliente);
            _contexto.Commit();
        }

        public IList<ClienteDto> Buscar(string Busqueda)
        {
            var clientes = _contexto.ClienteRepository.GetAll(); //repositorioCliente.Traer();
            if (!string.IsNullOrEmpty(Busqueda)) clientes = clientes.Where(x => x.Nombre.Contains(Busqueda));

            return Mapper.Map<IList<Cliente>, IList<ClienteDto>>(clientes.ToList());
        }

        public string ObtenerRutaPerfil(string nombreUsuario)
        {
            try
            {
                var cliente = _contexto.ClienteRepository.SingleOrDefault(x => x.NombreUsuario == nombreUsuario);

                //repositorioCliente.Traer().SingleOrDefault(x => x.NombreUsuario == nombreUsuario);

                return (string.IsNullOrEmpty(cliente.Url)) ? cliente.Id.ToString() : cliente.Url;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public ClienteDto TraerPorId(int id)
        {
            var cliente = _contexto
                .ClienteRepository
                .SingleOrDefault(x => x.Id == id);
            return Mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public void Actualizar(ClienteDto clienteDto)
        {
            //Forma 1
            
            //var cliente = Mapper.Map<ClienteDto, Cliente>(clienteDto);
            
            ///Forma 2 a mano
            var clienteOld = _contexto.ClienteRepository.SingleOrDefault(x => x.Id == clienteDto.Id);

            clienteOld.Nombre = clienteDto.Nombre;
            clienteOld.DocumentoIdentidad = clienteDto.DocumentoIdentidad;
            clienteOld.Direccion = Mapper
                .Map<DireccionDto, Direccion>(clienteDto.Direccion);

            _contexto.ClienteRepository.Update(clienteOld);
            _contexto.Commit();

            //forma2 entidades complejas que tienen listas o colecciones
            //var clienteOld = _contexto.ClienteRepository.SingleOrDefault(x => x.Id == clienteDto.Id);

            // actualizar los campos manual
            // si hay colecciones modificar las colecciones manualmente

        }
    }
}
