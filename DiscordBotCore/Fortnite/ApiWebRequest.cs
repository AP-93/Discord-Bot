using Newtonsoft.Json;
using DiscordBotCore.Fortnite.PlayerStats;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiscordBotCore
{
    class ApiWebRequest
    {
        static HttpClient _client;

        public ApiWebRequest(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://fortnite-public-api.theapinetwork.com/prod09/users/id?username=");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<PlayerID> GetPlayerIdAsync(string path)
        {
            PlayerID playerId = null;
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress+path);
            if (response.IsSuccessStatusCode)
            {
                playerId = JsonConvert.DeserializeObject<PlayerID>(
                 await response.Content.ReadAsStringAsync());
                Console.WriteLine(playerId.uid);
            }
         
            return playerId;
        }
    }
}
