using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using Hotel.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly HotelContext _hotelContext;

        public HabitacionService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<Habitaciones> ObtenerHabitacionDisponibleAsync(DateTime fechaInicial, DateTime fechaFinal, int tipoHabitacion)
        {
            var habitacionesOcupadasIds = await _hotelContext.Reservaciones
                .Include(x => x.Habitacion)
                .Where(x =>
                    x.Habitacion.TipoHabitacionId == tipoHabitacion &&
                    fechaInicial <= x.FechaFinal && fechaFinal >= x.FechaInicial)
                .Select(x => x.HabitacionId).ToListAsync();

            var habitacion = await _hotelContext.Habitaciones
                .Where(x =>
                    x.TipoHabitacionId == tipoHabitacion &&
                    !habitacionesOcupadasIds.Contains(x.HabitacionId))
                .FirstOrDefaultAsync();

            return habitacion;
        }

        public async Task<List<Habitaciones>> ObtenerHabitacionesAsync(HabitacionFilter habitacionFilter)
        {
            if (habitacionFilter == null)
                habitacionFilter = new HabitacionFilter();

            var result = await _hotelContext.Habitaciones
                .Include(x => x.TipoHabitacion)
                .Where(x =>
                    (habitacionFilter.TipoHabitacion <= 0 || x.TipoHabitacionId == habitacionFilter.TipoHabitacion) &&
                    (string.IsNullOrWhiteSpace(habitacionFilter.Habitacion) || x.Habitacion.Contains(habitacionFilter.Habitacion)))
                .ToListAsync();

            return result;
        }
    }
}
