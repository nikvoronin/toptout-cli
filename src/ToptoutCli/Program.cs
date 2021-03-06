using IO.Swagger.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                            api = new LocalTelemetryAdapter( new LocalDataProvider(Default_LocalDataFilename) );
                            break;
                    }

                    var apps = api.ListTelemetryAsync().GetAwaiter().GetResult();
                    File.WriteAllText( Default_LocalDataFilename, JsonConvert.SerializeObject(apps));
                }));

            root.Handler = CommandHandler.Create( ( ) => {
                Dictionary<string, Toptout> tm = null;

                if (!File.Exists(Default_LocalDataFilename)) {
                    Console.WriteLine("[!] Warning. Can not find local database. Use the `force`, Luke.");
                    return; // TODO define errorlevels
                }
                else {
                    try {
                        tm = new LocalDataProvider(Default_LocalDataFilename).LoadLocalData();
                    }
                    catch {
                        Console.WriteLine("[!] Error. Can not load local database. Should try to `update`.");
                        return; // TODO define errorlevels
                    }
                }

                Console.WriteLine($"Loaded {tm.Count} apps."); // STUB
            });

            int errlevel = root.Invoke( args );

            Console.WriteLine( "Press [Enter] to close..." );
            Console.ReadLine();

            return errlevel;
        }
    }
}
