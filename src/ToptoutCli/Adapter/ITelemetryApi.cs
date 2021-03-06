using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Adapters
{
    public interface ITelemetryApi
    {
        Task<IReadOnlyDictionary<string, Toptout>> ListTelemetryAsync();
    }
}
