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
    public class LocalTelemetryAdapter : ITelemetryApi
    {
        LocalDataProvider _provider;

        public LocalTelemetryAdapter(LocalDataProvider provider)
        {
            _provider = provider;
        }

        public async Task<IReadOnlyDictionary<string, Toptout>> ListTelemetryAsync()
        {
            return await Task.Run(() => {
                Dictionary<string, Toptout> telemetry = _provider.LoadLocalData();
                return telemetry.Count > 0 ? telemetry : null;
            });
        }
    }
}
