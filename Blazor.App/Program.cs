using System.Net.Http.Headers;
using Blazor.App.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using SimpleProgram.Lib;


namespace Blazor.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            return BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
        }
    }
}