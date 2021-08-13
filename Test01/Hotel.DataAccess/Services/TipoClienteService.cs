using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Services
{
    public class TipoClienteService : ITipoClienteService
    {
        private readonly HotelContext _hotelContext;

        public TipoClienteService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<bool> EditarTipoClienteAsync(TiposCliente tiposCliente)
        {
            _hotelContext.TiposClientes.Update(tiposCliente);
            int result = await _hotelContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<TiposCliente> ObtenerTipoClienteAsync(int tipoClienteId)
        {
            var result = await _hotelContext.TiposClientes
                .Where(x => x.TipoClienteId == tipoClienteId)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<TiposCliente>> ObtenerTiposClienteAsync()
        {
            var result = await _hotelContext.TiposClientes
                .ToListAsync();

            return result;
        }
    }
}
