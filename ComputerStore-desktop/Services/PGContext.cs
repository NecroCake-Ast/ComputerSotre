using ComputerStoreDesk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreDesk.Services
{
    public class PGContext : DbContext
    {
        public DbSet<ItemDetails> ItemDetails { get; set; }
        public DbSet<Item> Items { get; set; }

        public static string Host     { get; set; } = "";
        public static string Port     { get; set; } = "";
        public static string Base     { get; set; } = "";
        public static string Login    { get; set; } = "";
        public static string Password { get; set; } = "";

        public static string ConnectString { get => "Host=" + Host
                                                + ";Port=" + Port
                                                + ";Database=" + Base
                                                + ";Username=" + Login
                                                + ";Password=" + Password + ";"; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectString);
        }
    }
}
