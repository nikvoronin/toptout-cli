using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToptoutCli.Adapters;
using Xunit;

namespace ToptoutCli.Tests
{
    public class GithubApi_IsAccessible
    {
        [Fact]
        public async Task Call_To_GithubTelemetryApi()
        {
            Adapters.ITelemetryApi teleApi = new GithubTelemetryApi();

            IReadOnlyDictionary<string, Toptout> t = null;
            try {
                t = await teleApi.ListTelemetryAsync();
            }
            catch {
                Assert.True(false, "Exception during GithubTelemetryApi");
            }

            Assert.NotNull(t);
            Assert.True(t.Count > 0);
        }
    }
}
