using System.Net;
using System.Text.Json;
using ReqResApiTests.Models.Requests;
using ReqResApiTests.Models.Responses;

namespace ReqResApiTests.Tests;

    [TestFixture]
    public class UsersUpdateApiTests : BaseTest
    {
        [Test]
        public void UserUpdatePut()
        {
            var userUpdateRequest = new UserUpdateRequest
            {
                Name = "morpheus",
                Job = "zion resident"
            };

            var response = UpdateClient.UpdateUser(2, userUpdateRequest);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Unexpected response: {response.Content}");
            
            var updateUserResponse = JsonSerializer.Deserialize<UserUpdateResponse>(response.Content!);
            
            Assert.That(updateUserResponse, Is.Not.Null);
            Assert.That(updateUserResponse!.Name, Is.EqualTo("morpheus"));
            Assert.That(updateUserResponse.Job, Is.EqualTo("zion resident"));
            Assert.That(updateUserResponse.UpdatedAt, Is.Not.EqualTo(default(DateTime)));
        }
}