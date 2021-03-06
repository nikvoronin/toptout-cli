using IO.Swagger.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Provider
{
    public class LocalDataProvider
    {
        string _localDataFilename;

        public LocalDataProvider(string localDataFilename)
        {
            _localDataFilename = localDataFilename;
        }

        public Dictionary<string, Toptout> LoadLocalData()
        {
            var serializer = new JsonSerializer();

            using (var fs = File.OpenRead(_localDataFilename))
            using (var sr = new StreamReader(fs))
            using (var jsonTextReader = new JsonTextReader(sr))

            return serializer.Deserialize<Dictionary<string, Toptout>>(jsonTextReader);
        }
    }
}
