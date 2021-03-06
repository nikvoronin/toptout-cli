using Newtonsoft.Json;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using ToptoutCli.Adapters;
using ToptoutCli.Provider;

namespace ToptoutCli
{
    class Program
    {
        const string Default_LocalDataFilename = "./toptout.json";

        static int Main( string[] args )
        {
            Console.WriteLine( "Toptout-cli 0.1.306-alpha" );

            var root = new RootCommand( description: "Easily opt-out from telemetry collection." );

            root.AddCommand( UpdateCommand.Create(
                (provider, userRepo, path) => {
                    ITelemetryApi api;
                    switch (provider) {
                        case UpdateCommand.Provider.Swagger:
                            api = new SwaggerTelemetryAdapter();
                            break;
                        case UpdateCommand.Provider.Github:
                            api = new GithubTelemetryAdapter( new GithubDataProvider(userRepo, path) );
                            break;
                        default:
                        case UpdateCommand.Provider.Local:
                            throw new NotImplementedException();
                    }

                    var apps = api.ListTelemetryAsync().GetAwaiter().GetResult();
                    File.WriteAllText( Default_LocalDataFilename, JsonConvert.SerializeObject(apps));
                }));

            root.Handler = CommandHandler.Create( ( ) => {
                // TODO do MAIN toptout things
                Console.WriteLine( "[ROOT] handler" );
            } );

            int errlevel = root.Invoke( args );

            Console.WriteLine( "Press [Enter] to close..." );
            Console.ReadLine();

            return errlevel;
        }
    }
}
