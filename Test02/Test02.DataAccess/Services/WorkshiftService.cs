using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;
using Test02.DataAccess.Interfaces;

namespace Test02.DataAccess.Services
{
    public class WorkshiftService : IWorkshiftService
    {
        private readonly DBContext _dbContext;

        public WorkshiftService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Workshifts> ObtenerAsync(int workshiftId)
        {
            var result = await _dbContext.Workshifts
                 .Where(x => x.WorkshiftId == workshiftId)
                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Workshifts> ObtenerAsync(string workshift)
        {
            var result = await _dbContext.Workshifts
                 .Where(x => x.Workshift == workshift)
                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Workshifts>> ObtenerListaAsync()
        {
            var result = await _dbContext.Workshifts
                 .ToListAsync();

            return result;
        }
    }
}
