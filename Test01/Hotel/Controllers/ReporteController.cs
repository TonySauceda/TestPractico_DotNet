using Hotel.DataAccess.Filters;
using Hotel.DataAccess.Interfaces;
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
    [Authorize(Roles = Constantes.Identity.Rol.Administrador)]
    public class ReporteController : Controller
    {
        private readonly IReservacionService _reservacionService;

        public ReporteController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerReporte([FromQuery] DateTime? fecha)
        {
            if (fecha == null)
                fecha = DateTime.Now;

            fecha = new DateTime(fecha.Value.Year, fecha.Value.Month, 1);
            var filtros = new ReservacionFilter
            {
                FechaSalidaInicial = fecha.Value,
                FechaSalidaFinal = fecha.Value.AddMonths(1).AddDays(-1)
            };
            var reservaciones = await _reservacionService.ObtenerReservacionesAsync(filtros);

            var reporteModel = new ReporteViewModel(reservaciones);

            return PartialView(Constantes.VistaParcial.Reporte, reporteModel);
        }
    }
}
