using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreSetup
{
    public class PlaytimeContext: DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public string DbPath { get; private set; }

        public PlaytimeContext()
        {
            var folder = Environment.SpecialFolder.Desktop;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "playtime.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}