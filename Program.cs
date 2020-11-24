using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace StockBot
{
    class Program
    {
        static public IHost host;
        static Task Main(string[] args)
        {
            try
            {
                host = CreateHostBuilder(args)
                        .Build();   

                Log.Information("Hello World!");                

                return host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return Task.FromException(ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseEnvironment("Development")
                .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.FromLogContext());
    }
}
