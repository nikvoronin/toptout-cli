using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using ToptoutCli.Commands;
using ToptoutCli.Provider;

namespace ToptoutCli
{
    class Program
    {
        static int Main( string[] args )
        {
            Console.WriteLine( "Toptout-cli 0.1.307-alpha" );

            var root = GlobalCommand.Create();
            root.AddCommand( UpdateCommand.Create() );

            int errlevel = root.Invoke( args );

#if DEBUG   // TODO DEBUG only
            Console.WriteLine("Press [Enter] to close...");
            Console.ReadLine();
#endif
            return errlevel;
        }
    }
}
