﻿using System.Text.Json.Serialization;

namespace SerpApi.Dtos;

public class GoogleMapsSearchResult
{
    [JsonPropertyName("search_metadata")]
    public SearchMetadata? SearchMetadata { get; set; }

    [JsonPropertyName("search_parameters")]
    public SearchParameters? SearchParameters { get; set; }

    [JsonPropertyName("search_information")]
    public SearchInformation? SearchInformation { get; set; }

    [JsonPropertyName("local_results")]
    public List<LocalResult>? LocalResults { get; set; }
}

public class SearchMetadata
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("json_endpoint")]
    public string? JsonEndpoint { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("processed_at")]
    public string? ProcessedAt { get; set; }

    [JsonPropertyName("google_maps_url")]
    public string? GoogleMapsUrl { get; set; }

    [JsonPropertyName("raw_html_file")]
    public string? RawHtmlFile { get; set; }

    [JsonPropertyName("total_time_taken")]
    public double? TotalTimeTaken { get; set; }
}

public class SearchParameters
{
    [JsonPropertyName("engine")]
    public string? Engine { get; set; }

    [JsonPropertyName("q")]
    public string? Q { get; set; }

    [JsonPropertyName("ll")]
    public string? Ll { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("google_domain")]
    public string? GoogleDomain { get; set; }

    [JsonPropertyName("hl")]
    public string? Hl { get; set; }
}

public class SearchInformation
{
    [JsonPropertyName("local_results_state")]
    public string? LocalResultsState { get; set; }

    [JsonPropertyName("query_displayed")]
    public string? QueryDisplayed { get; set; }
}

public class LocalResult
{
    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("place_id")]
    public string? PlaceId { get; set; }

    [JsonPropertyName("data_id")]
    public string? DataId { get; set; }

    [JsonPropertyName("data_cid")]
    public string? DataCid { get; set; }

    [JsonPropertyName("reviews_link")]
    public string? ReviewsLink { get; set; }

    [JsonPropertyName("photos_link")]
    public string? PhotosLink { get; set; }

    [JsonPropertyName("gps_coordinates")]
    public GpsCoordinates? GpsCoordinates { get; set; }

    [JsonPropertyName("place_id_search")]
    public string? PlaceIdSearch { get; set; }

    [JsonPropertyName("provider_id")]
    public string? ProviderId { get; set; }

    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("reviews")]
    public int? Reviews { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("types")]
    public List<string>? Types { get; set; }

    [JsonPropertyName("type_id")]
    public string? TypeId { get; set; }

    [JsonPropertyName("type_ids")]
    public List<string>? TypeIds { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("open_state")]
    public string? OpenState { get; set; }

    [JsonPropertyName("hours")]
    public string? Hours { get; set; }

    [JsonPropertyName("operating_hours")]
    public OperatingHours? OperatingHours { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("service_options")]
    public ServiceOptions? ServiceOptions { get; set; }

    [JsonPropertyName("user_review")]
    public string? UserReview { get; set; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonPropertyName("serpapi_thumbnail")]
    public string? SerpapiThumbnail { get; set; }
}

public class OperatingHours
{
    [JsonPropertyName("monday")]
    public string? Monday { get; set; }

    [JsonPropertyName("tuesday")]
    public string? Tuesday { get; set; }

    [JsonPropertyName("wednesday")]
    public string? Wednesday { get; set; }

    [JsonPropertyName("thursday")]
    public string? Thursday { get; set; }

    [JsonPropertyName("friday")]
    public string? Friday { get; set; }

    [JsonPropertyName("saturday")]
    public string? Saturday { get; set; }

    [JsonPropertyName("sunday")]
    public string? Sunday { get; set; }
}

public class ServiceOptions
{
    [JsonPropertyName("dine_in")]
    public bool? DineIn { get; set; }

    [JsonPropertyName("takeout")]
    public bool? Takeout { get; set; }

    [JsonPropertyName("delivery")]
    public bool? Delivery { get; set; }

    [JsonPropertyName("drive_through")]
    public bool? DriveThrough { get; set; }

    [JsonPropertyName("no_contact_delivery")]
    public bool? NoContactDelivery { get; set; }

    [JsonPropertyName("curbside_pickup")]
    public bool? CurbsidePickup { get; set; }
}

public class GpsCoordinates
{
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
}