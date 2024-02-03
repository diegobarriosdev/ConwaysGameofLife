#define LOCALSTORAGE
using ConwaysGameofLife.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConwaysGameofLife.Persistence.Db
{
    public class GameOfLifeDb : DbContext
    {

#if LOCALSTORAGE
        public string DbPath { get; }
        public GameOfLifeDb()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "GameOfLife.db");
        }
        // The following configures EF to create a Sqlite database file in the "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
#else
        // Enabling storage in the real-db
        // public GameOfLifeDbContext(DbContextOptions<GameOfLifeDbContext> options) : base(options) {}
#endif

        public DbSet<BoardEntity> BoardsEntity => Set<BoardEntity>();
    }
}
