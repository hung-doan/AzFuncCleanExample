using System.Net.Http;
using System.Threading.Tasks;
using Shares.Common.ObjectSerializer;

namespace Shares.Http
{
    public class HttpClient : IHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClient(IHttpClientFactory  httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResult> GetAsync<TResult>(string url) where TResult : class
        {
            var client = _httpClientFactory.CreateClient();
            string rawString = await client.GetStringAsync(url);
            return JsonHelper.Deserialize<TResult>(rawString);
        }
    }
}
