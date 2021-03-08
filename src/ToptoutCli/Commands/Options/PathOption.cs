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
    public class PathOption
    {
        public const string Default_ToptoutRepoPath = "/data";

        public static Option<string> Create()
        {
            var o = new Option<string> (
                alias: "--path",
                description: "Path to telemetry data inside a Github repository",
                getDefaultValue: () => Default_ToptoutRepoPath
                );

            return o;
        }
    }
}
