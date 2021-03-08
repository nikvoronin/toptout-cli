using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Commands.Options
{
    public class ProviderOption
    {
        public enum DataSource { Swagger, Github, Local }

        public static Option<DataSource> Create()
        {
            var o = new Option<DataSource> (
                alias: "--provider",
                description: "Data retrieving method",
                getDefaultValue: () => DataSource.Swagger
                );

            return o;
        }
    }
}
