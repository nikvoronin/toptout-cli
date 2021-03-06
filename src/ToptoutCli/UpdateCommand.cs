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
        public const string Default_ToptoutDataUserRepo = "beatcracker/toptout";
        public const string Default_ToptoutRepoPath = "/data";

        public enum Provider { Swagger, Github }

        private UpdateCommand() { }

        public static Command Create(Action<Provider, string, string> handler)
        {
            var cmd = new Command("update", "Download and update local database.");
            cmd.AddAlias("force");

            cmd.Handler = CommandHandler.Create(handler);

            var providerOption = new Option<Provider> (
                alias: "--provider",
                description: "Data retrieving method",
                getDefaultValue: () => Provider.Swagger
                );

            var userRepoOption = new Option<string> (
                alias: "--user-repo",
                description: "Changes github 'user/repo' pair",
                getDefaultValue: () => Default_ToptoutDataUserRepo
                );

            userRepoOption.AllowMultipleArgumentsPerToken = false;
            userRepoOption.AddValidator(r => Validate(r.Tokens));

            var pathOption = new Option<string> (
                alias: "--path",
                description: "Path to telemetry data inside a github repository",
                getDefaultValue: () => Default_ToptoutRepoPath
                );

            cmd.AddOption(providerOption);
            cmd.AddOption(userRepoOption);
            cmd.AddOption(pathOption);

            return cmd;
        }

        public static string Validate(IReadOnlyList<Token> tokens)
        {
            if (tokens.Count != 1)
                return "ERROR: Too much arguments";

            if (tokens[0].Type != TokenType.Argument)
                return "ERROR: Not an argument";

            if (tokens[0].Value.Split("/").Length != 2)
                return "ERROR: Wrong argument format. Expected 'username/repo'";

            return null;
        }
    }
}
