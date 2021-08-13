using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Services
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly HotelContext _hotelContext;

        public TipoHabitacionService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<bool> EditarTipoHabitacionAsync(TiposHabitacion tiposHabitacion)
        {
            _hotelContext.TiposHabitacions.Update(tiposHabitacion);
            int result = await _hotelContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<TiposHabitacion> ObtenerTipoHabitacionAsync(int tipoHabitacionId)
        {
            var result = await _hotelContext.TiposHabitacions
                .Where(x => x.TipoHabitacionId == tipoHabitacionId)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<TiposHabitacion>> ObtenerTiposHabitacionAsync()
        {
            var result = await _hotelContext.TiposHabitacions
                .ToListAsync();

            return result;
        }
    }
}
