using RestSharp;
using ReqResApiTests.Clients;

namespace ReqResApiTests.Tests;

public abstract class BaseTest
{
    private RestClient _restClient = null!;
    protected UsersClient UsersClient { get; private set; } = null!;
    protected LoginApiClient LoginClient { get; private set; } = null!;
    protected RegisterClient RegisterClient { get; private set; } = null!;
    protected UpdateClient UpdateClient { get; private set; } = null!;
    protected ResourcesClient ResourcesClient { get; private set; } = null!;
    

    [SetUp]
    public void SetUp()
    {
        _restClient = new RestClient("https://reqres.in");
        _restClient.AddDefaultHeader("Accept", "application/json");

        UsersClient = new UsersClient(_restClient);
        RegisterClient = new RegisterClient(_restClient);
        LoginClient = new LoginApiClient(_restClient);
        UpdateClient = new UpdateClient(_restClient);
        ResourcesClient = new ResourcesClient(_restClient);
    }

    [TearDown]
    public void TearDown()
    {
        _restClient.Dispose();
    }
}