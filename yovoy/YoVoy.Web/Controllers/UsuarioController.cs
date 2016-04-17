using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoVoy.Servicios.Dtos;
using YoVoy.Servicios.Impl;
using YoVoy.Web.Models;

namespace YoVoy.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private readonly ServicioUsuario servicioUsuario;
        private ILog logger;
        public UsuarioController()
        {
            this.servicioUsuario = new ServicioUsuario();
            logger = LogManager.GetLogger("UsuarioLogger");
        }
        public ActionResult Editar(string nombreUsuario)
        {
            logger.InfoFormat("Se ingreso a ver usuario : {0}", nombreUsuario);
            UsuarioDto usuario = servicioUsuario.Traer(nombreUsuario);
            return View(Mapper.Map<UsuarioDto, UsuarioEditModel>(usuario));
        }

        [HttpPost]
        public ActionResult Editar(UsuarioEditModel usuario, HttpPostedFileBase upload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                   
                    logger.Debug("El modelo de usuario es invalido");
                    ModelState.AddModelError("", "Hubo un Error");
                    return View(usuario);                   
                }
                var usuarioDto = Mapper.Map<UsuarioEditModel, UsuarioDto>(usuario);
                if (upload != null && upload.ContentLength > 0)
                {
                    
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        usuarioDto.Avatar = new FileContent()
                        {
                            NombreArchivo = upload.FileName,
                            Content = reader.ReadBytes(upload.ContentLength)
                        };
                    }
                }
                servicioUsuario.Actualizar(usuarioDto);
                logger.InfoFormat("Se Actualizo correctamente el Usuario: {0}", usuario.Nombre);
            }
            catch (Exception ex)
            {
                // si tuvieras un logger configuradoc log4net
                logger.Error("Error Actualizando Usuario", ex);
                ModelState.AddModelError("", "Hubo un Error");
                return View(usuario);
            }

            return RedirectToAction("Index", "Home");
            
        }

    }
}