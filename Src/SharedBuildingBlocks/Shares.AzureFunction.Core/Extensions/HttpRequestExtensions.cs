using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shares.Common.ObjectSerializer;

namespace Shares.AzureFunction.Core.Extensions
{
    public static class HttpRequestExtensions
    {
        public static async Task<TResult> ReadJsonStringAsAsync<TResult>(this HttpRequest request) where TResult : class
        {
            return await Handler.Instance.ReadJsonStringAsAsync<TResult>(request);
        }


        #region Handler

        public class Handler
        {
            public static Handler Instance = new Handler();

            public virtual async Task<TResult> ReadJsonStringAsAsync<TResult>(HttpRequest request) where TResult : class
            {
                string requestBody;
                using (StreamReader streamReader = new StreamReader(request.Body))
                {
                    requestBody = await streamReader.ReadToEndAsync();
                }
                return JsonHelper.Deserialize<TResult>(requestBody);
            }
        }

        #endregion
    }
}
