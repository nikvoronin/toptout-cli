using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToptoutCli.Adapters;
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

        [Fact]
        public async Task Call_To_SwaggerTelemetryApi()
        {
            Adapters.ITelemetryApi teleApi = new SwaggerTelemetryAdapter();

            IReadOnlyDictionary<string, Toptout> t = null;
            try {
                t = await teleApi.ListTelemetryAsync();
            }
            catch {
                Assert.True(false, "Exception during ListTelemetryAsync");
            }

            Assert.NotNull(t);
            Assert.True(t.Count > 0);
        }
    }
}
