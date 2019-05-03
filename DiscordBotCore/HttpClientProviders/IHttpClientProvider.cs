using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiscordBotCore.HttpClientProviders
{
    public interface IHttpClientProvider
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
        HttpClient GetHttpClient();
        HttpRequestHeaders GetHttpClientHeader();
        MediaTypeWithQualityHeaderValue GetNewMTVQHeaderValue(string value);
        AuthenticationHeaderValue GetAuthenticationHeaderValue(string type, string clientLauncherToken);
        FormUrlEncodedContent MakeRequestBody(List<KeyValuePair<string, string>> requestData);
    }
}
