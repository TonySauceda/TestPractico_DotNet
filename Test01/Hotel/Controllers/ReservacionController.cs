using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
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
    [Authorize(Roles = Constantes.Identity.Rol.Recepcionista)]
    public class ReservacionController : Controller
    {
        private readonly IReservacionService _reservacionService;
        private readonly IClienteService _clienteService;
        private readonly ITipoHabitacionService _tipoHabitacionService;
        private readonly IHabitacionService _habitacionService;

        public ReservacionController(IReservacionService reservacionService, IClienteService clienteService, ITipoHabitacionService tipoHabitacionService, IHabitacionService habitacionService)
        {
            _reservacionService = reservacionService;
            _clienteService = clienteService;
            _tipoHabitacionService = tipoHabitacionService;
            _habitacionService = habitacionService;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObtenerClientesAsync();
            ViewBag.Clientes = clientes;

            return View();
        }

        public async Task<IActionResult> ObtenerReservaciones([FromQuery] int clienteId = 0, [FromQuery] string habitacion = "")
        {
            var filtros = new ReservacionFilter
            {
                ClienteId = clienteId,
                Habitacion = habitacion
            };

            var reservaciones = await _reservacionService.ObtenerReservacionesAsync(filtros);

            return PartialView(Constantes.VistaParcial.TablaReservaciones, reservaciones);
        }

        public async Task<IActionResult> Nueva()
        {
            var clientes = await _clienteService.ObtenerClientesAsync();
            var habitaciones = await _tipoHabitacionService.ObtenerTiposHabitacionAsync();

            ViewBag.Clientes = clientes;
            ViewBag.Habitaciones = habitaciones;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nueva(NuevaReservacionViewModel model)
        {
            DateTime fechaFinal = model.Fecha.AddDays(model.Dias - 1);
            //Buscar habitación disponible en la fecha
            var habitacion = await _habitacionService.ObtenerHabitacionDisponibleAsync(model.Fecha, fechaFinal, model.TipoHabitacionId);

            if (habitacion == null)
            {
                ViewBag.Mensaje = "No se encuentran habitaciones disponibles a la fecha seleccionada.";
                return View(model);
            }

            var reservacion = new Reservaciones
            {
                ClienteId = model.ClienteId,
                FechaCreacion = DateTime.UtcNow,
                FechaInicial = model.Fecha,
                FechaFinal = fechaFinal,
                HabitacionId = habitacion.HabitacionId,
                UsuarioId = 1
            };

            var resultado = await _reservacionService.GuardarReservacionAsync(reservacion);

            if (!resultado)
            {
                ViewBag.Mensaje = "Error al guardar la reservación.";
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int reservacionId)
        {
            var resultado = await _reservacionService.EliminarReservacionAsync(reservacionId);

            if (!resultado)
            {
                return Json(new
                {
                    Exito = false,
                    Mensaje = "Error al eliminar la reservación."
                });
            }

            return Json(new
            {
                Exito = true,
                Mensaje = "Proceso realizado correctamente."
            });
        }
    }
}