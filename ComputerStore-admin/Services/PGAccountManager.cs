using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services
{
    public class ConnectData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public static class PGAccountManager
    {
        private static string _adminLogin;
        private static string _adminPassword;
        private static string _sellerLogin;
        private static string _sellerPassword;
        private static string _marketerLogin;
        private static string _marketerPassword;
        private static string _agentLogin;
        private static string _agentPassword;
        private static string _storekeeperLogin;
        private static string _storekeeperPassword;
        private static string _guestLogin;
        private static string _guestPassword;

        public static void Configure(IConfiguration configuration)
        {
            // Администратор
            _adminLogin = configuration.GetValue("PG_Admin_Login", "store_admin");
            _adminPassword = configuration.GetValue("PG_Admin_Password", "qwerty");
            // Продавец
            _sellerLogin = configuration.GetValue("PG_Seller_Login", "store_seller");
            _sellerPassword = configuration.GetValue("PG_Seller_Password", "qwerty");
            // Маркетолог
            _marketerLogin = configuration.GetValue("PG_Marketer_Login", "store_marketer");
            _marketerPassword = configuration.GetValue("PG_Marketer_Password", "qwerty");
            // Представитель
            _agentLogin = configuration.GetValue("PG_Agent_Login", "store_agent");
            _agentPassword = configuration.GetValue("PG_Agent_Password", "qwerty");
            // Кладовщик
            _storekeeperLogin = configuration.GetValue("PG_Storekeeper_Login", "store_storekeeper");
            _storekeeperPassword = configuration.GetValue("PG_Storekeeper_Password", "qwerty");
            // Гость
            _guestLogin = configuration.GetValue("PG_Guest_Login", "store_storekeeper");
            _guestPassword = configuration.GetValue("PG_Guest_Password", "qwerty");
        }

        public static ConnectData getConnectData(string role)
        {
            switch (role)
            {
                case "admin":
                    return new ConnectData() { Login = _adminLogin, Password = _adminPassword };
                case "seller":
                    return new ConnectData() { Login = _sellerLogin, Password = _sellerPassword };
                case "marketer":
                    return new ConnectData() { Login = _marketerLogin, Password = _marketerPassword };
                case "agent":
                    return new ConnectData() { Login = _agentLogin, Password = _agentPassword };
                case "storekeeper":
                    return new ConnectData() { Login = _storekeeperLogin, Password = _storekeeperPassword };
                case "guest":
                    return new ConnectData() { Login = _guestLogin, Password = _guestPassword };
            }
            return null;
        }
    }
}
