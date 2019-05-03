using DiscordBotCore.HttpClientProviders;
using DiscordBotCore.Storage;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBotCore.EpicGamesAPI
{
    public class Login : ILogin
    {
        private static IHttpClientProvider _clientProvider;
        private static IDataStorage _dataStorage;
        private string clientLauncherToken;
        private string oauthTokenEndpoint;
        private string playerIdEndpoint;

        public Login(IHttpClientProvider clientProvider, IDataStorage dataStorage)
        {
            _clientProvider = clientProvider;
            _dataStorage = dataStorage;
            GetConfigData();
        }

        public async Task<AccessToken> GetToken()
        {
            var header = _clientProvider.GetHttpClientHeader();

            //Define Headers
            header.Accept.Clear();
            header.Accept.Add(_clientProvider.GetNewMTVQHeaderValue("application/json"));
            header.Authorization = _clientProvider.GetAuthenticationHeaderValue("Basic", clientLauncherToken);

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
            requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            //Request Token
            var request = await _clientProvider.PostAsync(oauthTokenEndpoint, _clientProvider.MakeRequestBody(requestData));
            var response = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AccessToken>(response);
        }

        public async Task<string> GetNameFromID(string id)
        {
            var header = _clientProvider.GetHttpClientHeader();

            //Define Headers
            header.Accept.Clear();
            header.Accept.Add(_clientProvider.GetNewMTVQHeaderValue("application/json"));
            header.Authorization = _clientProvider.GetAuthenticationHeaderValue("bearer", (await GetToken()).access_token);

            //Request data
            var request = await _clientProvider.GetAsync(playerIdEndpoint + id);

            var a = JsonConvert.DeserializeObject<NameAndID[]>(await request.Content.ReadAsStringAsync());
         
            return a[0].DisplayName;
        }

        public void GetConfigData()
        {
            clientLauncherToken = _dataStorage.RestoreToken("CLIENT_LAUNCHER_TOKEN");
            oauthTokenEndpoint = _dataStorage.RestoreToken("OAUTH_TOKEN");
            playerIdEndpoint = _dataStorage.RestoreToken("PlayerById");
        }
    }
}
