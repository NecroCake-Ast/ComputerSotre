using Avalonia.Interactivity;
using ComputerStoreDesk.Models;
using ComputerStoreDesk.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreDesk.ViewModels
{
    class AuthorizationViewModel : ViewModelBase
    {
        MainWindowViewModel _parent;
        string Login    { get; set; } = "vasya_petrov";
        string Password { get; set; } = "qwerty";

        public AuthorizationViewModel(MainWindowViewModel parent)
        {
            _parent = parent;
        }

        private string getRole()
        {
            NpgsqlConnection DB = new NpgsqlConnection(PGContext.ConnectString);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT * FROM get_role()";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return reader.GetString(0);
            return "";
        }

        public void onLoginClick()
        {
            try
            {
                PGContext.Host = "localhost";
                PGContext.Port = "5432";
                PGContext.Base = "computer_store";
                PGContext.Login = Login;
                PGContext.Password = Password;
                PGContext context = new PGContext();
                Program.itemRepositary = new PGItemRepositary(context);
                string userRole = getRole();
                switch (userRole)
                {
                    case "store_storekeeper":
                        _parent.ShowKeeper();
                        break;
                }
            } catch
            {

            }
        }
    }
}
