using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DiscordBotCore.Storage.Database
{
    public static class Data
    { 
        public static List <Players> GetData()
        {
            List <Players> plyrList = new List<Players>();
            using (var db = new SqliteDbContext())
            {
                plyrList = (from p in db.Players select p).ToList();
                return plyrList;
            }

        }

        public static async Task SaveChanges(int _ID, int _matchesPlayed, string FortniteName)
        {
            using(var db = new SqliteDbContext())
            {
                if(db.Players.Where(x => x.ID == _ID).Count() < 1)
                {
                    db.Players.Add(new Players
                    {
                        ID = _ID,
                        matchesPlayed = _matchesPlayed
                    });
                }
                else
                {
                    Players current = db.Players.Where(x => x.ID == _ID).FirstOrDefault();
                    current.matchesPlayed = _matchesPlayed;
                    if (current.FortniteName != FortniteName)
                        current.FortniteName = FortniteName;
                    db.Players.Update(current);
                }
                await db.SaveChangesAsync();

            }

        }
    }
}
