using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 

namespace Application.Services
{
    public static class ServiceRegistration
    {
        public static void SaveApplicationService( this IServiceCollection services,IConfiguration configuration)
        {
           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
    }
}
