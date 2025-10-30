using Microsoft.Extensions.Options;
using SerpApi.Dtos;

namespace SerpApi.helper;

public static class DependencyService
{
    public static void AddBusinessDependencies(this IServiceCollection services, AppSettingsModel appSettings)
    {
        services.AddSingleton<AppSettingsModel>(sp => sp.GetRequiredService<IOptions<AppSettingsModel>>().Value);

        services.AddScoped<ISerpApiService, SerpApiService>();

        services.AddHttpClient();
    }
}
