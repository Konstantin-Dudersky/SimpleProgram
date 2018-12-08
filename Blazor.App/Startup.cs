using System.Globalization;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.App.Services;
using SimpleProgram.Lib;

// ReSharper disable once IdentifierTypo
namespace Blazor.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
            var data = new Data();
            services.AddSingleton(data);
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            
            app.AddComponent<App>("app");
        }
    }
}