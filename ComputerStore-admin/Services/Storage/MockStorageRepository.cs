using ComputerStoreAdmin.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Storage
{
    public class MockStorageRepository : IStorageRepository
    {
        private List<StoredItem> _data;

        public MockStorageRepository()
        {
            _data = new List<StoredItem>()
            {
                new StoredItem() {
                    id = 1,
                    id_item = 1,
                    item = "Тип Производитель Деталь 1",
                    buy_date = DateTime.Now,
                    buy_price = 10000,
                    place = "Солнечная 22, строение 4",
                    isOnStorage = true
                },
                new StoredItem() {
                    id = 2,
                    id_item = 2,
                    item = "Тип Производитель Деталь 2",
                    buy_date = DateTime.Now,
                    buy_price = 10000,
                    place = "Солнечная 22, строение 4",
                    isOnStorage = true
                },
                new StoredItem() {
                    id = 3,
                    id_item = 3,
                    item = "Тип Производитель Деталь 3",
                    buy_date = DateTime.Now,
                    buy_price = 9000,
                    place = "Солнечная 22, строение 5",
                    isOnStorage = false
                }
            };
        }

        public Task Add(string userRole, StoredItem item)
        {
            return Task.Run(() => _data.Add(item));
        }

        public Task<List<StoredItem>> Find(string role, StoredItemSearchData pred)
        {
            throw new NotImplementedException();
        }

        public Task<StoredItem> Find(string userRole, int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StoredItem>> List(string userRole)
        {
            return Task.Run(() => new List<StoredItem>(_data));
        }

        public Task Remove(string userRole, int id)
        {
            return Task.Run(() => _data.RemoveAt(_data.FindIndex(p => p.id == id)));
        }

        public Task Update(string userRole, StoredItem item)
        {
            return Task.Run(() => _data[_data.FindIndex(p => p.id == item.id)] = item);
        }
    }
}
