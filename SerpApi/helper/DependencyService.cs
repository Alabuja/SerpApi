using Microsoft.Extensions.Options;
using SerpApi.Dtos;
using System.Net.Http.Headers;
using System.Net;

namespace SerpApi.helper;

public static class DependencyService
{
    public static void AddBusinessDependencies(this IServiceCollection services, AppSettingsModel appSettings)
    {
        services.AddSingleton<AppSettingsModel>(sp => sp.GetRequiredService<IOptions<AppSettingsModel>>().Value);

        services.AddScoped<ISerpApiService, SerpApiService>();

        services.AddHttpClient("SerpApi", (client) =>
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            client.BaseAddress = new Uri("https://serpapi.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
    }
}
