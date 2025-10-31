using SerpApi.Dtos;
using System.Text.Json;

namespace SerpApi.helper;

public interface ISerpApiService
{
    Task<GoogleMapsSearchResult?> SearchGoogleMapsAsync(string query, string? location = null);
}

public class SerpApiService : ISerpApiService
{
    private readonly HttpClient _client;
    IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;
    private readonly AppSettingsModel appSettingsModel;
    private readonly ILogger<SerpApiService> _logger;
    public SerpApiService(AppSettingsModel appSettingsModel, IHttpClientFactory httpClientFactory, ILogger<SerpApiService> logger)
    {
        this.appSettingsModel = appSettingsModel;

        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _apiKey = appSettingsModel.SerpApi.Key;
    }

    public async Task<GoogleMapsSearchResult?> SearchGoogleMapsAsync(string query, string? location = null)
    {
        using var _client = _httpClientFactory.CreateClient("SerpApi");

        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException("Query cannot be empty", nameof(query));

        if(string.IsNullOrWhiteSpace(_apiKey))
            throw new InvalidOperationException("SerpApi API key is not configured.");

        // Build query parameters
        var queryParams = $"search.json?engine=google_maps&q={Uri.EscapeDataString(query)}&api_key={_apiKey}";

        if (!string.IsNullOrWhiteSpace(location))
            queryParams += $"&ll={Uri.EscapeDataString(location)}";

        try
        {
            var response = await _client.GetAsync(queryParams);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<GoogleMapsSearchResult>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;

        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP request error while calling SerpApi: {Message}", ex.Message);
            // Log the exception here
            throw new Exception($"Error calling SerpApi: {ex.Message}", ex);
        }
    }
}
