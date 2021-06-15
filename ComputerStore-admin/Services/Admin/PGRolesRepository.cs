using ComputerStoreAdmin.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Admin
{
    public class PGRolesRepository : IRolesRepository
    {
        public async Task<List<Role>> List(string role)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Roles.ToListAsync();
        }
    }
}
