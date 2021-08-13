using Hotel.DataAccess.BDModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Interfaces
{
    public interface ITipoHabitacionService
    {
        public Task<List<TiposHabitacion>> ObtenerTiposHabitacionAsync();
        public Task<TiposHabitacion> ObtenerTipoHabitacionAsync(int tipoHabitacionId);
        public Task<bool> EditarTipoHabitacionAsync(TiposHabitacion tiposHabitacion);
    }
}
