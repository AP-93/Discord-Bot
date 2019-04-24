using DiscordBotCore.Storage.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCore.Fortnite
{
    public interface IApiWebRequest
    {
          Task<string> GetPlayerIdAsync(string path);
        Task<string> GetPlayerName(string arg);
            //look for all time stats  change
        Task<Players> GetPlayerMatchesAsync(string arg);
         Task<Players> GetPlayerMatchesFortniteTrackerAsync(string arg);
             // lifetime solo stats
         Task<string> GetSoloStats(string arg);
             // lifetime duo stats
         Task<string> GetDuoStats(string arg);
    }
}
