using RestSharp;

namespace ReqResApiTests.Clients;

public class ApiClient
{
    protected RestClient Client { get; }

    public ApiClient(RestClient client)
    {
        Client = client;
    }

    protected RestResponse Execute(RestRequest request)
    {
        return Client.Execute(request);
    }
}