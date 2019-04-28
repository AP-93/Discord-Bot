using Newtonsoft.Json;
using System.Threading.Tasks;
using DiscordBotCore.Storage.Database;
using System.Linq;
using DiscordBotCore.Fortnite.FortniteApi;
using DiscordBotCore.HttpClientProviders;
using DiscordBotCore.Fortnite.FortniteTrackerApi;
using System.Collections.Generic;

namespace DiscordBotCore.Fortnite
{
    public class ApiWebRequest : IApiWebRequest
    {
        static IHttpClientProvider _httpProvider;
        static FortniteTrackerData _data;
     

        public ApiWebRequest(IHttpClientProvider httpProvider, FortniteTrackerData data)
        {
            _httpProvider = httpProvider;
            _data = data;
         
        }

        //look for all time stats  change
        public async Task<Players> GetPlayerMatchesAsync(string id)
        {
            Players players = new Players();
            var response = await _httpProvider.GetAsync("https://fortnite-user-api.theapinetwork.com/prod09/users/public/br_stats?user_id=" + id + "&platform=pc", "Authorization");
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<UserStatsV1>(
                   await response.Content.ReadAsStringAsync());

                players.matchesPlayed = data.totals.matchesplayed;
                players.kills = data.totals.kills;
                players.wins = data.totals.wins;
                players.FortniteName = data.username;
            }
            return players;
        }

        // lifetime  stats
        public async Task<FortniteTrackerApi.Stats> GetStats(string id)
        {
            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + id, "TRN-Api-Key");
            if (response.IsSuccessStatusCode)
            {
                _data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());
            }
            return _data.stats;
        }

        public async Task<FortniteTrackerLastMatch> GetPlayerMatchesFortniteTrackerAsync(string id)
        {
            var _matchData = new List<FortniteTrackerLastMatch>();


            var response = await _httpProvider.GetAsync("https://api.fortnitetracker.com/v1/profile/account/"+ id +"/matches", "TRN-Api-Key");
            if (response.IsSuccessStatusCode)
            {
                
                _matchData = JsonConvert.DeserializeObject<List<FortniteTrackerLastMatch>>(
                  await response.Content.ReadAsStringAsync());

            }
           
            return _matchData.FirstOrDefault();
        }

        /*
               public async Task<string> GetPlayerIdAsync(string path)
               {

                   PlayerID playerId = null;
                   var response = await _httpProvider.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/users/id?username=" + path);
                   if (response.IsSuccessStatusCode)
                   {
                       playerId = JsonConvert.DeserializeObject<PlayerID>(
                        await response.Content.ReadAsStringAsync());
                   }
                   return playerId.uid;
               }

               public  async Task<string> GetPlayerName(string arg)
               {
                   //string id = await GetPlayerIdAsync(arg);
                   PlayerData data = null;
                   var response = await _httpProvider.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/users/public/br_stats_v2?user_id=" + arg);
                   if (response.IsSuccessStatusCode)
                   {
                       data = JsonConvert.DeserializeObject<PlayerData>(
                        await response.Content.ReadAsStringAsync());
                   }
                   return (data.EpicName);
               }
               */

    }
}
