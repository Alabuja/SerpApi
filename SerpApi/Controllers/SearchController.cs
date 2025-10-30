using Microsoft.AspNetCore.Mvc;
using SerpApi.helper;

namespace SerpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISerpApiService _serpApiService;
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger, ISerpApiService serpApiService)
        {
            _logger = logger;
            _serpApiService = serpApiService;
        }

        /// <summary>
        /// Search for places using Google Maps via SerpApi
        /// </summary>
        /// <param name="query">Search query (e.g., "restaurants in abuja")</param>
        /// <param name="location">Optional location coordinates (e.g., "9.0765,7.3986")</param>
        /// <returns>Search results from Google Maps</returns>
        [HttpGet("google-maps")]
        public async Task<IActionResult> SearchGoogleMaps([FromQuery] string query, [FromQuery] string? location = null)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest(new { error = "Query parameter is required" });

            try
            {
                var result = await _serpApiService.SearchGoogleMapsAsync(query, location);

                if (result == null)
                    return NotFound(new { error = "No results found" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching Google Maps for query: {Query}", query);
                return StatusCode(500, new { error = "An error occurred while processing your request" });
            }
        }

        /// <summary>
        /// Search specifically for restaurants in a location
        /// </summary>
        /// <param name="location">Location name (e.g., "abuja", "lagos")</param>
        /// <returns>Restaurant search results</returns>
        [HttpGet("restaurants")]
        public async Task<IActionResult> SearchRestaurants([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest(new { error = "Location parameter is required" });

            try
            {
                var query = $"restaurants in {location}";
                var result = await _serpApiService.SearchGoogleMapsAsync(query);

                if (result == null || result.LocalResults == null || !result.LocalResults.Any())
                    return NotFound(new { error = $"No restaurants found in {location}" });

                return Ok(new
                {
                    location,
                    totalResults = result.LocalResults.Count,
                    restaurants = result.LocalResults
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching restaurants in: {Location}", location);
                return StatusCode(500, new { error = "An error occurred while processing your request" });
            }
        }
    }
}
