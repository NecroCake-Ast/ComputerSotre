using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Models
{
    public class PGContext : DbContext
    {
        static string DB_Connect = "";
        public DbSet<Complectation> Complectations { get; set; }

        public static void SetDBConnectSettings(string settings)
        {
            DB_Connect = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DB_Connect);
        }
    }
}
