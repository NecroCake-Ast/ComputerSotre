using ComputerStoreAdmin.Models.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Items
{
    public class MockItemRepository : IItemRepository
    {
        private List<Item> _data;

        public MockItemRepository()
        {
            _data = new List<Item>()
            {
                new Item() {
                    id = 1, name = "Запчасть 1",
                    manufacturer_id = 1, manufacturer = "Производитель 1",
                    type_id = 1, type = "Тип 1"
                },
                new Item() {
                    id = 2, name = "Запчасть 2",
                    manufacturer_id = 2, manufacturer = "Производитель 2",
                    type_id = 2, type = "Тип 2"
                },
                new Item() {
                    id = 3, name = "Запчасть 3",
                    manufacturer_id = 3, manufacturer = "Производитель 3",
                    type_id = 3, type = "Тип 3"
                },
            };
        }

        public Task Add(string role, Item item)
        {
            return Task.Run(() => _data.Add(item));
        }

        public Task<Item> Find(string role, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Item>> List(string role)
        {
            return Task.Run(() => new List<Item>(_data));
        }

        public Task Remove(string role, int id)
        {
            return Task.Run(() => _data.RemoveAt(_data.FindIndex(p => p.id == id)));
        }

        public Task Update(string role, Item item)
        {
            return Task.Run(() => _data[_data.FindIndex(p => p.id == item.id)] = item);
        }
    }
}
