using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using Hotel.DataAccess.Interfaces;
using Hotel.DataAccess.Services;
using Hotel.WebApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    [Authorize(Roles = Constantes.Identity.Rol.Recepcionista)]
    public class HabitacionController : Controller
    {
        private readonly IHabitacionService _habitacionService;
        private readonly ITipoHabitacionService _tipoHabitacionService;

        public HabitacionController(IHabitacionService habitacionService, ITipoHabitacionService tipoHabitacionService)
        {
            _habitacionService = habitacionService;
            _tipoHabitacionService = tipoHabitacionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tiposHabitacion = await _tipoHabitacionService.ObtenerTiposHabitacionAsync();
            ViewBag.TiposHabitacion = tiposHabitacion;
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerHabitaciones([FromQuery] int tipo = 0, [FromQuery] string habitacion = "")
        {
            var filtros = new HabitacionFilter
            {
                Habitacion = habitacion,
                TipoHabitacion = tipo
            };

            List<Habitaciones> listaHabitaciones = await _habitacionService.ObtenerHabitacionesAsync(filtros);

            return PartialView(Constantes.VistaParcial.TablaHabitacion, listaHabitaciones);
        }
    }
}
