using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli
{
    public class UpdateCommand
    {
        public const string Default_ToptoutDataRepo = @"https://api.github.com/repos/beatcracker/toptout/git/trees/master";
        public const string Default_ToptoutRepoPath = "/data";

        public enum Provider { Swagger, Github }

        private UpdateCommand() { }

        public static Command Create(Action<string> handler)
        {
            var cmd = new Command("update", "Download and update local database.");
            cmd.AddAlias("force");

            cmd.Handler = CommandHandler.Create(handler);

            var providerOption = new Option<Provider> (
                alias: "--provider",
                description: "Data retrieving method",
                getDefaultValue: () => Provider.Swagger
                );

            var repoOption = new Option<string> (
                alias: "--repo",
                description: "Change github repository",
                getDefaultValue: () => Default_ToptoutDataRepo
                );

            var pathOption = new Option<string> (
                alias: "--path",
                description: "Path to telemetry data inside a github repository",
                getDefaultValue: () => Default_ToptoutRepoPath
                );

            cmd.AddOption(providerOption);
            cmd.AddOption(repoOption);
            cmd.AddOption(pathOption);

            return cmd;
        }
    }
}
