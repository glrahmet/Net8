using Net8.Data.Context;
using System.Diagnostics;
using System.Net;

namespace Net8.UI.MiddleWare.Worker
{
    public class WorkerGround: BackgroundService
    {
        private readonly Net8Context _context;
        public readonly IConfiguration _configuration;

        public WorkerGround(IServiceScopeFactory context, IConfiguration configuration)
        {
            _context = context.CreateScope().ServiceProvider.GetRequiredService<Net8Context>();
            _configuration = configuration;
        }

       

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_configuration.GetValue<bool>("WorkerCheckTime:WorkerStartStop"))
            {
                while (true)
                { 
                    stoppingToken.ThrowIfCancellationRequested();
                   ///Metot Adi
                    await Task.Delay(_configuration.GetValue<int>("WorkerCheckTime:WorkerCheckTime"), stoppingToken);
                }
            }
        }
    }
}
