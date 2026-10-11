using System.Net;
using System.Text.Json;
using ReqResApiTests.Models;
using ReqResApiTests.Models.Responses;
using System.Linq;

namespace ReqResApiTests.Tests;

[TestFixture]
public class UsersGetByIdApiTests : BaseTest
{
    [Test]
    public void GetUserById_Get()
    {
        int userId = 3;
        var response = UsersClient.GetUserById(userId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");

        var userResponse = JsonSerializer.Deserialize<UserDetailsResponse>(response.Content!);

        Assert.That(userResponse, Is.Not.Null);
        Assert.That(userResponse!.Data, Is.Not.Null);
        Assert.That(userResponse.Data!.Id, Is.EqualTo(userId));
        Assert.That(userResponse.Data.Email, Is.Not.Null.And.Not.Empty);
        Assert.That(userResponse.Data.FirstName, Is.Not.Null.And.Not.Empty);
        Assert.That(userResponse.Data.LastName, Is.Not.Null.And.Not.Empty);
        Assert.That(userResponse.Data.Avatar, Is.Not.Null.And.Not.Empty);
    }
    
    [Test]
    public void GetUsersList_Get()
    {
        var response = UsersClient.GetUsers();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");

        var result = JsonSerializer.Deserialize<UsersListResponse>(response.Content!);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Page, Is.GreaterThanOrEqualTo(0));
        Assert.That(result.PerPage, Is.GreaterThan(0));
        Assert.That(result.Total, Is.GreaterThanOrEqualTo(0));
        Assert.That(result.TotalPages, Is.GreaterThanOrEqualTo(0));
        Assert.That(result.Data, Is.Not.Null.And.Not.Empty);

        foreach (var user in result.Data!)
        {
            Assert.That(user.Id, Is.GreaterThan(0));
            Assert.That(user.Email, Is.Not.Null.And.Not.Empty);
            Assert.That(user.FirstName, Is.Not.Null.And.Not.Empty);
            Assert.That(user.LastName, Is.Not.Null.And.Not.Empty);
            Assert.That(user.Avatar, Is.Not.Null.And.Not.Empty);
        }
    }
    
    [Test]
    public void GetUserContentType_Get()
    {
        var response = UsersClient.GetUsersContentType();

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");

        if (response.Headers != null)
        {
            foreach (var header in response.Headers)
            {
                TestContext.WriteLine($"{header.Name}: {header.Value}");
            }
        }

        Assert.That(response.ContentType, Is.Not.Null.And.Not.Empty);
        Assert.That(response.ContentType,
            Does.StartWith("application/json").IgnoreCase);

        var dateHeader = response.Headers?
            .FirstOrDefault(h =>
                string.Equals(h.Name, "Date",
                    StringComparison.OrdinalIgnoreCase));

        Assert.That(dateHeader, Is.Not.Null,
            "Response does not contain the Date header");
    }
}