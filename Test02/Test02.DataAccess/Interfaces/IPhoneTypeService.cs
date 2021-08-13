using System.Collections.Generic;
using System.Threading.Tasks;
using Test02.DataAccess.DbModels;

namespace Test02.DataAccess.Interfaces
{
    public interface IPhoneTypeService
    {
        public Task<List<PhoneTypes>> ObtenerListaAsync();
        public Task<PhoneTypes> ObtenerAsync(int phoneTypeId);
        public Task<PhoneTypes> ObtenerAsync(string phoneType);
    }
}
