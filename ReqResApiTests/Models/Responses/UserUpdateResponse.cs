using System.Text.Json.Serialization;

namespace ReqResApiTests.Models.Responses;

public class UserUpdateResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } 

    [JsonPropertyName("job")]
    public string Job { get; set; } 
    
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}