using System.Collections.Generic;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;

namespace Test02.DataAccess.Interfaces
{
    public interface IUserService
    {
        public Task<List<Users>> ObtenerListaAsync(string searchBy);
        public Task<Users> ObtenerAsync(int keyUser);
        public Task<Users> GuardarAsync(Users user);
        public Task<bool> ExistePinAsync(string pin);
        public Task<bool> ExistePinAsync(string pin, int keyUser);
        public Task<bool> ModificarAsync(Users user);
    }
}
