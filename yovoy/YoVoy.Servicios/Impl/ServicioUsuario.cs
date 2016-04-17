using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Web;
using YoVoy.Repositorio.DDDContext;
using YoVoy.Repositorio.Entidades;
using YoVoy.Servicios.Dtos;

namespace YoVoy.Servicios.Impl
{
    public class ServicioUsuario
    {
        private readonly IYoVoyRepository repositorio;

        public ServicioUsuario ()
	    {
            repositorio = new EFYovoyRepository();
	    }

        public Dtos.UsuarioDto Traer(string nombreUsuario)
        {
            var usuario = repositorio
                .UsuarioRepository
                .Single(x => x.CorreoElectronico == nombreUsuario);

            return Mapper.Map<Usuario, UsuarioDto>(usuario);
        }

        public void Actualizar(Dtos.UsuarioDto usuarioDto)
        {
            var usuario =repositorio
                .UsuarioRepository
                .Single(x => x.CorreoElectronico == usuarioDto.CorreoElectronico);
            // actualizar la entidad con el dto
            usuario.Departamento = usuarioDto.Departamento;
            usuario.Provincia= usuarioDto.Provincia;
            usuario.Distrito = usuarioDto.Distrito;

            var nombreArchivo = "\avatar" + usuario.Id + Path.GetExtension(usuarioDto.Avatar.NombreArchivo);
            // grabando la imagen
            var path = HttpContext.Current.Server.MapPath(@"~\Avatars");
            File.WriteAllBytes(path + nombreArchivo, usuarioDto.Avatar.Content); // Requires System.IO
            repositorio.Commit();
        }
    }
}
