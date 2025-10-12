using Application.DependencyInjection;
using Infrastructure.DependencyInjection;
using Presentation.Hubs;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            var app = builder.Build();

            app.MapHub<RaceStateHub>("/racehub");

            app.Run();
        }
    }
}