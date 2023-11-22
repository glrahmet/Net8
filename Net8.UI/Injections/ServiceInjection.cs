using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Net8.Data.UnitOfWork;
using Net8.Data.Repositories.Abstract;
using Net8.Data.Repositories.Concrete;

namespace Net8.UI.Injections
{
    public static class ServiceInjection
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICarRepository, CarRepository>();

        }

    }
}
