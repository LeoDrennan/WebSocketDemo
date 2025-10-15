using Application.DependencyInjection;
using Infrastructure.DependencyInjection;
using Presentation.DependencyInjection;
using Presentation.Hubs;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            builder.Services.AddPresentationServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            builder.Services.AddSignalR();

            var app = builder.Build();

            app.UseRouting();
            app.UseCors("AllowReactApp");

            app.MapHub<RaceSessionHub>("/session-detail").RequireCors("AllowReactApp");
            app.MapHub<SessionsHub>("/sessions").RequireCors("AllowReactApp");

            app.Run();
        }
    }
}