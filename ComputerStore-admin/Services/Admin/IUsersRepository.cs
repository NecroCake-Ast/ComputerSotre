using ComputerStoreAdmin.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Admin
{
    public interface IUsersRepository
    {
        public Task<List<UserData>> List(string role);
        public Task<List<UserData>> Find(string role, UserSearchData data);
        public Task<bool> isRegistered(string role, string login);
        public Task Add(string role, RegistrationData data);
        public Task Update(string role, ChangePasswordData data);
        public Task Remove(string role, string name);
    }
}
