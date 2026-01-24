using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("features")]
    public List<Feature>? Features { get; set; }

}
public class Feature
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("properties")]
    public FeatureProperties? Properties { get; set; }
}

public class FeatureProperties
{
    [JsonPropertyName("mag")]
    public double? Mag { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }
}