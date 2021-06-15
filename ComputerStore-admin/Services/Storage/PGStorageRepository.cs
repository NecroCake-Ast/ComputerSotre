using ComputerStoreAdmin.Models.Store;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Storage
{
    public class PGStorageRepository : IStorageRepository
    {
        public async Task Add(string userRole, StoredItem item)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@id", item.id_item),
                new NpgsqlParameter("@price", item.buy_price),
                new NpgsqlParameter("@place", item.place),
                new NpgsqlParameter("@store", item.isOnStorage),
            };
            await context.Database.ExecuteSqlRawAsync("CALL add_to_store(@id, @price, @place, @store)", parameters);
        }

        public async Task<List<StoredItem>> Find(string userRole, StoredItemSearchData pred)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Etalon", (object)pred.Etalon??DBNull.Value),
                new NpgsqlParameter("@StartDate", (object)pred.StartDateDiap??DBNull.Value),
                new NpgsqlParameter("@EndDate", (object)pred.EndDateDiap??DBNull.Value)
            };
            return await context.Storage
                .FromSqlRaw("SELECT * FROM find_in_storage(@Etalon, @StartDate, @EndDate)", parameters)
                .ToListAsync();
        }

        public async Task<StoredItem> Find(string userRole, int id)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            return await context.Storage.SingleAsync(p => p.id == id);
        }

        public async Task<List<StoredItem>> List(string userRole)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            return await context.Storage.ToListAsync();
        }

        public async Task Remove(string userRole, int id)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@storedID", id)
            };
            await context.Database.ExecuteSqlRawAsync("CALL delete_from_store(@storedID)", parameters);
        }

        public async Task Update(string userRole, StoredItem item)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(userRole));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@id", item.id),
                new NpgsqlParameter("@idItem", item.id_item),
                new NpgsqlParameter("@price", item.buy_price),
                new NpgsqlParameter("@place", item.place),
                new NpgsqlParameter("@store", item.isOnStorage),
            };
            await context.Database.ExecuteSqlRawAsync("CALL update_in_store(@id, @idItem, @price, @place, @store)", parameters);
        }
    }
}
