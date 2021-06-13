using ComputerStoreAdmin.Models.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services
{
    public class PGContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<StoredItem> Storage { get; set; }

        public static string Host { get; set; } = "";
        public static string Port { get; set; } = "";
        public static string Base { get; set; } = "";
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";

        public string ConnectString
        {
            get => "Host=" + Host
               + ";Port=" + Port
               + ";Database=" + Base
               + ";Username=" + Login
               + ";Password=" + Password + ";";
        }

        public static void Configure(IConfiguration configuration)
        {
            Host = configuration.GetValue("PG_Host", "localhost");
            Port = configuration.GetValue("PG_Port", "5432");
            Base = configuration.GetValue("PG_Database", "computer_store");
        }

        public PGContext(ConnectData data)
        {
            Login = data.Login;
            Password = data.Password;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectString);
        }
    }
}
