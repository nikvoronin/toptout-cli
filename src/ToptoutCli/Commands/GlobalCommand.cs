using IO.Swagger.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.IO;
using ToptoutCli.Adapters;
using ToptoutCli.Commands.Options;
using ToptoutCli.Provider;

namespace ToptoutCli.Commands
{
    public class GlobalCommand
    {
        public const string Default_ToptoutDataUserRepo = "beatcracker/toptout/master";
        public const string Default_ToptoutRepoPath = "/data";

        public enum Provider { Swagger, Github, Local }

        private GlobalCommand() {}

        public static RootCommand Create(Action<string> executor = null)
        {
            var cmd = new RootCommand( description: "Easily opt-out from telemetry collection." );
            cmd.AddGlobalOption( UserOptionsOption.Create() );

            cmd.Handler = CommandHandler.Create( executor != null 
                ? executor 
                : new Func<string, int>(Execute));

            return cmd;
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

            Dictionary<string, UserOptions.OptionPair> rules;

            if (File.Exists(options)) {
                var uo = new UserOptions(options);
                uo.LoadFromFile();
                rules = uo.Rules;
                ProcessApp(appId, UserOptions.Option.TOptOut);
            }
            else {
                rules = new();
                foreach(var appId in tm.Keys)
                    ProcessApp(appId, UserOptions.Option.TOptOut);
            }

            return 0;
        }
    }
}
