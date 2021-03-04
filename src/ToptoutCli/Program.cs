using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace ToptoutCli
{
    class Program
    {
        static int Main( string[] args )
        {
            Console.WriteLine( "Toptout-cli 0.1.304-alpha" );

            var cmd = new RootCommand( description: "Easily opt-out from telemetry collection." );
            cmd.AddCommand( CreateCommand(
                new string[] { "update", "u", "force" },
                "Download and update local database." ,
                () => {
                    // TODO Download json data
                    Console.WriteLine("[UPDATE] handler");
                }));

            cmd.Handler = CommandHandler.Create( ( ) => {
                // TODO do toptout things
                Console.WriteLine( "[ROOT] handler" );
            } );

            int errlevel = cmd.Invoke( args );

            Console.WriteLine( "Press [Enter] to close..." );
            Console.ReadLine();

            return errlevel;
        }

        internal static Command CreateCommand( string[] aliases, string description, Action handler )
        {
            var cmd = new Command( 
                name: aliases[0],
                description: description
                );

            if (aliases != null) {
                for(int i = 1; i < aliases.Length; i++)
                    cmd.AddAlias( aliases[i]);
            }

            cmd.Handler = CommandHandler.Create( handler );

            return cmd;
        }
    }
}
