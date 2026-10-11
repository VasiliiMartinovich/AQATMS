using ReqResApiTests.Models.Requests;
using RestSharp;
using ReqResApiTests.Models.Responses;

namespace ReqResApiTests.Clients;

public class RegisterClient : ApiClient
{
    public RegisterClient(RestClient client) : base(client)
    {
    }
    
    public RestResponse Register(RegisterRequest registerRequest)
    {
        var request = new RestRequest("/api/register", Method.Post);
        request.AddJsonBody(registerRequest);
        return Execute(request);
    }
}