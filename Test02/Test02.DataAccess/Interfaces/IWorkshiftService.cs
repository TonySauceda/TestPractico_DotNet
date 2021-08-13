using System.Collections.Generic;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;

namespace Test02.DataAccess.Interfaces
{
    public interface IWorkshiftService
    {
        public Task<List<Workshifts>> ObtenerListaAsync();
        public Task<Workshifts> ObtenerAsync(int workshiftId);
        public Task<Workshifts> ObtenerAsync(string workshift);
    }
}
