using ReqResApiTests.Models.Requests;
using RestSharp;

namespace ReqResApiTests.Clients;

public class UpdateClient : ApiClient
{
    public UpdateClient(RestClient client) : base(client)
    {
    }

    public RestResponse UpdateUser(int userId, UserUpdateRequest userUpdateRequest)
    {
        var request = new RestRequest($"/api/users/{userId}", Method.Put);
        request.AddJsonBody(userUpdateRequest);

        return Execute(request);
    }
}