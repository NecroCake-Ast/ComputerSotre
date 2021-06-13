using ComputerStoreAdmin.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Items
{
    public interface ItemRepository
    {
        public Task<List<Item>> List();
        public Task Add(Item item);
        public Task Update(Item item);
        public Task Remove(int id);
    }
}
