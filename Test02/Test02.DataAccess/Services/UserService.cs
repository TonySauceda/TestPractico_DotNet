using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test02.Core.Requests;
using Test02.DataAccess.DbModels;
using Test02.DataAccess.Interfaces;

namespace Test02.DataAccess.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext _dbContext;

        public UserService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistePinAsync(string pin)
        {
            var result = await _dbContext.Users
                .Where(x => x.Pin == pin)
                .AnyAsync();

            return result;
        }

        public async Task<bool> ExistePinAsync(string pin, int keyUser)
        {
            var result = await _dbContext.Users
                .Where(x => x.Pin == pin && x.KeyUser != keyUser)
                .AnyAsync();

            return result;
        }

        public async Task<Users> GuardarAsync(Users user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var result = await _dbContext.Users
                .Where(x => x.Pin == user.Pin)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Users> ObtenerAsync(int keyUser)
        {
            var result = await _dbContext.Users
                .Include(x => x.Gender)
                .Include(x => x.Workshift)
                .Include(x => x.Phones)
                .Where(x => x.KeyUser == keyUser)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Users>> ObtenerListaAsync(string searchBy)
        {
            List<Users> result;

            IQueryable<Users> query = _dbContext.Users
                .Include(x => x.Gender)
                .Include(x => x.Workshift)
                .Include(x => x.Phones)
                .ThenInclude(x => x.PhoneType);

            if (string.IsNullOrWhiteSpace(searchBy))
                result = await query.ToListAsync();
            else
            {
                result = new List<Users>();
                var searchArr = searchBy.Split(',');
                int[] ids = new int[0];
                foreach (var search in searchArr)
                {
                    result.AddRange(await query
                    .Where(x =>
                        !ids.Contains(x.KeyUser) &&
                        (
                            x.Name.Contains(search) ||
                            x.Lastname.Contains(search) ||
                            x.Surname.Contains(search) ||
                            x.Rfc.Contains(search))
                        )
                    .ToListAsync());

                    ids = result.Select(x => x.KeyUser).Distinct().ToArray();
                }
            }

            return result;
        }

        public async Task<bool> ModificarAsync(Users user)
        {
            _dbContext.Users.Update(user);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
