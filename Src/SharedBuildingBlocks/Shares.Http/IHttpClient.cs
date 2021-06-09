using System.Threading.Tasks;

namespace Shares.Http
{
    public interface IHttpClient
    {
        Task<TResult> GetAsync<TResult>(string url) where TResult : class;
    }
}
