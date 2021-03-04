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
        public const string Default_UserRepo = "beatcracker/toptout";

        private UpdateCommand() { }

        public static Command Create(Action<string> handler)
        {
            var cmd = new Command("update", "Download and update local database.");
            cmd.AddAlias("u");
            cmd.AddAlias("force");

            cmd.Handler = CommandHandler.Create(handler);

            var o = new Option<string> (
                alias: "--user-repo",
                description: "Changes default 'user/repo' pair to another one",
                getDefaultValue: () => Default_UserRepo
                );

            o.AllowMultipleArgumentsPerToken = false;
            o.AddValidator( r => Validate(r.Tokens) );

            cmd.AddOption(o);

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
