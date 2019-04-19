using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DiscordBotCore.Storage.Database
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string DbLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.1\DiscordBotCore.dll", @"Storage\");
             options.UseSqlite($"Data Source={DbLocation}Database.sqlite");
        }
    }
}
