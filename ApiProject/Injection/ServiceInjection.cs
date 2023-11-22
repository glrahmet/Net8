using Application.Feature.CQRS.Handlers.AboutHandlers;
using Application.Feature.CQRS.Handlers.BannerHandlers;
using Application.Feature.CQRS.Handlers.BrandHandlers;
using Application.Feature.CQRS.Handlers.CarHandlers;
using Persistence.Context;

namespace ApiProject.Injection
{
    public static class ServiceInjection
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<Net8Context>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            
            services.AddScoped<GetAboutByIdCommandHandler>();
            services.AddScoped<GetAboutQueryCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            
            services.AddScoped<GetBrandByIdCommandHandler>();
            services.AddScoped<GetBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            
            services.AddScoped<GetCarByIdCommandHandler>();
            services.AddScoped<GetCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

        }
    }
}
