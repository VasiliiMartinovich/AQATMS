using System.Net;
using System.Text.Json;
using ReqResApiTests.Models.Responses;

namespace ReqResApiTests.Tests;

[TestFixture]
public class ResourcesGetApiTests : BaseTest
{
    [Test]
    public void GetResourceList_Get()
    {
        var response = ResourcesClient.GetResources();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Unexpected response: {response.Content}");

        var resourceResponse = JsonSerializer.Deserialize<ResourceListResponse>(response.Content!);

        Assert.That(resourceResponse, Is.Not.Null);
        Assert.That(resourceResponse!.Data, Is.Not.Null.And.Not.Empty);

        foreach (var resource in resourceResponse.Data!)
        {
            Assert.That(resource.Id, Is.GreaterThan(0));
            Assert.That(resource.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(resource.Year, Is.GreaterThan(0));
            Assert.That(resource.Color, Is.Not.Null.And.Not.Empty);
            Assert.That(resource.PantoneValue, Is.Not.Null.And.Not.Empty);
        }
    }
}