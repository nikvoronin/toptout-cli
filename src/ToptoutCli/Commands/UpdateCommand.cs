using Newtonsoft.Json;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using ToptoutCli.Adapters;
using ToptoutCli.Commands.Options;
using ToptoutCli.Provider;
using static ToptoutCli.Commands.Options.ProviderOption;

namespace ToptoutCli.Commands
{
    public class UpdateCommand
    {
        private UpdateCommand() {}

        public static Command Create(Action<DataSource, string, string, string> executor = null)
        {
            var cmd = new Command("update", "Download and update local database.");
            cmd.AddAlias("force");

            cmd.Handler = CommandHandler.Create( executor != null 
                ? executor 
                : new Action<DataSource, string, string, string>(Execute));

            cmd.AddOption( ProviderOption.Create() );
            cmd.AddOption( RepoOption.Create() );
            cmd.AddOption( PathOption.Create() );

            return cmd;
        }

        static void Execute(DataSource provider, string repo, string path, string options)
        {
            ITelemetryApi api;

            switch (provider) {
                case DataSource.Swagger:
                    api = new SwaggerTelemetryAdapter();
                    break;

                case DataSource.Github:
                    api = new GithubTelemetryAdapter(new GithubDataProvider(repo, path));
                    break;

                default:
                case DataSource.Local:
                    api = new LocalTelemetryAdapter(new LocalDataProvider(Const.Default_LocalDataFilename));
                    break;
            }

            var apps = api.ListTelemetryAsync().GetAwaiter().GetResult();

            if (apps == null) {
                Console.WriteLine("ERROR: Can not update data."); // TODO swagger-api not avilable error message
                return;
            }

            File.WriteAllText(Const.Default_LocalDataFilename, JsonConvert.SerializeObject(apps));

            var userOpts = new UserOptions(options);
            if (File.Exists(options))
                userOpts.LoadFromFile();

            foreach(var appId in apps.Keys) {
                if (!userOpts.Rules.ContainsKey(appId))
                    userOpts.AddDefaultRule(appId);
            }

            userOpts.SaveRules();
        }
    }
}
