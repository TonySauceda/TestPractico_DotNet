using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using Hotel.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HotelContext _hotelContext;

        public ClienteService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<List<Clientes>> ObtenerClientesAsync()
        {
            var result = await _hotelContext.Clientes.ToListAsync();

            return result;
        }
    }
}
