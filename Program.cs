using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace StockBot
{
    class Program
    {
        static public IHost host;
        static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            host = CreateHostBuilder(args)
                    .UseEnvironment("Development")
                    .Build();

            
            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args);
    }
}
