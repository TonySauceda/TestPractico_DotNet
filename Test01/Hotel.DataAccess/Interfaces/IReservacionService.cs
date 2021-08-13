using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Interfaces
{
    public interface IReservacionService
    {
        public Task<List<Reservaciones>> ObtenerReservacionesAsync(ReservacionFilter filtros);
        public Task<bool> GuardarReservacionAsync(Reservaciones reservacion);
        public Task<bool> EliminarReservacionAsync(int reservacionId);
    }
}
