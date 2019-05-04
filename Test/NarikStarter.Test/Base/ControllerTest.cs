using Microsoft.AspNetCore.Mvc.Testing;
using NarikStarter.Web;
using Xunit;

namespace NarikStarter.Test.Base
{
    public class ControllerTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> Factory;

        public ControllerTest(WebApplicationFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
