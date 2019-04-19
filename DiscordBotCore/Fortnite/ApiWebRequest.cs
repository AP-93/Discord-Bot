using Newtonsoft.Json;
using DiscordBotCore.Fortnite.PlayerStats;
using System.Threading.Tasks;
using DiscordBotCore.Fortnite;
using DiscordBotCore.Storage.Database;

namespace DiscordBotCore
{
    public class ApiWebRequest
    {
        static IHttpClientProvider _httpProvider;

        public ApiWebRequest(IHttpClientProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public static async Task<string> GetPlayerIdAsync(string path)
        {
            PlayerID playerId = null;
            var response = await _httpProvider.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/users/id?username="+path);
            if (response.IsSuccessStatusCode)
            {
                playerId = JsonConvert.DeserializeObject<PlayerID>(
                 await response.Content.ReadAsStringAsync());
            }
            return playerId.uid;
        }

        public static async Task<string> GetPlayerStats (string arg)
        {
            //string id = await GetPlayerIdAsync(arg);
            PlayerData data = null;
            var response = await _httpProvider.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/users/public/br_stats_v2?user_id=" + arg);
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<PlayerData>(
                 await response.Content.ReadAsStringAsync());   
            }
            return ("Name: "+data.EpicName+"\n"+
                    "Wins in default solo, duo and squad modes: "+data.OverallData.DefaultModes.Placetop1);
        }

        public static async Task<Players> GetPlayerMatches(string arg)
        {
            //string id = await GetPlayerIdAsync(arg);
            PlayerData data = new PlayerData();
            Players players = new Players() ;
            var response = await _httpProvider.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/users/public/br_stats_v2?user_id=" + arg);
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<PlayerData>(
                 await response.Content.ReadAsStringAsync());
            }
            players.matchesPlayed =(int) (data.OverallData.DefaultModes.Matchesplayed + data.OverallData.LargeTeamModes.Matchesplayed + data.OverallData.LtmModes.Matchesplayed);
            players.FortniteName = data.EpicName;
            return players;
        }
    }
}
