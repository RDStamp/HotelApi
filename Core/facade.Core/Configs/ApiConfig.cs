namespace facade.Core.Configs;

public class ApiConfig
{
    public const string SectionName = "ApiConfig";
    public string BaseUrl { get; set; } = string.Empty;
    public string DataUrl { get; set; } = string.Empty;
}
