using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using VirtualOffice.Web.Areas.Administrativa.Models;
using VirtualOffice.Servicios.Clientes.Dtos;
using VirtualOffice.Servicios.Clientes;
using VirtualOffice.Servicios.Excepciones;
using VirtualOffice.Web.Filters.Auth;
using VirtualOffice.Web.Models;

namespace VirtualOffice.Web.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "Admin, Empleado")]
    public class ClientesController : Controller
    {
        private ServicioClientes servicioClientes;
        // GET: Administrativa/Clientes
        public ClientesController()
        {
            servicioClientes = new ServicioClientes();
        }

        public ActionResult Index(string busqueda)
        {

            busqueda = string.IsNullOrEmpty(busqueda) ? string.Empty : busqueda;
            var model = Mapper.Map<IList<ClienteDto>, IList<ClientesListaViewModel>>(servicioClientes.Buscar(busqueda));
            return View(new BuscaClientesViewModel() { Clientes = model});
        }

        public ActionResult Nuevo()
        {
            return View(new GrabaClienteViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Nuevo(GrabaClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Debemos codificar la reserva
                    await CreaUsuario(model);
                    servicioClientes.Nuevo(Mapper.Map<GrabaClienteViewModel, GrabaClienteDto>(model));
                    // transferencia de datos entre capas
                    return RedirectToAction("Index", "AdmHome", new { area = "Administrativa" });
                }
                // reconstruir el objeto anterior <ReservaViewModel>
                ModelState.AddModelError("", "Hubo Error en el Modelo");
                return View(model);
            }
            catch (ErrorCreandoCliente ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            ClienteDto cliente = servicioClientes.TraerPorId(id);
            if (cliente.EsNulo())
                RedirectToAction("NoEncontrado","Errores", new { area = ""});

            return View(Mapper.Map<ClienteDto,GrabaClienteViewModel>(cliente));
        }

        [HttpPost]
        public ActionResult Editar(GrabaClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cliente = Mapper.Map<GrabaClienteViewModel, ClienteDto>(model);
                    servicioClientes.Actualizar(cliente);
                    return RedirectToAction("Index", "AdmHome", new { area = "Administrativa" });
                }
                ModelState.AddModelError("", "Hubo Error en el Modelo");
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hubo Error en el Modelo");
                return View(model);
            }
        }

        public ActionResult RenovarSuscripcion(int id)
        {
            return PartialView("_RenovarSuscripcion", new RenuevaSuscripcionClienteViewModel() { ClienteId = id, Titulo = "Renovar Suscripcion" });
        }


        //public ActionResult ListaBusqueda()
        //{
        //    var clientes = servicioClientes.Buscar(string.Empty);
        //    return Json(clientes, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RenovarSuscripcion(RenuevaSuscripcionClienteViewModel model)
        {
            return ConsultarClientes("");
        }
        public ActionResult VerSuscripciones(int id)
        {
            return View();
        }


        public PartialViewResult ConsultarClientes(string busqueda)
        {
            busqueda = string.IsNullOrEmpty(busqueda) ? string.Empty : busqueda;
            var model = Mapper.Map<IList<ClienteDto>, IList<ClientesListaViewModel>>(servicioClientes.Buscar(busqueda));

            return PartialView("_ListaClientes", model);
        }


        public ActionResult ListaBusqueda()
        {
            var clientes = Mapper.Map<IList<ClienteDto>, IList<ClientesListaViewModel>>(servicioClientes.Buscar(string.Empty));

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        private async Task<IdentityResult> CreaUsuario(GrabaClienteViewModel cliente)
        {
            using (ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>())
            {
                var usuarioCliente = new ApplicationUser()
                {
                    UserName = cliente.CorreoElectronico,
                    Email = cliente.CorreoElectronico,
                    Nombre = cliente.Nombre,
                    DebeCambiarPassword = true
                };

                await userManager.CreateAsync(usuarioCliente, "P@$$w0rd");
                userManager.AddToRole(usuarioCliente.Id, "Cliente");
                string code = await userManager.GeneratePasswordResetTokenAsync(usuarioCliente.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = usuarioCliente.Id, code = code, area="" }, protocol: Request.Url.Scheme);
                await userManager.SendEmailAsync(usuarioCliente.Id, "Crear contraseña", "Para Crear su contraseña, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");
            }
            return null;
        }


       
    }
}