using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using Hotel.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HotelContext _hotelContext;

        public UsuarioService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<Usuarios> ObtenerUsuarioAsync(string usuario)
        {
            var result = await _hotelContext.Usuarios
                .Include(x => x.TipoUsuario)
                .Where(x => x.Usuario == usuario)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
