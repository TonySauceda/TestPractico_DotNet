using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Interfaces
{
    public interface IUsuarioService
    {
        public Task<Usuarios> ObtenerUsuarioAsync(string usuario);
    }
}
