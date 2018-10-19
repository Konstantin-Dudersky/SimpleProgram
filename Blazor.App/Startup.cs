using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.App.Services;

namespace Blazor.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
            services.AddSingleton<WeatherForecastService>();
            Data data = new Data();
            services.AddSingleton<Data>(data);
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
//            Data.StartUp();
            
            

            app.AddComponent<App>("app");
        }
    }
}