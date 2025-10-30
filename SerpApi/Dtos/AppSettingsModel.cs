namespace SerpApi.Dtos;

public class AppSettingsModel
{
    public SerpApiSettings SerpApi { get; set; }
}

public class SerpApiSettings
{
    public string Key { get; set; }
}
