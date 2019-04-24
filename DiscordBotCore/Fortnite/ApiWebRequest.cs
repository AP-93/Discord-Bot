using Newtonsoft.Json;
using System.Threading.Tasks;
using DiscordBotCore.Storage.Database;
using System.Linq;
using DiscordBotCore.Fortnite.FortniteApi;
using DiscordBotCore.HttpClientProviders;
using DiscordBotCore.Fortnite.FortniteTrackerApi;

namespace DiscordBotCore.Fortnite
{
    public class ApiWebRequest : IApiWebRequest
    {
        static IHttpClientProvider _httpProvider;

        public ApiWebRequest(IHttpClientProvider httpProvider)
        {
            _httpProvider = httpProvider;
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

        public async Task<Players> GetPlayerMatchesFortniteTrackerAsync(string arg)
        {
            FortniteTrackerData data = new FortniteTrackerData();
            Players players = new Players();

            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + arg, "TRN-Api-Key");
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());


                players.matchesPlayed = int.Parse(data.lifeTimeStats.FirstOrDefault(o => o.key == "Matches Played").value);
                players.kills = int.Parse(data.lifeTimeStats.FirstOrDefault(o => o.key == "Kills").value);
                players.wins = int.Parse(data.lifeTimeStats.FirstOrDefault(o => o.key == "Wins").value);
                players.FortniteName = data.epicUserHandle;

            }
            return players;
        }

        // lifetime solo stats
        public async Task<string> GetSoloStats(string arg)
        {
            FortniteTrackerData data = new FortniteTrackerData();

            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + arg, "TRN-Api-Key");
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());
            }
            var path = data.stats.p2;
            return ("Matches: " + path.matches.value + "\n" +
                    "Wins: " + path.top1.value + "\n" +
                    "Kills: " + path.kills.value + "\n" +
                    "K/d: " + path.kd.value + "\n" +
                    "WinRatio: " + path.winRatio.value + "%"
                );
        }

        // lifetime duo stats
        public async Task<string> GetDuoStats(string arg)
        {
            FortniteTrackerData data = new FortniteTrackerData();

            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + arg, "TRN-Api-Key");
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());
            }
            var path = data.stats.p10;
            return ("Matches: " + path.matches.value + "\n" +
                    "Wins: " + path.top1.value + "\n" +
                    "Kills: " + path.kills.value + "\n" +
                    "K/d: " + path.kd.value + "\n" +
                    "WinRatio: " + path.winRatio.value + "%"
                );
        }
    }
}
