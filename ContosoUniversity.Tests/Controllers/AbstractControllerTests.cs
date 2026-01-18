using System.Net.Http.Headers;

namespace ContosoUniversity.Tests.Controllers
{
    public class AbstractControllerTests: IClassFixture<TestApplicationFactory>
    {
        protected HttpClient Client { get; }

        protected AbstractControllerTests(TestApplicationFactory factory)
        { 
            Client = factory.CreateClient();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "TestScheme");
        }
    }
}
