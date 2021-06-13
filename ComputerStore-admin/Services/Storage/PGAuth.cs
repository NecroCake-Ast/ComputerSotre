using ComputerStoreAdmin.Models.Auth;
using Npgsql;

namespace ComputerStoreAdmin.Services.Storage
{
    public static class PGAuth
    {
        private static string connectString
        {
            get {
                ConnectData connectData = PGAccountManager.getConnectData("guest");
                return "Host=" + PGContext.Host + "; Port=" + PGContext.Port
                    + ";Database=" + PGContext.Base + ";Username=" + connectData.Login
                    + ";Password=" + connectData.Password + ";";
            }
        }

        public static User Auth(LoginData data)
        {
            User user = null;
            try
            {
                NpgsqlConnection DB = new NpgsqlConnection(connectString);
                DB.Open();
                NpgsqlCommand cmd = new NpgsqlCommand() {
                    CommandText = "SELECT * FROM get_role('" + data.Login + "', '" + data.Password + "');",
                    Connection = DB
                };
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User()
                    {
                        Login = data.Login,
                        Password = data.Password,
                        Role = reader.GetString(0)
                    };
                }
            } catch { }
            return user;
        }
    }
}
