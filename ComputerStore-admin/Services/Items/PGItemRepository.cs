using ComputerStoreAdmin.Models.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Items
{
    public class PGItemRepository : IItemRepository
    {
        public Task Add(string role, Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> Find(string role, int id)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Items.SingleAsync(p => p.id == id);
        }

        public async Task<List<Item>> List(string role)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Items.ToListAsync();
        }

        public Task Remove(string role, int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string role, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
