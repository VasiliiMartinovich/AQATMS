using RestSharp;


namespace ReqResApiTests.Clients;

public class UsersClient : ApiClient
{
    public UsersClient(RestClient client) : base(client)
    {
    }

    public RestResponse GetUsers()
    {
        var request = new RestRequest("/api/users", Method.Get);
        return Execute(request);
    }

    public RestResponse GetUserById(int userId)
    {
        var request = new RestRequest($"/api/users/{userId}", Method.Get);
        return Execute(request);
    }
    
    public RestResponse GetUsersContentType()
    {
        var request = new RestRequest("/api/users", Method.Get);
        return Execute(request);
    }

    public RestResponse DeleteUser(int userId)
    {
        var request = new RestRequest($"/api/users/{userId}", Method.Delete);
        return Execute(request);
    }
}