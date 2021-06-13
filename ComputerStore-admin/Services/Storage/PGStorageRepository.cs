using ComputerStoreAdmin.Models.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Storage
{
    public class PGStorageRepository : IStorageRepository
    {
        public Task Add(string userRole, StoredItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StoredItem>> List(string userRole)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            return await context.Storage.ToListAsync();
        }

        public Task Remove(string userRole, int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string userRole, StoredItem item)
        {
            throw new NotImplementedException();
        }
    }
}
