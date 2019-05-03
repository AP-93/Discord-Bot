using DiscordBotCore.Storage;
using DiscordBotCore.HttpClientProviders;
using DiscordBotCore.Fortnite.FortniteTrackerApi;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBotCore.Fortnite
{
    public class ApiWebRequest : IApiWebRequest
    {
        private static IHttpClientProvider _clientProvider;
        private static IDataStorage _dataStorage;
        private string TrnApiKey;
        private string FortniteTrackerEndpoint;

        public ApiWebRequest(IHttpClientProvider clientProvider, IDataStorage dataStorage)
        {
            _clientProvider = clientProvider;
            _dataStorage = dataStorage;

            GetConfigData();
        }

        // Fortnite tracker solo,duo and squad stats  fortnitetracker.com
        public async Task<FortniteTrackerApi.Stats> GetStats(string id)
        {
            FortniteTrackerData data = new FortniteTrackerData();
            var header = _clientProvider.GetHttpClientHeader();

            header.Clear();
            header.Add("TRN-Api-Key", TrnApiKey);

            var response = await _clientProvider.GetAsync(FortniteTrackerEndpoint + id);
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());
            }
            return data.stats;
        }

        // Fortnite tracker Lifetime stats   fortnitetracker.com
        public async Task<List<FortniteTrackerApi.LifeTimeStat>> GetLifetimeStats(string id)
        {
            FortniteTrackerData data = new FortniteTrackerData();
            var header = _clientProvider.GetHttpClientHeader();

            header.Clear();
            header.Add("TRN-Api-Key", TrnApiKey);

            var response = await _clientProvider.GetAsync(FortniteTrackerEndpoint + id);
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<FortniteTrackerData>(
                  await response.Content.ReadAsStringAsync());
            }
            return data.lifeTimeStats as List<FortniteTrackerApi.LifeTimeStat>;
        }

        public void GetConfigData()
        {
            TrnApiKey = _dataStorage.RestoreToken("TRN-Api-Key");
            FortniteTrackerEndpoint = _dataStorage.RestoreToken("trackerPlayerStats");
        }

        /*
        //look for all time stats  change  fortniteapi
        public async Task<Players> GetPlayerMatchesAsync(string id)
        {
            Players players = new Players();

            var header = _clientProvider.GetHttpClientHeader();

            header.Clear();
            header.Add("Authorization", "key");


            var response = await _clientProvider.GetAsync("https://fortnite-user-api.theapinetwork.com/prod09/users/public/br_stats?user_id=" + id + "&platform=pc");
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
        }*/

        /*
    //matches fortnitetracker.com
    public async Task<FortniteTrackerLastMatch> GetPlayerMatchesFortniteTrackerAsync(string id)
    {
        var _matchData = new List<FortniteTrackerLastMatch>();

        var response = await _clientProvider.GetAsync("https://api.fortnitetracker.com/v1/profile/account/" + id + "/matches");
        if (response.IsSuccessStatusCode)
        {

            _matchData = JsonConvert.DeserializeObject<List<FortniteTrackerLastMatch>>(
              await response.Content.ReadAsStringAsync());
        }
        return _matchData.FirstOrDefault();
    }*/

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
