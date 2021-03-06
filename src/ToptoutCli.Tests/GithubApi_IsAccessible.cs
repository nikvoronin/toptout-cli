using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToptoutCli.Adapters;
using ToptoutCli.Provider;
using Xunit;

namespace ToptoutCli.Tests
{
    public class GithubApi_IsAccessible
    {
        [Fact]
        public async Task Call_To_GithubTelemetryApi()
        {
            var provider = new GithubDataProvider(
                UpdateCommand.Default_ToptoutDataUserRepo,
                UpdateCommand.Default_ToptoutRepoPath);

            Adapters.ITelemetryApi teleApi = new GithubTelemetryAdapter(provider);

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
