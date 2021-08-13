using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using Hotel.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Services
{
    public class ReservacionService : IReservacionService
    {
        private readonly HotelContext _hotelContext;

        public ReservacionService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<bool> EliminarReservacionAsync(int reservacionId)
        {
            var reservacion = await _hotelContext.Reservaciones
                .Where(x => x.ReservacionId == reservacionId)
                .FirstOrDefaultAsync();
            if (reservacion == null)
                return false;

            _hotelContext.Remove(reservacion);
            int resultado = await _hotelContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> GuardarReservacionAsync(Reservaciones reservacion)
        {
            _hotelContext.Reservaciones.Add(reservacion);
            int resultado = await _hotelContext.SaveChangesAsync();
            return resultado > 0;
        }

        public Task<List<Reservaciones>> ObtenerReservacionesAsync(ReservacionFilter filtros)
        {
            if (filtros == null)
                filtros = new ReservacionFilter();
            var result = _hotelContext.Reservaciones
                .Include(x => x.Cliente)
                .Include(x => x.Cliente.TipoCliente)
                .Include(x => x.Habitacion)
                .Include(x => x.Habitacion.TipoHabitacion)
                .Where(x =>
                    (!filtros.FechaSalidaInicial.HasValue || x.FechaFinal >= filtros.FechaSalidaInicial) &&
                    (!filtros.FechaSalidaFinal.HasValue || x.FechaFinal <= filtros.FechaSalidaFinal) &&
                    (filtros.ClienteId == 0 || x.ClienteId == filtros.ClienteId) &&
                    (string.IsNullOrWhiteSpace(filtros.Habitacion) || x.Habitacion.Habitacion.Contains(filtros.Habitacion)))
                .ToListAsync();

            return result;
        }
    }
}
