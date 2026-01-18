using ContosoUniversity.Tests.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ContosoUniversity.Tests.Controllers
{
    public class TestApplicationFactory: WebApplicationFactory<Program>
    {
        private readonly string _environment = "Development";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(_environment);
            builder.ConfigureServices(services => {
                services.AddAuthentication(defaultScheme: "TestScheme")
                .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("TestScheme", options => { });
            });
            base.ConfigureWebHost(builder);
        }
    }
}
