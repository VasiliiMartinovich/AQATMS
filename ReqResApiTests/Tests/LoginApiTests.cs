using System.Net;
using System.Text.Json;
using ReqResApiTests.Models.Requests;
using ReqResApiTests.Models.Responses;

namespace ReqResApiTests.Tests;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public void LoginPost()
    {
        var loginRequest = new LoginRequest
        {
            Email = "eve.holt@reqres.in",
            Password = "cityslicka"
        };

        var response = LoginClient.Login(loginRequest);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");

        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(response.Content!);

        Assert.That(loginResponse, Is.Not.Null);
        Assert.That(loginResponse!.Token, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void LoginPost_WithoutPassword()
    {
        var email = "test@qa.com";
        var response = LoginClient.LoginWithoutPassword(email);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
            $"Unexpected response: {response.Content}");

        var errorResponse = JsonSerializer.Deserialize<ReqResApiTests.Models.Responses.ErrorResponse>(response.Content!);
        Assert.That(errorResponse, Is.Not.Null);
        }
    
    [Test]
    public void LoginPost_WithInvalidPassword()
    {
        var loginRequest = new LoginRequest
        {
            Email = "eve.hlt@reqres.in",
            Password = "43242352"
        };

        var response =  LoginClient.Login(loginRequest);
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
            $"Unexpected response: {response.Content}");

        var errorResponse = JsonSerializer.Deserialize<ReqResApiTests.Models.Responses.ErrorResponse>(response.Content!);

        Assert.That(errorResponse, Is.Not.Null);
        Assert.That(errorResponse!.Error, Is.EqualTo("user not found"));
    }
}