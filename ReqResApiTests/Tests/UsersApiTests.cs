using System.Net;

namespace ReqResApiTests.Tests;

[TestFixture]
public class UsersTests : BaseTest
{
    [Test]
    public void GetUsers_ShouldReturnSuccess()
    {
        var response = UsersClient.GetUsers();

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");
    }
}