using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiscordBotCore.HttpClientProviders
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private static HttpClient _httpClient;

        public HttpClientProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
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

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        public HttpRequestHeaders GetHttpClientHeader()
        {
            return  _httpClient.DefaultRequestHeaders;
        }

        public MediaTypeWithQualityHeaderValue GetNewMTVQHeaderValue(string value)
        {
            return new MediaTypeWithQualityHeaderValue(value);
        }

        public AuthenticationHeaderValue GetAuthenticationHeaderValue(string type, string clientLauncherToken)

        {
            return new AuthenticationHeaderValue(type, clientLauncherToken);
        }

        public FormUrlEncodedContent MakeRequestBody(List<KeyValuePair<string, string>> requestData)
        {
            return new FormUrlEncodedContent(requestData);
        }
    }
}
