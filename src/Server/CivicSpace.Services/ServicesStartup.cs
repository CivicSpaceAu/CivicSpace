using CivicSpace.Services.Content;
using CivicSpace.Services.Content.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.Services
{
    public static class ServicesStartup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<INodeService, NodeService>();
        }
    }
}
