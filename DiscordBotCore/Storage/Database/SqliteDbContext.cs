using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DiscordBotCore.Storage.Database
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string DbLocation = Directory.GetCurrentDirectory()+ @"\Storage\";
                //Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.1\DiscordBotCore.dll", @"Storage\");
             options.UseSqlite($"Data Source={DbLocation}Database.sqlite");
        }
    }
}
