using ComputerStoreAdmin.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Admin
{
    public class PGUsersRepository : IUsersRepository
    {
        public async Task Add(string role, RegistrationData data)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@log", data.login),
                new NpgsqlParameter("@pass", data.password),
                new NpgsqlParameter("@conf", data.confirm),
                new NpgsqlParameter("@role", data.role),
            };
            await context.Database.ExecuteSqlRawAsync("CALL reg_user(@log, @pass, @conf, @role)", parameters);
        }

        public async Task<List<UserData>> Find(string role, UserSearchData data)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@name", (object)data.LoginEtalon??DBNull.Value)
            };
            return await context.Users.FromSqlRaw("SELECT * FROM find_user(@name)", parameters).ToListAsync();
        }

        public async Task<bool> isRegistered(string role, string login)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Users.SingleAsync(p => p.login == login) != null;
        }

        public async Task<List<UserData>> List(string role)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Users.ToListAsync();
        }

        public async Task Remove(string role, string name)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@name", (object)name??DBNull.Value)
            };
            await context.Database.ExecuteSqlRawAsync("CALL delete_user(@name)", parameters);
        }

        public async Task Update(string role, ChangePasswordData data)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@log", data.login),
                new NpgsqlParameter("@pass", data.password),
                new NpgsqlParameter("@conf", data.confirm)
            };
            await context.Database.ExecuteSqlRawAsync("CALL update_user(@log, @pass, @conf)", parameters);
        }
    }
}
