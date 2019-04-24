using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiscordBotCore.Fortnite
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;


        public HttpClientProvider(HttpClient httpClient)
        {
         
            _httpClient = httpClient;
           
            // _httpClient.DefaultRequestHeaders.Authorization               
            //    = new AuthenticationHeaderValue("TRN-Api-Key", "87b7264b-aa8f-405b-9d79-06c82af49eb0");
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)//, string key, string token)
        {

            _httpClient.DefaultRequestHeaders.Add("TRN-Api-Key", "");
            //_httpClient.DefaultRequestHeaders.Add("Authorization", "TRN-Api-Key" + "87b7264b-aa8f-405b-9d79-06c82af49eb0");
            return _httpClient.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return _httpClient.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return _httpClient.PutAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return _httpClient.DeleteAsync(requestUri);
        }
    }
}
