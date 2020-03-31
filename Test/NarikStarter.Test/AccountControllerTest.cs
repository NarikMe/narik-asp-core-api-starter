using System.Net.Http;
using NarikStarter.Test.Base;
using NarikStarter.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Narik.Common.Shared.Models;
using Xunit;
using System.Text;
using System.Text.Json;

namespace NarikStarter.Test
{
    public class AccountControllerTest: ControllerTest
    {
        public AccountControllerTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async void Authenticate()
        {
            var url = "api/account/Authenticate";
            var client = Factory.CreateClient();

            var obj = new LoginModel
            {
                UserName = "admin",
                Password = "123"
            };
            var stringPayload = System.Text.Json.JsonSerializer.Serialize(obj);
            var response = await client.PostAsync(url, new StringContent(stringPayload, Encoding.UTF8, "application/json"));


            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var result = await response.Content.ReadAsStringAsync();
            var resultObject = System.Text.Json.JsonSerializer.Deserialize<LoginResultModel>(result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            System.Diagnostics.Debug.WriteLine(response.StatusCode);

        }

        [Fact]
        public async void UpdateUserRole()
        {
            var url = "api/UserAction/UpdateRoles";
            var client = Factory.CreateClient();

            var stringPayload = System.Text.Json.JsonSerializer.Serialize(new ValueHolder<int, int[]>()
            {
                Value = 2,
                Value1 = new[] { 2 }
            });
            var response = await client.PostAsync(url, new StringContent(stringPayload, Encoding.UTF8, "application/json"));


            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var result = await response.Content.ReadAsStringAsync();
            var resultObject = System.Text.Json.JsonSerializer.Deserialize<LoginResultModel>(result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            System.Diagnostics.Debug.WriteLine(response.StatusCode);

        }
    }
}
