using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Generic;
using Xunit;

namespace ToptoutCli.Tests
{
    public class SwaggerApi_IsAccessible
    {
        [Fact]
        public IReadOnlyList<string> Call_To_AppApi()
        {
            var appsApi = new AppsApi();


            List<string> apps = null;

            try {
                apps = appsApi.GetApplicationId();
            }
            catch {
                Assert.True( false, "Exception during GetApplicationId" );
            }

            Assert.NotNull( apps );
            Assert.True( apps.Count > 0 );

            return apps;
        }

        [Fact]
        public void Call_To_TelemetryApi()
        {
            var teleApi = new TelemetryApi();

            var apps = Call_To_AppApi();

            Toptout t = null;
            try {
                t = teleApi.GetTelemetryById( apps[2] );
            }
            catch {
                Assert.True( false, "Exception during GetTelemetryById" );
            }

            Assert.NotNull( t );
        }
    }
}
