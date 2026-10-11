using RestSharp;

namespace ReqResApiTests.Clients;

public class ResourcesClient : ApiClient
{
    public ResourcesClient(RestClient client) : base(client)
    {
    }

    public RestResponse GetResources()
    {
        var request = new RestRequest("/api/unknown", Method.Get);
        return Execute(request);
    }
}