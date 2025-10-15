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

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            builder.Services.AddSignalR();

            var app = builder.Build();

            app.MapHub<RaceSessionHub>("/session-detail");

            app.Run();
        }
    }
}