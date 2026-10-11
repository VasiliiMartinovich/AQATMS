using System.Text.Json.Serialization;

namespace ReqResApiTests.Models;

public class UsersListResponse
{
    public int Page { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    public int Total { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("data")]
    public List<UserDto>? Data { get; set; }
}