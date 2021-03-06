using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToptoutCli.Model.Github;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using ToptoutCli.Provider;

namespace ToptoutCli.Adapters
{
    public class GithubTelemetryAdapter : ITelemetryApi
    {
        GithubDataProvider _provider;

        public GithubTelemetryAdapter(GithubDataProvider provider)
        {
            _provider = provider;
        }

        public async Task<IReadOnlyDictionary<string, Toptout>> ListTelemetryAsync()
        {
            Dictionary<string, Toptout> telemetry = new Dictionary<string, Toptout>();

            string url = await _provider.FindDataFolderUrlAsync();
            var files = await _provider.ListJsonFilesAsync(url);

            foreach(var appId in files) {
                try {
                    string jsonString = await _provider.GetJsonFileAsString( appId );
                    var t = JsonConvert.DeserializeObject<Toptout>(jsonString);

                    telemetry.Add(t.Id, t);
                }
                catch { }
            }

            return telemetry.Count > 0 ? telemetry : null;
        }
    }
}
