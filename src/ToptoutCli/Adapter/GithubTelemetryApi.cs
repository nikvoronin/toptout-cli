using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Adapters
{
    public class GithubTelemetryApi : ITelemetryApi
    {
        readonly string _repo;
        readonly string _path;

        public GithubTelemetryApi(string repo, string path)
        {
            _repo = repo;
            _path = path;
        }

        public async Task<IReadOnlyDictionary<string, Toptout>> ListTelemetryAsync()
        {
            Dictionary<string, Toptout> telemetry = null;

            return telemetry;
        }
    }
}
