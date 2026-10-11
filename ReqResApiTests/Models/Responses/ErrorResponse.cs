using System.Text.Json.Serialization;

namespace ReqResApiTests.Models.Responses;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}