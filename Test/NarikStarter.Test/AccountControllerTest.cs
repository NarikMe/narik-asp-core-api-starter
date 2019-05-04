using System.Net.Http;
using System.Net.Http.Formatting;
using NarikStarter.Test.Base;
using NarikStarter.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Narik.Common.Shared.Models;
using Xunit;

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

            var response = await client.PostAsync(url,
                new LoginModel
            {
                UserName = "admin",
                Password = "123"
            }, new JsonMediaTypeFormatter());

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var result = await response.Content.ReadAsAsync<LoginResultModel>();
            System.Diagnostics.Debug.WriteLine(response.StatusCode);

        }

        [Fact]
        public async void UpdateUserRole()
        {
            var url = "api/UserAction/UpdateRoles";
            var client = Factory.CreateClient();

            var response = await client.PostAsync(url,
                new ValueHolder<int,int[]>()
                {
                    Value = 2,
                    Value1 =new []{2}
                }, new JsonMediaTypeFormatter());

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var result = await response.Content.ReadAsAsync<LoginResultModel>();
            System.Diagnostics.Debug.WriteLine(response.StatusCode);

        }
    }
}
