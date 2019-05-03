using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBotCore.Fortnite
{
    public interface IApiWebRequest
    {
        // Fortnite tracker solo,duo and squad stats
        Task<FortniteTrackerApi.Stats> GetStats(string arg);

        // Fortnite tracker Lifetime stats
        Task<List<FortniteTrackerApi.LifeTimeStat>> GetLifetimeStats(string arg);

        /*
        Task<FortniteTrackerLastMatch> GetPlayerMatchesFortniteTrackerAsync(string arg);
        Task<string> GetPlayerIdAsync(string path);
        Task<string> GetPlayerName(string arg);
       Task<Players> GetPlayerMatchesAsync(string arg);
       */
    }
}
