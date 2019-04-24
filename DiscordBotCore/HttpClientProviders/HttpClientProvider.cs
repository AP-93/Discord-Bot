using DiscordBotCore.Storage;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiscordBotCore.HttpClientProviders
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;
        private static IDataStorage _datastorage;

        public HttpClientProvider(HttpClient httpClient,IDataStorage datastorage)
        {
            _httpClient = httpClient;
            _datastorage= datastorage;
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri, string key)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add(key, _datastorage.RestoreToken(key));
   
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
