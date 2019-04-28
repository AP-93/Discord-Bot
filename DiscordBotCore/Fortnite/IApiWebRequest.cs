using DiscordBotCore.Fortnite.FortniteTrackerApi;
using DiscordBotCore.Storage.Database;
using System.Threading.Tasks;

namespace DiscordBotCore.Fortnite
{
    public interface IApiWebRequest
    {
        // Task<string> GetPlayerIdAsync(string path);
        // Task<string> GetPlayerName(string arg);

        //look for all time stats change
        Task<Players> GetPlayerMatchesAsync(string arg);

        Task<FortniteTrackerLastMatch> GetPlayerMatchesFortniteTrackerAsync(string arg);
       
        // lifetime stats
        Task<FortniteTrackerApi.Stats> GetStats(string arg);

    }
}
