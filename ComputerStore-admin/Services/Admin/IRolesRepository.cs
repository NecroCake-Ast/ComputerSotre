using ComputerStoreAdmin.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Admin
{
    public interface IRolesRepository
    {
        public Task<List<Role>> List(string role);
    }
}
