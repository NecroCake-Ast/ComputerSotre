using ComputerStoreAdmin.Models.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Items
{
    public interface IItemRepository
    {
        public Task<List<Item>> List(string role);
        public Task<Item> Find(string role, int id);
        public Task Add(string role, Item item);
        public Task Update(string role, Item item);
        public Task Remove(string role, int id);
        public Task<List<DeficitItem>> DeficitList(string role);
    }
}
