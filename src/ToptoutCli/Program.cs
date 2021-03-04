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

            cmd.AddCommand( UpdateCommand.Create(
                (userRepo) => {
                    // TODO Download json data
                    Console.WriteLine($"[UPDATE] handler {userRepo}");
                }));

            cmd.Handler = CommandHandler.Create( ( ) => {
                // TODO do MAIN toptout things
                Console.WriteLine( "[ROOT] handler" );
            } );

            int errlevel = cmd.Invoke( args );

            Console.WriteLine( "Press [Enter] to close..." );
            Console.ReadLine();

            return errlevel;
        }
    }
}
