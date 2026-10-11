using ReqResApiTests.Models.Requests;
using RestSharp;

namespace ReqResApiTests.Clients;

public class LoginApiClient : ApiClient
{
    public LoginApiClient(RestClient client) : base(client)
    {
    }
    public RestResponse Login(LoginRequest loginRequest)
    {
        var request = new RestRequest("/api/login", Method.Post);
        request.AddJsonBody(loginRequest);

        return Execute(request);
    }

    public RestResponse LoginWithoutPassword(string email)
    {
        var request = new RestRequest("/api/login", Method.Post);
        request.AddJsonBody(new { email });

        return Execute(request);
    }
}