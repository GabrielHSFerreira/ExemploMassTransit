using ExemploMassTransit.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ExemploMassTransit.MessageConsumer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ExemploContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("Database")));
            });

            builder.UseSerilog();

            var app = builder.Build();
            app.Run();

            Log.CloseAndFlush();
        }
    }
}