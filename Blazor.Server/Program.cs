using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Blazor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5001);
                })
                .Build();
    }
}
