using System.Net.Http;
using System.Threading.Tasks;

namespace DiscordBotCore.HttpClientProviders
{
    public interface IHttpClientProvider
    {
        Task<HttpResponseMessage> GetAsync(string requestUri, string key);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);       
    }
}
