using System.Text.Json.Serialization;

namespace ReqResApiTests.Models.Responses;

public class LoginResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; set; } 
}