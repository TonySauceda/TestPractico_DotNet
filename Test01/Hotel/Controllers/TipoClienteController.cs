using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Interfaces;
using Hotel.DataAccess.Services;
using Hotel.WebApp.Models;
using Hotel.WebApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    [Authorize(Roles = Constantes.Identity.Rol.Recepcionista + "," + Constantes.Identity.Rol.Administrador)]
    public class TipoClienteController : Controller
    {
        private readonly ITipoClienteService _tipoClienteService;

        public TipoClienteController(ITipoClienteService tipoClienteService)
        {
            _tipoClienteService = tipoClienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTiposCliente()
        {
            List<TiposCliente> lista = await _tipoClienteService.ObtenerTiposClienteAsync();

            return PartialView(Constantes.VistaParcial.TablaTipoCliente, lista);
        }

        [Authorize(Roles = Constantes.Identity.Rol.Administrador)]
        public async Task<IActionResult> Editar(int id)
        {
            var tipoCliente = await _tipoClienteService.ObtenerTipoClienteAsync(id);

            if (tipoCliente == null)
                return View();

            var modelo = new TipoClienteViewModel
            {
                PorcentajeDescuento = tipoCliente.PorcentajeDescuento,
                TipoCliente = tipoCliente.TipoCliente,
                TipoClienteId = tipoCliente.TipoClienteId
            };

            return View(modelo);
        }

        [Authorize(Roles = Constantes.Identity.Rol.Administrador)]
        [HttpPost]
        public async Task<IActionResult> Editar(TipoClienteViewModel model)
        {
            var tipoCliente = await _tipoClienteService.ObtenerTipoClienteAsync(model.TipoClienteId);

            if (tipoCliente == null)
            {
                ViewBag.Mensaje = "Error al obtener el registro a editar.";
                return View(model);
            }

            tipoCliente.TipoCliente = model.TipoCliente;
            tipoCliente.PorcentajeDescuento = model.PorcentajeDescuento;


            var resultado = await _tipoClienteService.EditarTipoClienteAsync(tipoCliente);

            if (!resultado)
            {
                ViewBag.Mensaje = "Error al editar la información.";
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
