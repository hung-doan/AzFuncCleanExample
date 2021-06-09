using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Shares.Http
{
    public static class ServiceCollectionExtension
    {
        public static void AddSharesHttp(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IHttpClient, HttpClient>();
        }
    }
}
