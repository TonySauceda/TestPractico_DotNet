using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;
using Test02.DataAccess.Interfaces;

namespace Test02.DataAccess.Services
{
    public class PhoneTypeService : IPhoneTypeService
    {
        private readonly DBContext _dbContext;

        public PhoneTypeService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PhoneTypes> ObtenerAsync(int phoneTypeId)
        {
            var result = await _dbContext.PhoneTypes
                .Where(x => x.PhoneTypeId == phoneTypeId)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<PhoneTypes> ObtenerAsync(string phoneType)
        {
            var result = await _dbContext.PhoneTypes
                .Where(x => x.PhoneType == phoneType)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<PhoneTypes>> ObtenerListaAsync()
        {
            var result = await _dbContext.PhoneTypes
               .ToListAsync();

            return result;
        }
    }
}
