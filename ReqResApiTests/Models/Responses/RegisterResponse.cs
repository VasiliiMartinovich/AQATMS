using System.Text.Json.Serialization;

namespace ReqResApiTests.Models.Responses;

public class RegisterResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; } 
    [JsonPropertyName("token")]
    public string? Token { get; set; } 
}