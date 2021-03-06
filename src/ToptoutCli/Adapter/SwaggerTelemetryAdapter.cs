using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Adapters
{
    public class SwaggerTelemetryAdapter : ITelemetryApi
    {
        public async Task<IReadOnlyDictionary<string, Toptout>> ListTelemetryAsync()
        {
            Dictionary<string, Toptout> telemetry = null;
            var teleApi = new TelemetryApi();

            try {
                List<Toptout> ts = await teleApi.GetTelemetryAsync();
                telemetry = new Dictionary<string, Toptout>();

                foreach (var t in ts)
                    telemetry.Add(t.Id, t);
            }
            catch {
                return null;
            }

            return telemetry;
        }
    }
}
