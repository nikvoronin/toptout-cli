using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using ToptoutCli.Provider;

namespace ToptoutCli
{
    class Program
    {
        static int Main( string[] args )
        {
            Console.WriteLine( "Toptout-cli 0.1.307-alpha" );

            var root = new RootCommand( description: "Easily opt-out from telemetry collection." );

            var optionsFileOption = new Option<string> (
                alias: "--options",
                description: "Set filename of the user defined options",
                getDefaultValue: () => Const.Default_UserOptionsFilename
                );
            root.AddGlobalOption(optionsFileOption);

            root.AddCommand( UpdateCommand.Create() );
            root.Handler = CommandHandler.Create( new Func<string, int>(Execute) );

            int errlevel = root.Invoke( args );

#if DEBUG   // TODO DEBUG only
            Console.WriteLine("Press [Enter] to close...");
            Console.ReadLine();
#endif
            return errlevel;
        }

        static int Execute(string options)
        {
            Dictionary<string, Toptout> tm = null;

            if (!File.Exists(Const.Default_LocalDataFilename)) {
                Console.WriteLine("[!] Warning. Can not find local database. Use the `force`, Luke.");
                return 1; // TODO define errorlevels
            }
            else {
                try {
                    tm = new LocalDataProvider(Const.Default_LocalDataFilename).LoadLocalData();
                }
                catch {
                    Console.WriteLine("[!] Error. Can not load local database. Should try to `update`.");
                    return 2; // TODO define errorlevels
                }
            }
#if DEBUG
            Console.WriteLine($"Loaded {tm?.Count} apps."); // TODO STUB
#endif
            return 0;
        }
    }
}
