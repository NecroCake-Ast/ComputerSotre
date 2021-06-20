using ComputerStoreAdmin.Models.Seller;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Seller
{
    public class PGComplectationRepository : IComplectationRepository
    {
        private string ListToString(List<ServicesList.Service> list)
        {
            string res = "";
            foreach (ServicesList.Service curElement in list)
                if (curElement.isActive)
                    res += ", " + curElement.ID;
            if (res.Length != 0)
                res = res.Substring(2);
            return "'{" + res + "}'::integer[]";
        }

        public async Task<List<Complectation>> List(string role)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Complectations.ToListAsync();
        }

        public async Task<Complectation> FindByID(string role, int id)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Complectations.SingleAsync(p => p.id == id);
        }

        public async Task<ServicesList> GetServices(string role)
        {
            ServicesList list = new ServicesList() { List = new List<ServicesList.Service>() };
            ConnectData connectData = PGAccountManager.getConnectData(role);
            string connect = "Host=" + PGContext.Host
               + ";Port=" + PGContext.Port
               + ";Database=" + PGContext.Base
               + ";Username=" + connectData.Login
               + ";Password=" + connectData.Password + ";";
            NpgsqlConnection DB = new NpgsqlConnection(connect);
            await DB.OpenAsync();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT id, name, description, price FROM get_services_list();", DB);
            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
                list.List.Add(new ServicesList.Service() {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Price = reader.GetDouble(3),
                    isActive = false
                });
            await DB.CloseAsync();
            return list;
        }

        public async Task<int> SaleComplectation(string role, ServicesList services)
        {
            int chequeID = -1;
            ConnectData connectData = PGAccountManager.getConnectData(role);
            string connect = "Host=" + PGContext.Host
               + ";Port=" + PGContext.Port
               + ";Database=" + PGContext.Base
               + ";Username=" + connectData.Login
               + ";Password=" + connectData.Password + ";";
            NpgsqlConnection DB = new NpgsqlConnection(connect);
            await DB.OpenAsync();
            NpgsqlCommand cmd = new NpgsqlCommand() {
                Connection = DB,
                CommandText = "SELECT * FROM buy_complectation(" + services.ComplectID + ", " + ListToString(services.List) + ");"
            };
            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.Read())
                chequeID = reader.GetInt32(0);
            await DB.CloseAsync();
            return chequeID;
        }
    }
}
