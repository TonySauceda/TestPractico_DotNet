using Hotel.DataAccess.BDModels;
using Hotel.DataAccess.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Interfaces
{
    public interface IHabitacionService
    {
        public Task<List<Habitaciones>> ObtenerHabitacionesAsync(HabitacionFilter habitacionFilter);
        public Task<Habitaciones> ObtenerHabitacionDisponibleAsync(DateTime fechaInicial, DateTime fechaFinal, int tipoHabitacion);
    }
}
