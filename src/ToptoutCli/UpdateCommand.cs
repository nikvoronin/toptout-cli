using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.IO;
using ToptoutCli.Adapters;
using ToptoutCli.Provider;

namespace ToptoutCli
{
    public class UpdateCommand
    {
        public const string Default_ToptoutDataUserRepo = "beatcracker/toptout/master";
        public const string Default_ToptoutRepoPath = "/data";

        public enum Provider { Swagger, Github, Local }

        private UpdateCommand() { }

        public static Command Create(Action<Provider, string, string> executor = null)
        {
            var cmd = new Command("update", "Download and update local database.");
            cmd.AddAlias("force");

            cmd.Handler = CommandHandler.Create( executor != null 
                ? executor 
                : new Action<Provider, string, string>(Execute));

            var providerOption = new Option<Provider> (
                alias: "--provider",
                description: "Data retrieving method",
                getDefaultValue: () => Provider.Swagger
                );

            var userRepoOption = new Option<string> (
                aliases: new[]{ "--user-repo-branch", "--repo" },
                description: "Changes 'user/repo/branch' of the Github repository with a data",
                getDefaultValue: () => Default_ToptoutDataUserRepo
                );

            userRepoOption.AllowMultipleArgumentsPerToken = false;
            userRepoOption.AddValidator(r => Validate(r.Tokens));

            var pathOption = new Option<string> (
                alias: "--path",
                description: "Path to telemetry data inside a Github repository",
                getDefaultValue: () => Default_ToptoutRepoPath
                );

            cmd.AddOption(providerOption);
            cmd.AddOption(userRepoOption);
            cmd.AddOption(pathOption);

            return cmd;
        }

        static void Execute(Provider provider, string repo, string path)
        {
            ITelemetryApi api;
            switch (provider) {
                case Provider.Swagger:
                    api = new SwaggerTelemetryAdapter();
                    break;

                case Provider.Github:
                    api = new GithubTelemetryAdapter(new GithubDataProvider(repo, path));
                    break;

                default:
                case Provider.Local:
                    api = new LocalTelemetryAdapter(new LocalDataProvider(Const.Default_LocalDataFilename));
                    break;
            }

            var apps = api.ListTelemetryAsync().GetAwaiter().GetResult();
            File.WriteAllText(Const.Default_LocalDataFilename, JsonConvert.SerializeObject(apps));
        }

        public static string Validate(IReadOnlyList<Token> tokens)
        {
            if (tokens.Count == 0)
                return null;

            if (tokens.Count > 1)
                return "ERROR: Too much arguments.";

            if (tokens[0].Type != TokenType.Argument)
                return "ERROR: Not an argument.";

            if (tokens[0].Value.Split("/").Length != 3)
                return "ERROR: Wrong arguments format. Expected 'username/repo/branch'.";

            return null;
        }
    }
}
