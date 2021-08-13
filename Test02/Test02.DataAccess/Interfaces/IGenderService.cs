using System.Collections.Generic;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;

namespace Test02.DataAccess.Interfaces
{
    public interface IGenderService
    {
        public Task<List<Genders>> ObtenerListaAsync();
        public Task<Genders> ObtenerAsync(int genderId);
        public Task<Genders> ObtenerAsync(string gender);
    }
}
