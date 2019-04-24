using Newtonsoft.Json;
using DiscordBotCore.Fortnite.PlayerStats;
using System.Threading.Tasks;
using DiscordBotCore.Fortnite;
using DiscordBotCore.Storage.Database;
using System.Linq;
using DiscordBotCore.Storage;

namespace DiscordBotCore
{
    public class ApiWebRequest
    {
        static IHttpClientProvider _httpProvider;
        //private readonly IDataStorage _dataStorage;

        public ApiWebRequest(IHttpClientProvider httpProvider)
        {
            _httpProvider = httpProvider;
           // _dataStorage = dataStorage;
        }

        public static async Task<string> GetPlayerIdAsync(string path)
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

        public static async Task<string> GetPlayerName(string arg)
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


        //look for all time stats  change
        public static async Task<Players> GetPlayerMatchesAsync(string arg)
        {
          
            PlayerData data = new PlayerData();
            Players players = new Players();
            var response = await _httpProvider.GetAsync("https://fortnite-public-api.theapinetwork.com/prod09/users/public/br_stats_v2?user_id=" + arg);
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<PlayerData>(
                  await response.Content.ReadAsStringAsync());

                players.matchesPlayed = (int)(data.OverallData.DefaultModes.Matchesplayed + data.OverallData.LargeTeamModes.Matchesplayed + data.OverallData.LtmModes.Matchesplayed);
                players.kills = (int)(data.OverallData.DefaultModes.Kills + data.OverallData.LargeTeamModes.Kills + data.OverallData.LtmModes.Kills);
                players.wins = (int)(data.OverallData.DefaultModes.Placetop1 + data.OverallData.LargeTeamModes.Placetop1 + data.OverallData.LtmModes.Placetop1);
                players.FortniteName = data.EpicName;

            }
            return players;
        }

        public static async Task<Players> GetPlayerMatchesFortniteTrackerAsync(string arg)
        {
            //string id = await GetPlayerIdAsync(arg);
            FortniteTrackerData data = new FortniteTrackerData();
            Players players = new Players();

            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + arg);
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
        public static async Task<string> GetSoloStats(string arg)
        {
            FortniteTrackerData data = new FortniteTrackerData();

            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + arg);
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());

            }
            var path = data.stats.p2;
            return ("Matches: "+path.matches.value+"\n"+
                    "Wins: "+ path.top1.value + "\n" +
                    "Kills: "+ path.kills.value + "\n" +
                    "K/d: " + path.kd.value + "\n" +
                    "WinRatio: "+ path.winRatio.value + "%"
                );
        }
        // lifetime duo stats
        public static async Task<string> GetDuoStats(string arg)
        {
            FortniteTrackerData data = new FortniteTrackerData();

            var response = await _httpProvider.GetAsync(" https://api.fortnitetracker.com/v1/profile/pc/" + arg);
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
