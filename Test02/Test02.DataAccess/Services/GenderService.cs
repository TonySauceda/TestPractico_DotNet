using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;
using Test02.DataAccess.Interfaces;

namespace Test02.DataAccess.Services
{
    public class GenderService : IGenderService
    {
        private readonly DBContext _dbContext;

        public GenderService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genders> ObtenerAsync(int genderId)
        {
            var result = await _dbContext.Genders
                .Where(x => x.GenderId == genderId)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Genders> ObtenerAsync(string gender)
        {
            var result = await _dbContext.Genders
                .Where(x => x.Gender == gender)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Genders>> ObtenerListaAsync()
        {
            var result = await _dbContext.Genders
                .ToListAsync();

            return result;
        }
    }
}
