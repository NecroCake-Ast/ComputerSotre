using ComputerStoreAdmin.Models.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Storage
{
    public interface IStorageRepository
    {
        public Task<List<StoredItem>> List(string userRole);
        public Task Add(string userRole, StoredItem item);
        public Task Update(string userRole, StoredItem item);
        public Task Remove(string userRole, int id);
    }
}
