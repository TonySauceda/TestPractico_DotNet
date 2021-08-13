using Hotel.DataAccess.BDModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Interfaces
{
    public interface ITipoClienteService
    {
        public Task<List<TiposCliente>> ObtenerTiposClienteAsync();
        public Task<TiposCliente> ObtenerTipoClienteAsync(int tipoClienteId);
        public Task<bool> EditarTipoClienteAsync(TiposCliente tiposCliente);
    }
}
