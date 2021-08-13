using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Interfaces;
using Hotel.DataAccess.Services;
using Hotel.WebApp.Models;
using Hotel.WebApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    [Authorize(Roles = Constantes.Identity.Rol.Recepcionista + "," + Constantes.Identity.Rol.Administrador)]
    public class TipoHabitacionController : Controller
    {
        private readonly ITipoHabitacionService _tipoHabitacionService;

        public TipoHabitacionController(ITipoHabitacionService tipoHabitacionService)
        {
            _tipoHabitacionService = tipoHabitacionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ObtenerTiposHabitacion()
        {
            List<TiposHabitacion> lista = await _tipoHabitacionService.ObtenerTiposHabitacionAsync();

            return PartialView(Constantes.VistaParcial.TablaTipoHabitacion, lista);
        }

        [Authorize(Roles = Constantes.Identity.Rol.Administrador)]
        public async Task<IActionResult> Editar(int id)
        {
            var tipoHabitacion = await _tipoHabitacionService.ObtenerTipoHabitacionAsync(id);

            if (tipoHabitacion == null)
                return View();

            var modelo = new TipoHabitacionViewModel
            {
                Precio = tipoHabitacion.Precio,
                TipoHabitacion = tipoHabitacion.TipoHabitacion,
                TipoHabitacionId = tipoHabitacion.TipoHabitacionId
            };

            return View(modelo);
        }

        [Authorize(Roles = Constantes.Identity.Rol.Administrador)]
        [HttpPost]
        public async Task<IActionResult> Editar(TipoHabitacionViewModel model)
        {
            var tipoHabitacion = await _tipoHabitacionService.ObtenerTipoHabitacionAsync(model.TipoHabitacionId);

            if (tipoHabitacion == null)
            {
                ViewBag.Mensaje = "Error al obtener el registro a editar.";
                return View(model);
            }

            tipoHabitacion.Precio = model.Precio;
            tipoHabitacion.TipoHabitacion = model.TipoHabitacion;


            var resultado = await _tipoHabitacionService.EditarTipoHabitacionAsync(tipoHabitacion);

            if (!resultado)
            {
                ViewBag.Mensaje = "Error al editar la información.";
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
