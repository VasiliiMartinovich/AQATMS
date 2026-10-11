using System.Net;
using System.Text.Json;
using ReqResApiTests.Models.Requests;
using ReqResApiTests.Models.Responses;

namespace ReqResApiTests.Tests;

[TestFixture]
public class RegisterTests : BaseTest
{
    [Test]
    public void RegisterPost()
    {
        var registerRequest = new RegisterRequest
        {
            Email = "eve.holt@reqres.in",
            Password = "pistol"
        };

        var response = RegisterClient.Register(registerRequest);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");
        var registerResponse = JsonSerializer.Deserialize<RegisterResponse>(response.Content!);

        Assert.That(registerResponse, Is.Not.Null);
        Assert.That(registerResponse!.Id, Is.GreaterThan(0));
        Assert.That(registerResponse.Token, Is.Not.Null.And.Not.Empty);
    }
    [Test]
    public void RegisterPost_EmptyData()
    {
        var registerRequest = new RegisterRequest
        {
            Email = "",
            Password = ""
        };

        var response = RegisterClient.Register(registerRequest);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
            $"Unexpected response: {response.Content}");
        var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(response.Content!);

        Assert.That(errorResponse, Is.Not.Null);
        Assert.That(errorResponse!.Error, Is.EqualTo("Missing email or username"));
    }
}