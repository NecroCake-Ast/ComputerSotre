using ComputerStoreAdmin.Models.Admin;
using ComputerStoreAdmin.Models.Seller;
using ComputerStoreAdmin.Models.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComputerStoreAdmin.Services
{
    public class PGContext : DbContext
    {
        public DbSet<Item>          Items          { get; set; }  //!< Список деталей
        public DbSet<DeficitItem>   DeficitItems   { get; set; }  //!< Список деталей, которых почти нет в наличии
        public DbSet<StoredItem>    Storage        { get; set; }  //!< Список деталей на складе
        public DbSet<UserData>      Users          { get; set; }  //!< Список зарегистрированных пользователей
        public DbSet<Role>          Roles          { get; set; }  //!< Список ролей
        public DbSet<Complectation> Complectations { get; set; }  //!< Списко комплектаций
        public DbSet<Cheque>        Cheques        { get; set; }  //!< Список чеков

        public static string Host     { get; set; } = "";  //!< Хост для подключения к БД
        public static string Port     { get; set; } = "";  //!< Порт для подключения к БД
        public static string Base     { get; set; } = "";  //!< Название базы
        public string        Login    { get; set; } = "";  //!< Роль в БД
        public string        Password { get; set; } = "";  //!< Пароль от роли в БД

        public string ConnectString
        {
            get => "Host=" + Host
               + ";Port=" + Port
               + ";Database=" + Base
               + ";Username=" + Login
               + ";Password=" + Password + ";"; }      //!< Строка подключения

        /*
         * \brief Установка хоста, порта и названия БД из конфигурации приложения
         */
        public static void Configure(IConfiguration configuration)
        {
            Host = configuration.GetValue("PG_Host", "localhost");
            Port = configuration.GetValue("PG_Port", "5432");
            Base = configuration.GetValue("PG_Database", "computer_store");
        }

        /*
         * \brief Конструктор с указанием роли и пароля
         */
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
